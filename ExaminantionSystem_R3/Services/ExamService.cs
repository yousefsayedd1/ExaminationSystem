using ExaminantionSystem_R3.DTOs;
using ExaminantionSystem_R3.DTOs.Coureses;
using ExaminantionSystem_R3.DTOs.ExamQuestion;
using ExaminantionSystem_R3.DTOs.Exams;
using ExaminantionSystem_R3.DTOs.Questions;
using ExaminantionSystem_R3.DTOs.StudentAnswer;
using ExaminantionSystem_R3.DTOs.StudentsExams;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Repositories;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Services
{
    public class ExamService
    {
        public readonly GeneralRepository<Exam> _examRepo;
        public readonly ExamQuestionService _examQuestionService;
        public readonly QuestionService _questionService;
        public readonly CourseService _courseService;
        public readonly StudentService _studentService;
        public readonly StudentsExamsService _studentsExamsService;
        public readonly StudentAnswersService _StudentAnswersService;
        
        // technical debt
        public Context _context { get; set; } = new();
        
        public ExamService(GeneralRepository<Exam> examRepo, QuestionService questionService, ExamQuestionService examQuestionService, CourseService courseService)
        {
            _examRepo = examRepo;
            _questionService = questionService;
            _examQuestionService = examQuestionService;
            _courseService = courseService;
        }

        public IEnumerable<GetAllExamsDTO> GetAll()
        {
            return _examRepo.GetAll().Project<GetAllExamsDTO>().ToList();
        }
        public async Task<GetbyidExamDTO> GetById(int id)
        {
            return await _examRepo.GetById(id).Project<GetbyidExamDTO>().FirstOrDefaultAsync();
            
        }

        public bool Add(AddExamDTO exam)
        {
            return _examRepo.Add(exam);

        }
        public async Task<bool> AddAsync(AddExamDTO exam)
        {
            return await _examRepo.AddAsync(exam.Map<Exam>());
        }
        public bool Update(UpdateExamDTO exam, params string[] modifiedProperties)
        {

            return _examRepo.Update(exam.Map<Exam>());


        }
        public async Task<bool> UpdateAsync(UpdateExamDTO exam, params string[] modifiedProperties)
        {

            return await _examRepo.UpdateAsync(exam.Map<Exam>()).ConfigureAwait(true);

        }
        public bool Delete(int id)
        {
            return _examRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _examRepo.DeleteAsync(id).ConfigureAwait(true);

        }

        public async Task<bool> AddQuestionToExamAsync(int examId, int questionId, int grade)
        {
            bool exam = _examRepo.GetAll().Any(x => x.ID == examId);
            bool question = _questionService.GetAll().Any(x => x.ID == questionId);
            if (exam && question)
            {
                return _examQuestionService.Add(new AddExamQuestionDTO() { ExamID = examId, QuestionID = questionId, Grade = grade });
            }
            return false;
        }
        public async Task<bool> RemoveQuestionFromExamAsync(int examId, int questionId)
        {
            return await _examQuestionService.RemoveQuestionFromExamAsync(examId, questionId);

        }
        public async Task<CreateExamDTO> CreateExamAsync(int courseId)
        {
            Exam exam = new Exam() { CourseID = courseId };
            bool examAdded = await _examRepo.AddAsync(exam);
            if(examAdded) return exam.Map<CreateExamDTO>();
            return null;
        }
        public IEnumerable<GetCourseExamDTO> GetCourseExams(int courseId)
        {
            return _examRepo.GetAll().Where(x => x.CourseID == courseId).Project<GetCourseExamDTO>();
        }
        public async Task<CreateRandomExamDTO> CreateRandomExamAsync(int courseId, int easyQuestionsCount,int easyGrade, int mediumQuestionsCount, int mediumGrade, int hardQuestionsCount,int hardGrade)
        {

            GetCourseDTO course = await _courseService.GetByIdAsync(courseId).ConfigureAwait(true);
            if (course is not null)
            {
                CreateExamDTO exam = await CreateExamAsync(courseId);
                IEnumerable<GetQuestionDTO> easyQuestions = _questionService.GetByLevel(QuestionLevel.Easy, easyQuestionsCount);
                IEnumerable<GetQuestionDTO> mediumQuestions = _questionService.GetByLevel(QuestionLevel.Medium, easyQuestionsCount);
                IEnumerable<GetQuestionDTO> hardQuestions = _questionService.GetByLevel(QuestionLevel.Hard, easyQuestionsCount);
                foreach (GetQuestionDTO question in easyQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,easyGrade);
                }
                foreach (GetQuestionDTO question in mediumQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,mediumGrade);
                }
                foreach (GetQuestionDTO question in hardQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,hardGrade);
                }
                return exam.Map<CreateRandomExamDTO>();
            }
            return null;
        }
        public bool AssignStudentToExam(int studentId, int examId)
        {
            var studentExists = _studentService.GetAll().Any(s => s.ID == studentId);
            bool examExists = _examRepo.GetAll().Any(e => e.ID == examId);
            if (studentExists && examExists)
            {
                AddStudentsExamsDTO studentsExams = new() { StudentID = studentId, ExamID = examId };
                _studentsExamsService.Add(studentsExams);
            }
            return false;
        }
        //technical debt 

        public bool SubmitExam(SubmitExamDTO submitExamDTO)
        {
            int studentID= -1;
            int examID = -1; 
            foreach (StudentAnswerDTO studentAnswer in submitExamDTO.StudentAnswers)
            {
                _StudentAnswersService.Add(studentAnswer);
                studentID = studentAnswer.StudentID;
                examID = studentAnswer.ExamID;
            }
            if (studentID > -1 && examID > -1)
            {
                decimal grade = ViewExamResult(examID, studentID);
                AddStudentsExamsDTO studentsExams = new() { StudentID = studentID, ExamID = examID, Grade = grade };
                AddStudentsCoursesDTO studentsCourses = new() { StudentID = studentID, CourseID = _examRepo.GetById(examID).FirstOrDefault().CourseID, Grade = grade };
                _context.StudentsCourses.Add(studentsCourses);
                _context.StudentsExams.Add(studentsExams);
            }

            _context.SaveChanges();
            return true;
        }
        [HttpGet]
        public decimal ViewExamResult(int examId,params int[] studentID)
        {

            var rightQuestions = _context.StudentAnswers
                .Where(x => studentID.Contains(x.StudentID)  && x.ExamID == examId && x.Choice.IsCorrect)
                .Select(x => x.Question.ID);

            var grads = _context.ExamsQuestions
                .Where(x => x.ExamID == examId && rightQuestions.Contains( x.QuestionID))
                .Select(x => x.Grade);

            return grads.Sum();
        }
        public decimal ViewBestGrad(int examId)
        {

            return _context.StudentsExams
                .Where(x => x.ExamID == examId)
                .Select(x => x.Grade)
                .Max();
        }
        public decimal ViewAvgerageGrad(int examId)
        {
            return _context.StudentsExams
                .Where(x => x.ExamID == examId)
                .Select(x => x.Grade)
                .Average();
        }


    }
}
