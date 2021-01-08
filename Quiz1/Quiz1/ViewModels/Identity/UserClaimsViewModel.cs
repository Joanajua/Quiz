using System.Collections.Generic;
using Quiz1.Models.Identity;

namespace Quiz1.ViewModels.Identity
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
