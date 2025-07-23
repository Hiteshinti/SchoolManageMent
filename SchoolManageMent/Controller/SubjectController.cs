using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManageMent.Data;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;

namespace SchoolManageMent.Controller
{

    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository; 
        public SubjectController(ISubjectRepository subjectRepository) 
        { 
             _subjectRepository = subjectRepository;
        }

        [Route("api/SaveMarks")]
        [Authorize(Roles ="Teacher")]
        [HttpPost]
        public IActionResult Index([FromBody] List<Subject> subjects)
        {
            RESPONSE rESPONSE = new RESPONSE(); 
            var isSaved =_subjectRepository.SaveSubject(subjects);
            rESPONSE.message = "Subjects Saved Successfully.";
            rESPONSE.data = isSaved;    
            return Ok(rESPONSE);    
        }
    }
}
