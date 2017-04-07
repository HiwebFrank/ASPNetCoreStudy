using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TensunCloud.Data;

namespace TensunCloud.Migrations
{
    [DbContext(typeof(TensunContext))]
    partial class TensunContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TensunCloud.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TensunCloud.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int>("PartyID");

                    b.Property<string>("Tel")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("PartyID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("TensunCloud.Models.Contract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<string>("ContractName")
                        .HasMaxLength(200);

                    b.Property<DateTime>("SignDate");

                    b.HasKey("ID");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("TensunCloud.Models.ContractRelatedParty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractID");

                    b.Property<int>("PartyID");

                    b.Property<int>("PartyRelationType");

                    b.HasKey("ID");

                    b.HasIndex("ContractID");

                    b.HasIndex("PartyID");

                    b.ToTable("ContractRelatedParty");
                });

            modelBuilder.Entity("TensunCloud.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AspNetUsersID");

                    b.Property<int?>("Dept");

                    b.Property<string>("EmpName");

                    b.Property<int?>("Title");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TensunCloud.Models.Party", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PartyName");

                    b.Property<int>("PartyType");

                    b.HasKey("ID");

                    b.ToTable("Party");
                });

            modelBuilder.Entity("TensunCloud.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductCatalog");

                    b.Property<string>("ProductDesc");

                    b.Property<string>("ProductModel");

                    b.Property<string>("ProductName");

                    b.Property<string>("ProductParameter");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TensunCloud.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<string>("ProjectName");

                    b.Property<int>("ProjectType");

                    b.Property<int>("Province");

                    b.Property<int>("Region");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectContract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractID");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ContractID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectContract");
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductID");

                    b.Property<int>("ProjectID");

                    b.Property<int>("Qty");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectProduct");
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectRelatedParty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PartyID");

                    b.Property<int>("PartyRelationType");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("PartyID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectRelatedParty");
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectTeamMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("ProjectID");

                    b.Property<int>("TeamMemberType");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectTeamMember");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TensunCloud.Data.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TensunCloud.Data.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Data.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.Contact", b =>
                {
                    b.HasOne("TensunCloud.Models.Party", "Party")
                        .WithMany("Contacts")
                        .HasForeignKey("PartyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.ContractRelatedParty", b =>
                {
                    b.HasOne("TensunCloud.Models.Contract", "Contract")
                        .WithMany("ContractRelatedParties")
                        .HasForeignKey("ContractID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Models.Party", "Party")
                        .WithMany("ContractRelatedParties")
                        .HasForeignKey("PartyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectContract", b =>
                {
                    b.HasOne("TensunCloud.Models.Contract", "Contract")
                        .WithMany("ProjectContracts")
                        .HasForeignKey("ContractID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Models.Project", "Project")
                        .WithMany("ProjectContracts")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectProduct", b =>
                {
                    b.HasOne("TensunCloud.Models.Product", "Product")
                        .WithMany("ProjectProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Models.Project", "Project")
                        .WithMany("ProjectProducts")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectRelatedParty", b =>
                {
                    b.HasOne("TensunCloud.Models.Party", "Party")
                        .WithMany("ProjectRelatedParties")
                        .HasForeignKey("PartyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Models.Project", "Project")
                        .WithMany("ProjectRelatedParties")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TensunCloud.Models.ProjectTeamMember", b =>
                {
                    b.HasOne("TensunCloud.Models.Employee", "Employee")
                        .WithMany("ProjectTeamMembers")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TensunCloud.Models.Project", "Project")
                        .WithMany("ProjectTeamMembers")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
