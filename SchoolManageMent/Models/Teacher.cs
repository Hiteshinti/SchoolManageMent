using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManageMent.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual Schedule Schedule {get;set;}
       
    }
}
