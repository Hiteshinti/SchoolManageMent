using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Controller
{
    [ApiController]
    public class StudentController : ControllerBase
    {
      

        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [Route("api/GetStudent")]
        [HttpGet]
        public IActionResult GetStudent(int Id)
        {

            //var student = _studentRepository.GetAll();
            return Ok();
        }

        [Authorize(Roles="Teacher")]
        [Route("api/AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]Student student)
        {
            RESPONSE rESPONSE = new RESPONSE();
            var isAdded = _studentRepository.AddStudent(student);
            if (isAdded)
            {
                rESPONSE.data = isAdded;
                rESPONSE.message = "Student Added Succesfully";
            }
            else
            {
                rESPONSE.data = isAdded;
                rESPONSE.message = "Student AddedFailed!!1";
            }

            return Ok(rESPONSE);
        }

        [Authorize(Roles = "Teacher")]
        [Route("api/GetStudents")]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            RESPONSE rESPONSE = new RESPONSE();
            var students = _studentRepository.GetStudents();
            rESPONSE.message = "Students fetched Successfully";
            rESPONSE.data = students;

            return Ok(rESPONSE);    

        }

        [Authorize(Roles = "Teacher")]
        [Route("api/UpdateStudent")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            RESPONSE rESPONSE = new RESPONSE();
            var isUpdated = _studentRepository.UpdateStudent(student);
            rESPONSE.message = "Student Updated susccesfully!!";
            rESPONSE.data = isUpdated;
            return Ok(rESPONSE);    

        }

    }
}
