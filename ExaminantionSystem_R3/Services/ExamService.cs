using ExaminantionSystem_R3.DTOs;
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
        // technical debt
        public Context _context { get; set; } = new();
        
        public ExamService(GeneralRepository<Exam> examRepo, QuestionService questionService, ExamQuestionService examQuestionService, CourseService courseService)
        {
            _examRepo = examRepo;
            _questionService = questionService;
            _examQuestionService = examQuestionService;
            _courseService = courseService;
        }

        public IEnumerable<Exam> GetAll()
        {
            return _examRepo.GetAll().ToList();
        }
        public async Task<Exam> GetById(int id)
        {
            return await _examRepo.GetById(id).FirstOrDefaultAsync();
            ;
        }

        public bool Add(Exam exam)
        {
            return _examRepo.Add(exam);

        }
        public async Task<bool> AddAsync(Exam exam)
        {
            return await _examRepo.AddAsync(exam);
        }
        public bool Update(Exam exam, params string[] modifiedProperties)
        {

            return _examRepo.Update(exam);


        }
        public async Task<bool> UpdateAsync(Exam exam, params string[] modifiedProperties)
        {

            return await _examRepo.UpdateAsync(exam).ConfigureAwait(true);

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
                return _examQuestionService.Add(new ExamQuestion() { ExamID = examId, QuestionID = questionId, Grade = grade });
            }
            return false;
        }
        public async Task<bool> RemoveQuestionFromExamAsync(int examId, int questionId)
        {
            return await _examQuestionService.RemoveQuestionFromExamAsync(examId, questionId);

        }
        public async Task<Exam> CreateExamAsync(int courseId)
        {
            Exam exam = new Exam() { CourseID = courseId };
            bool examAdded = await _examRepo.AddAsync(exam);
            if(examAdded) return exam;
            return null;
        }
        public IEnumerable<Exam> GetCourseExams(int courseId)
        {
            return _examRepo.GetAll().Where(x => x.CourseID == courseId);
        }
        public async Task<Exam> CreateRandomExamAsync(int courseId, int easyQuestionsCount,int easyGrade, int mediumQuestionsCount, int mediumGrade, int hardQuestionsCount,int hardGrade)
        {

            Course course = await _courseService.GetByIdAsync(courseId).ConfigureAwait(true);
            if (course is not null)
            {
                Exam exam = await CreateExamAsync(courseId);
                IEnumerable<Question> easyQuestions = _questionService.GetByLevel(QuestionLevel.Easy, easyQuestionsCount);
                IEnumerable<Question> mediumQuestions = _questionService.GetByLevel(QuestionLevel.Medium, easyQuestionsCount);
                IEnumerable<Question> hardQuestions = _questionService.GetByLevel(QuestionLevel.Hard, easyQuestionsCount);
                foreach (Question question in easyQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,easyGrade);
                }
                foreach (Question question in mediumQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,mediumGrade);
                }
                foreach (Question question in hardQuestions)
                {
                    await AddQuestionToExamAsync(exam.ID, question.ID,hardGrade);
                }
                return exam;
            }
            return null;
        }
        //technical debt
        public bool AssignStudentToExam(int studentId, int examId)
        {
            var studentExists = _context.Students.Any(s => s.ID == studentId);
            bool examExists = _context.Exams.Any(e => e.ID == examId);
            if (studentExists && examExists)
            {
                StudentsExams studentsExams = new StudentsExams() { StudentID = studentId, ExamID = examId };
                _context.StudentsExams.Add(studentsExams);
            }
            return false;
        }
        //technical debt 

        public bool SubmitExam(SumbitExamDTO submitExamDTO)
        {
            int studentID= -1;
            int examID = -1; 
            foreach (StudentAnswer studentAnswer in submitExamDTO.StudentAnswers)
            {
                _context.StudentAnswers.Add(studentAnswer);
                studentID = studentAnswer.StudentID;
                examID = studentAnswer.ExamID;
            }
            if (studentID > -1 && examID > -1)
            {
                decimal grade = ViewExamResult(examID, studentID);
                StudentsExams studentsExams = new() { StudentID = studentID, ExamID = examID, Grade = grade };
                StudentsCourses studentsCourses = new() { StudentID = studentID, CouresID = _context.Exams.FirstOrDefault(x => x.ID == examID).CourseID, Grade = grade };
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
