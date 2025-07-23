using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManageMent.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int? Id { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public string? SubjectName { get; set; }
        public int? GradeMarks { get; set; }
        public virtual Student Student { get; set; }
    }
}
