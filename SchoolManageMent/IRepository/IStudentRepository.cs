using SchoolManageMent.Models;

namespace SchoolManageMent.IRepository
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        bool AddStudent(Student student);   
             
    }
}
