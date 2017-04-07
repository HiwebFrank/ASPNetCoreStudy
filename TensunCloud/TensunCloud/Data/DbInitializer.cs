using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Models;

namespace TensunCloud.Data
{
    public class DbInitializer
    {
        public static void Initialize(TensunContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{ProductCatalog=ProductCatalog.A类产品,ProductName="产品AAA",ProductModel="TSF-9200",ProductParameter="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. ",ProductDesc="可以产生 10 种不同语言（或称为语言风格）的范例文字，并能设定产生字数、字符数或段落数，在进阶选项里，还能针对文字字型、粗细、文字距离、对齐方式来产生 CSS 程序代码。"},
                new Product{ProductCatalog=ProductCatalog.B类产品 ,ProductName="产品BBB",ProductModel="GS9208",ProductParameter="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. ",ProductDesc="可以产生 10 种不同语言（或称为语言风格）的范例文字，并能设定产生字数、字符数或段落数，在进阶选项里，还能针对文字字型、粗细、文字距离、对齐方式来产生 CSS 程序代码。"},
                new Product{ProductCatalog=ProductCatalog.C类产品,ProductName="产品CCC",ProductModel="TS-VID612S",ProductParameter="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. ",ProductDesc="可以产生 10 种不同语言（或称为语言风格）的范例文字，并能设定产生字数、字符数或段落数，在进阶选项里，还能针对文字字型、粗细、文字距离、对齐方式来产生 CSS 程序代码。"}

            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
                new Project{ProjectName="陕西ABCD项目",ProjectType=ProjectType.系统集成,Province=Province.陕西省,Region=TSRegion.西区,StartDate=DateTime.Parse("2017/3/1"),DeliveryDate=DateTime.Parse("2017/9/1"),Status=ProjectStatus.进行中},
                new Project{ProjectName="汉中EFG项目",ProjectType=ProjectType.系统集成,Province=Province.陕西省,Region=TSRegion.西区,StartDate=DateTime.Parse("2017/2/1"),DeliveryDate=DateTime.Parse("2017/6/1"),Status=ProjectStatus.进行中},
                new Project{ProjectName="成都AAA项目",ProjectType=ProjectType.系统集成,Province=Province.四川省,Region=TSRegion.西南区,StartDate=DateTime.Parse("2016/3/1"),DeliveryDate=DateTime.Parse("2016/9/1"),Status=ProjectStatus.维保期}
            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var projectproducts = new ProjectProduct[]
            {
                new ProjectProduct{ProjectID=1,ProductID=1,Qty=100},
                new ProjectProduct{ProjectID=1,ProductID=2,Qty=120},
                new ProjectProduct{ProjectID=1,ProductID=3,Qty=50},
                new ProjectProduct{ProjectID=2,ProductID=1,Qty=50},
                new ProjectProduct{ProjectID=2,ProductID=2,Qty=80},
                new ProjectProduct{ProjectID=2,ProductID=3,Qty=60},
                new ProjectProduct{ProjectID=3,ProductID=2,Qty=90},
                new ProjectProduct{ProjectID=3,ProductID=1,Qty=85}
            };
            foreach (ProjectProduct pp in projectproducts)
            {
                context.ProjectProducts.Add(pp);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{EmpName="小张",Dept=TSDept.技术部,Title=TSTitle.部门经理},
                new Employee{EmpName="小李",Dept=TSDept.技术部,Title=TSTitle.员工},
                new Employee{EmpName="小王",Dept=TSDept.技术部,Title=TSTitle.部门经理}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var projectteammembers = new ProjectTeamMember[]
            {
                new ProjectTeamMember{ProjectID=1,EmployeeID=1,TeamMemberType=TeamMemberType.项目经理},
                new ProjectTeamMember{ProjectID=1,EmployeeID=2,TeamMemberType=TeamMemberType.实施工程师},
                new ProjectTeamMember{ProjectID=1,EmployeeID=3,TeamMemberType=TeamMemberType.实施工程师},
                new ProjectTeamMember{ProjectID=2,EmployeeID=2,TeamMemberType=TeamMemberType.项目经理},
                new ProjectTeamMember{ProjectID=2,EmployeeID=3,TeamMemberType=TeamMemberType.实施工程师},
                new ProjectTeamMember{ProjectID=3,EmployeeID=1,TeamMemberType=TeamMemberType.项目经理},
                new ProjectTeamMember{ProjectID=3,EmployeeID=2,TeamMemberType=TeamMemberType.实施工程师},
                new ProjectTeamMember{ProjectID=3,EmployeeID=3,TeamMemberType=TeamMemberType.售前技术}
            };

            foreach (ProjectTeamMember pt in projectteammembers)
            {
                context.ProjectTeamMembers.Add(pt);
            }
            context.SaveChanges();


            
        }
    }
}
