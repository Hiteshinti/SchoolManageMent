using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManageMent.Models
{
   
    public class AppUser: IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email {  get; set; }

        [Required] 
        public string? Password { get; set; }

        [Required]
        public string? PhoneNumber {  get; set; }

        

    }
}
