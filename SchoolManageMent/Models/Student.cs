using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace SchoolManageMent.Models
{
    
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Standard { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }


       
    }
}



