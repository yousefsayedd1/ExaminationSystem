using ExaminantionSystem_R3.Models;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Repositories
{
    public class ExamRepository : GeneralRepository<Exam>
    {
        public async Task<bool> AddQuestionToExamAsync(int examId, int questionId)
        {
            bool exam = _dbSet.Any(x => x.ID == examId);
            bool question = _context.Questions.Any(x => x.ID == questionId);
            if (exam  && question)
            {
                _context.ExamsQuestions.Add(new ExamQuestion() { ExamID = examId, QuestionID = questionId });
                
            }

            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> RemoveQuestionFromExamAsync(int examId, int questionId)
        {
            bool exist = _context.ExamsQuestions.Any(x => x.QuestionID == questionId && x.ExamID == examId);
            if (exist)
            {
                _context.ExamsQuestions.Remove(new ExamQuestion() { ExamID = examId, QuestionID = questionId });
            }

            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<Exam> CreateExamAsync(int courseId)
        {
            Exam exam = new Exam() { CourseID = courseId };
            await _dbSet.AddAsync(exam);
            await _context.SaveChangesAsync();
            return exam;
        }
    }
}
