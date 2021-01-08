using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz1.DataAccess.Models.Identity
{
    public class UserClaim
    {
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
