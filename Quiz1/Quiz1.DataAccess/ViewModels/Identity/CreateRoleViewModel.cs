using System.ComponentModel.DataAnnotations;

namespace Quiz1.DataAccess.ViewModels.Identity
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
