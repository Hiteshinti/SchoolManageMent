using SchoolManageMent.Models;

namespace SchoolManageMent.IRepository
{
    public interface IStudentRepository
    {
        bool AddStudent(Student student);
        List<Student> GetStudents();
        bool UpdateStudent(Student student);
    }
}
