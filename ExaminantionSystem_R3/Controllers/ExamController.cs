using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamController : ControllerBase
    {
        ExamRepository _examRepository;
        CourseRepository _courseRepository;
        QuestionRepository _questionRepository;
        public ExamController(ExamRepository examRepository, CourseRepository courseRepository, QuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _courseRepository = courseRepository;
            _questionRepository = questionRepository;
        }
        [HttpPost]
        public async Task<Exam> CreateExam(int courseId)
        {

            return await _examRepository.CreateExamAsync(courseId);
        }
        [HttpGet]
        public IEnumerable<Exam> GetCourseExams(int courseId)
        {
            return _examRepository.GetAll().Where(x => x.CourseID == courseId);
        }
        [HttpPut]
        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            return await _examRepository.UpdateAsync(exam);
        }
        [HttpPost]
        public async Task<bool> AddQuestionToExam(int examId, int questionId)
        {
            return await _examRepository.AddQuestionToExamAsync(examId, questionId);
        }
        [HttpDelete]
        public async Task<bool> RemoveQuestionFromExam(int examId, int questionId)
        {
            return await _examRepository.RemoveQuestionFromExamAsync(examId, questionId);
        }
        [HttpGet] 
        public async Task<Exam> GetExamById(int examId)
        {
            return await _examRepository.GetById(examId).Result.Where(x=> x.isDeleted == false).FirstOrDefaultAsync();
        }
        [HttpGet] 
        public async Task<IActionResult> CreateRandomExam(int couresId, int easyQuestionsCount, int mediumQuestionsCount, int hardQuestionsCount)
        {

            Course course = _courseRepository.GetById(couresId).FirstOrDefault();
            if (course is not null)
            {
                Exam exam = await _examRepository.CreateExamAsync(couresId);
                IQueryable<Question> easyQuestions = _questionRepository.GetByLevel(QuestionLevel.Easy, easyQuestionsCount);
                IQueryable<Question> mediumQuestions = _questionRepository.GetByLevel(QuestionLevel.Medium, easyQuestionsCount);
                IQueryable<Question> hardQuestions = _questionRepository.GetByLevel(QuestionLevel.Hard, easyQuestionsCount);
                foreach (Question question in easyQuestions)
                {
                    await _examRepository.AddQuestionToExamAsync(exam.ID, question.ID);
                }
                foreach (Question question in mediumQuestions)
                {
                    await _examRepository.AddQuestionToExamAsync(exam.ID, question.ID);
                }
                foreach (Question question in hardQuestions)
                {
                    await _examRepository.AddQuestionToExamAsync(exam.ID, question.ID);
                }
                return Ok(exam);
            }
            else
            {
                return NotFound();
            }
        }


        
    }
}
