using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Quiz1.DataAccess.Models.Identity
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Can Manage Roles and Users", "Can Manage Roles and Users"),
            new Claim("Can Manage Quizzes", "Can Manage Quizzes"),
            new Claim("Can Play Quizzes","Can Play Quizzes"),
            new Claim("Can Read Quizzes","Can Read Quizzes")
        };
    }
}
