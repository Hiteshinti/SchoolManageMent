using System.ComponentModel.DataAnnotations;

namespace SchoolManageMent.Models
{
    public class Login
    {
        [Required]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }
    }
}
