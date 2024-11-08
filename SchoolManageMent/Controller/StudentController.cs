using Microsoft.AspNetCore.Mvc;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Controller
{
    public class StudentController : ControllerBase
    {
      

        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult GetStudent(int Id)
        {

            var student = _studentRepository.GetStudent(Id);
            return Ok(student);
        }
        [HttpGet]
        public IActionResult AddStudent(Student student)
        {

            var isAdded = _studentRepository.AddStudent(student);
            return Ok(isAdded);
        }

    }
}
