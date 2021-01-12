using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Quiz1.Controllers;

namespace Quiz1.Utilities.SeedData
{
    public class IdentityDataSeeder
    {
        public static void SeedData(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
                ("ro-user@mailinator.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "ro-user@mailinator.com";
                user.Email = "ro-user@mailinator.com";
                user.NormalizedUserName = user.UserName.ToUpperInvariant();

                IdentityResult result = userManager.CreateAsync
                    (user, "Abcd123456@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                        "RO-User").Wait();
                }
            }

            if (userManager.FindByNameAsync
                ("po-user@mailinator.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "po-user@mailinator.com";
                user.Email = "po-user@mailinator.com";
                user.NormalizedUserName = user.UserName.ToUpperInvariant();

                IdentityResult result = userManager.CreateAsync
                    (user, "Abcd123456@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                        "PO-User").Wait();
                }
            }

            if (userManager.FindByNameAsync
                ("admin@mailinator.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@mailinator.com";
                user.Email = "admin@mailinator.com";
                user.NormalizedUserName = user.UserName.ToUpperInvariant();

                IdentityResult result = userManager.CreateAsync
                    (user, "Abcd123456@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                        "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("ReadOnly-User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "ReadOnly-User";
                role.NormalizedName = role.Name.ToUpperInvariant();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
                ("PlayOnly-User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "ReadOnly-User";
                role.NormalizedName = role.Name.ToUpperInvariant();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                role.NormalizedName = role.Name.ToUpperInvariant();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
        }
    }
}
