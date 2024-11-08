using SchoolManageMent.Data;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly ApplicationDbContext _context;
       public StudentRepository(ApplicationDbContext applicationDbContext)
       {
            _context = applicationDbContext;
       }

        public Student GetStudent(int id)
        {
            return _context.Students.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool AddStudent(Student student)
        {
             _context.Students.Add(student); 
             _context.SaveChanges();
              return true;
        }
    }
}
