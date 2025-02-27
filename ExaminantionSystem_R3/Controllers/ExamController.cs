using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Repositories;
using ExaminantionSystem_R3.Services;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamController : ControllerBase
    {
        ExamService _examService;
      
        public ExamController(ExamService examService, CourseService courseService, QuestionService questionService)
        {
            _examService = examService;
         
        }
        [HttpPost]
        public async Task<Exam> CreateExam(int courseId)
        {

            return await _examService.CreateExamAsync(courseId);
        }
        [HttpGet]
        public IEnumerable<Exam> GetCourseExams(int courseId)
        {
            return _examService.GetCourseExams(courseId);
        }
        [HttpPut]
        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            return await _examService.UpdateAsync(exam);
        }
        [HttpPost]
        public async Task<bool> AddQuestionToExam(int examId, int questionId,int grade)
        {
            return await _examService.AddQuestionToExamAsync(examId, questionId,grade);
        }
        [HttpDelete]
        public async Task<bool> RemoveQuestionFromExam(int examId, int questionId)
        {
            return await _examService.RemoveQuestionFromExamAsync(examId, questionId);
        }
        [HttpGet] 
        public async Task<Exam> GetExamById(int examId)
        {
            return await _examService.GetById(examId);
        }
        [HttpGet] 
        public async Task<IActionResult> CreateRandomExam(int courseId, int easyQuestionsCount, int easyGrade, int mediumQuestionsCount, int mediumGrade, int hardQuestionsCount, int hardGrade)
        {
            return Ok( await _examService.CreateRandomExamAsync(courseId, easyQuestionsCount,easyGrade, mediumQuestionsCount, mediumGrade, hardQuestionsCount, hardGrade));
        }
        

        [HttpPost]
        public bool AssignStudentToExam(int studentId, int examId)
        {
            return _examService.AssignStudentToExam(studentId, examId);
        }
        [HttpGet]
        public decimal ViewExamResult(int examId, params int[] studentID)
        {

           return  _examService.ViewExamResult(examId, studentID);
        }
        [HttpGet]
        public decimal ViewBestGrad(int examId)
        {

            return _examService.ViewBestGrad(examId);
        }
        [HttpGet]
        public decimal ViewAvgerageGrad(int examId)
        {
            return _examService.ViewAvgerageGrad(examId);
        }

    }
}
