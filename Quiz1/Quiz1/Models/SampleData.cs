using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Quiz1.Models
{
    public class AppDbContextSeedData
    {
        private readonly AppDbContext _context;

        public AppDbContextSeedData(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAdminUser()
        {
            var user = new IdentityUser()
            {
                UserName = "email@email.com",
                NormalizedUserName = "EMAIL@EMAIL.COM",
                Email = "email@email.com",
                NormalizedEmail = "EMAIL@EMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);
            var newRole = new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            };


            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(newRole);
            }

            var newUserRole = new IdentityUserRole<string>
            {
                RoleId = newRole.Id, // for Ro-User - po-user@mailinator.com username
                UserId = user.Id // for PlayOnly role
            };

            _context.UserRoles.Add(newUserRole);

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(user, "Abcd123456@");
                user.PasswordHash = hashed;
                var userStore = new UserStore<IdentityUser>(_context);
                await userStore.CreateAsync(user);

                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }

    }
}
