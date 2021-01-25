using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Quiz1.Utilities.IdentitySeedData
{
    public class AppDbContextSeedData
    {
        private readonly AppDbContext _context;

        public AppDbContextSeedData(AppDbContext context)
        {
            _context = context;
        }

        public void SeedAdminUser()
        {
            var user = new IdentityUser()
            {
                UserName = "admin@mailinator.com",
                NormalizedUserName = "ADMIN@MAILINATOR.COM",
                Email = "admin@mailinator.com",
                NormalizedEmail = "ADMIN@MAILINATOR.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);
            var adminRole = new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var roUserRole = new IdentityRole
            {
                Name = "readonly",
                NormalizedName = "READONLY"
            };

            if (!_context.Roles.Any(r => r.Name == "admin" || r.Name == "readonly"))
            {
                roleStore.CreateAsync(adminRole);
                roleStore.CreateAsync(roUserRole);
            }

            var newUserRole = new IdentityUserRole<string>
            {
                RoleId = adminRole.Id, // for admin user - admin@mailinator.com username
                UserId = user.Id // for admin role
            };

            _context.UserRoles.Add(newUserRole);

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(user, "Abcd123456@");
                user.PasswordHash = hashed;

                var userStore = new UserStore<IdentityUser>(_context);
                userStore.CreateAsync(user);

                _context.SaveChangesAsync();
            }

            _context.SaveChangesAsync();
        }
    }
}
