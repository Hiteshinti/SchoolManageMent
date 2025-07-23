using SchoolManageMent.Data;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Repository
{
    public class SubjectRepository :ISubjectRepository
    { 
         private readonly ApplicationDbContext _context;    

         public SubjectRepository(ApplicationDbContext context)
         {
               _context = context;
         }
         public bool SaveSubject(List<Subject> subjects)
         {
            try
            {
                _context.AddRange(subjects);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
         }
    } 
}
