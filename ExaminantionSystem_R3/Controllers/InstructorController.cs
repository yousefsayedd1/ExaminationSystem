using ExaminantionSystem_R3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstructorController : ControllerBase
    {
        
        public readonly ExamService _examService;
        public InstructorController(InstructorService instructorService)
        {
            _examService = _examService;
        }

        [HttpPost]
        public bool AssignStudentToExam(int studentId, int examId)
        {
            return _examService.AssignStudentToExam(studentId, examId);
        }
    }
}
