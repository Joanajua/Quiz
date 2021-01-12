using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;
using Quiz1.Utilities.CustomExtensions;
using Quiz1.Utilities.SeedData;
using Quiz1.ViewModels;

namespace Quiz1
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // Conditional to migrate database when is not in testing
            //if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            //{
            Database.Migrate();
            //}
        }

        // For unit test a need to set these methods a virtual to override them
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<Result> Results { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.SeedQuizzes();

            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole() {
                    Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                Name = "RO-User",
                NormalizedName = "RO-USER"
                },
                new IdentityRole {
                    Id = "341743f0-asd2–42de-atsy-59kmkkmk72cf6",
                    Name = "PO-User",
                    NormalizedName = "PO-USER"
                },
            });

            //string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            //string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            ////create user
            //var user = new IdentityUser()
            //{
            //    //Id = ADMIN_ID,
            //    Email = "admin@mailinator.com",
            //    EmailConfirmed = true,
            //    UserName = "admin@mailinator.com"
            //};

            ////seed admin role
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "Admin",
            //    NormalizedName = "ADMIN",
            //    Id = ROLE_ID,
            //    ConcurrencyStamp = ROLE_ID
            //});



            ////set user password
            //PasswordHasher<IdentityUser> passwordHasherh = new PasswordHasher<IdentityUser>();
            //user.PasswordHash = passwordHasherh.HashPassword(user, "Abcd123456@");

            ////seed user
            //modelBuilder.Entity<IdentityUser>().HasData(user);

            ////set user role to admin
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = user.Id
            //});

        }
    }
}
