using System.ComponentModel.DataAnnotations;

namespace Quiz1.DataAccess.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
