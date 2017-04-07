using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TensunCloud.Data;
using TensunCloud.Models;

namespace TensunCloud.Controllers
{
    public class PartiesController : Controller
    {
        private readonly TensunContext _context;

        public PartiesController(TensunContext context)
        {
            _context = context;    
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parties.ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .SingleOrDefaultAsync(m => m.ID == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            ViewBag.PartyType = new SelectList(System.Enum.GetValues(typeof(PartyType)));
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PartyName,PartyType")] Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PartyType = new SelectList(System.Enum.GetValues(typeof(PartyType)), party.PartyType);
            return View(party);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties.SingleOrDefaultAsync(m => m.ID == id);
            if (party == null)
            {
                return NotFound();
            }
            ViewBag.PartyType = new SelectList(System.Enum.GetValues(typeof(PartyType)), party.PartyType);
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PartyName,PartyType")] Party party)
        {
            if (id != party.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.ID))
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
            ViewBag.PartyType = new SelectList(System.Enum.GetValues(typeof(PartyType)), party.PartyType);
            return View(party);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .SingleOrDefaultAsync(m => m.ID == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Parties.SingleOrDefaultAsync(m => m.ID == id);
            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PartyExists(int id)
        {
            return _context.Parties.Any(e => e.ID == id);
        }
    }
}
