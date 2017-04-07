using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TensunCloud.Data;
using TensunCloud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TensunCloud.Controllers
{
    //[Authorize]
    public class ProjectsController : Controller
    {
        private readonly TensunContext _context;

        public ProjectsController(TensunContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectProducts)
                    .ThenInclude(pp => pp.Product)
                .Include(p => p.ProjectTeamMembers)
                    .ThenInclude(pt => pt.Employee)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }


        // GET: Projects/Create
        public IActionResult Create()
        {
            EnumDropDownList();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectName,ProjectType,Province,Region,StartDate,DeliveryDate,Status")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            EnumDropDownList(null, project.Region, project.Province, null, project.ProjectType, project.Status, null, null, null, null);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);


            if (project == null)
            {
                return NotFound();
            }
            EnumDropDownList(null, project.Region, project.Province, null, project.ProjectType, project.Status, null, null, null, null);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectName,ProjectType,Province,Region,StartDate,DeliveryDate,Status")] Project project)
        {
            if (id != project.ID)
            {
                return NotFound();
            }




            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            EnumDropDownList(null, project.Region, project.Province, null, project.ProjectType, project.Status, null, null, null, null);
            return View(project);
        }

        public async Task<IActionResult> EditProjectProducts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectProducts)
                    .ThenInclude(pp => pp.Product)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (project == null)
            {
                return NotFound();
            }
            ProductDropDownList();
            return View(project);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProjectProducts(int id, [Bind("ID,ProjectID,ProductID,Qty")] ProjectProduct projectproduct)
        {
            if (id != projectproduct.ProjectID)
            {
                return NotFound();
            }

            var projectproducts = await _context.ProjectProducts
                .Include(p => p.Product)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);



            if (await TryUpdateModelAsync<ProjectProduct>(
                projectproducts, "", pp => pp.ProjectID, pp => pp.ProductID, pp => pp.Qty)
                )
            {
                try
                {
                    //_context.Attach(projectproduct);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectproduct.ProjectID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Details", new { @id = id });
            }
            ProductDropDownList();
            return View(projectproduct);
        }

        private void EnumDropDownList(object seletedTSDept = null, object seletedTSRegion = null, object seletedProvince = null,
            object seletedTSTitle = null, object seletedProjectType = null, object seletedProjectStatus = null, object seletedProductCatalog = null,
            object seletedTeamMemberType = null, object seletedPartyRelationType = null, object seletedPartyType = null)
        {

            ViewBag.TSDept = new SelectList(System.Enum.GetValues(typeof(TSDept)), seletedTSDept);
            ViewBag.TSRegion = new SelectList(System.Enum.GetValues(typeof(TSRegion)), seletedTSRegion);
            ViewBag.Province = new SelectList(System.Enum.GetValues(typeof(Province)), seletedProvince);
            ViewBag.TSTitle = new SelectList(System.Enum.GetValues(typeof(TSTitle)), seletedTSTitle);
            ViewBag.ProjectType = new SelectList(System.Enum.GetValues(typeof(ProjectType)), seletedProjectType);
            ViewBag.ProjectStatus = new SelectList(System.Enum.GetValues(typeof(ProjectStatus)), seletedProjectStatus);
            ViewBag.ProductCatalog = new SelectList(System.Enum.GetValues(typeof(ProductCatalog)), seletedProductCatalog);
            ViewBag.TeamMemberType = new SelectList(System.Enum.GetValues(typeof(TeamMemberType)), seletedTeamMemberType);
            ViewBag.PartyRelationType = new SelectList(System.Enum.GetValues(typeof(PartyRelationType)), seletedPartyRelationType);
            ViewBag.PartyType = new SelectList(System.Enum.GetValues(typeof(PartyType)), seletedPartyType);

        }

        private void ProductDropDownList(object seletedProduct = null)
        {

            var productsQuery = from p in _context.Products
                                orderby p.ProductName
                                select p;
            ViewBag.DropDownProducts = new SelectList(productsQuery.AsNoTracking(), "ID", "ProductName", seletedProduct);
            ViewBag.DropDownProductsModel = new SelectList(productsQuery.AsNoTracking(), "ID", "ProductModel", seletedProduct);
        }


        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }

        public async Task<IActionResult> DeleteProjectProduct(int id)
        {

            var projectproduct = await _context.ProjectProducts.SingleOrDefaultAsync(pp => pp.ID == id);
            int projectID = projectproduct.ProjectID;  //获取返回位置
            _context.ProjectProducts.Remove(projectproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("EditProjectProducts", new { @id = projectID });
        }
        public async Task<IActionResult> AddProjectProduct(int id)
        {

            var PrdQty = Request.Form["prdqty"];
            var PrdID = Request.Form["prdid"];
            if (!(String.IsNullOrEmpty(PrdQty) || String.IsNullOrEmpty(PrdID)))
            {
                // todo： 判断产品是否有重复


                ProjectProduct projectproduct = new ProjectProduct();
                projectproduct.ProjectID = id;
                projectproduct.Qty = int.Parse(PrdQty);
                projectproduct.ProductID = int.Parse(PrdID);


                _context.ProjectProducts.Add(projectproduct);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("EditProjectProducts", new { @id = id });
        }
    }
}
