using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TensunCloud.Data
{
    public class TensunContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public TensunContext(DbContextOptions<TensunContext> options):base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractRelatedParty> ContractRelatedParties { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectContract> ProjectContracts { get; set; }
        public DbSet<ProjectProduct> ProjectProducts { get; set; }
        public DbSet<ProjectRelatedParty> ProjectRelatedParties { get; set; }
        public DbSet<ProjectTeamMember> ProjectTeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<ContractRelatedParty>().ToTable("ContractRelatedParty");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Party>().ToTable("Party");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<ProjectContract>().ToTable("ProjectContract");
            modelBuilder.Entity<ProjectProduct>().ToTable("ProjectProduct");
            modelBuilder.Entity<ProjectRelatedParty>().ToTable("ProjectRelatedParty");
            modelBuilder.Entity<ProjectTeamMember>().ToTable("ProjectTeamMember");


        }
              
    }
}
