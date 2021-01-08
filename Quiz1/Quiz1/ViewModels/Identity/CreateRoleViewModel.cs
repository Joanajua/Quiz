using System.ComponentModel.DataAnnotations;

namespace Quiz1.ViewModels.Identity
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
