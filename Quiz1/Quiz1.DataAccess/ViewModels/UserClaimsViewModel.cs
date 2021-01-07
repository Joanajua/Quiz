using System.Collections.Generic;
using Quiz1.DataAccess.Models;

namespace Quiz1.DataAccess.ViewModels
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaims>();
        }

        public string UserId { get; set; }
        public List<UserClaims> Claims { get; set; }
    }
}
