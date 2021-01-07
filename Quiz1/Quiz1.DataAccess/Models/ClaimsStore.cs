using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Quiz1.DataAccess.Models
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Manage Roles and Users", "Manage Roles and Users"),
            new Claim("Manage Book Records","Manage Book Records"),
            new Claim("Manage Check In and Check Out","Manage Check In and Check Out")
        };
    }
}
