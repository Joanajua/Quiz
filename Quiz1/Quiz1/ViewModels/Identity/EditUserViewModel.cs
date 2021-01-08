using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quiz1.ViewModels.Identity
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            // Initialise Claims and Roles lists to avoid NullReferenceExceptions at runtime.
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}
