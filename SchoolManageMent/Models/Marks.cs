using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace SchoolManageMent.Models
{
    public class Marks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int? Id { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public string? Subject { get; set; }
        public int? GradeMarks {  get; set; } 
        public virtual Student Student { get; set; }
    }
}
