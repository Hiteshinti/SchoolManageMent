using Microsoft.EntityFrameworkCore;
using SchoolManageMent.Data;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public  bool AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public bool UpdateStudent(Student student)
        {
            try
            {   
                _context.Students.Update(student);
                //_context.Entry(student).State = EntityState.Modified;
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
