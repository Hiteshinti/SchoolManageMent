using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManageMent.Models
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public DateTime? Date { get; set; } 
        public string? Subject { get; set; }
        public string? Time { get; set; } 
        public virtual Teacher Teacher { get; set; }


    }
}
