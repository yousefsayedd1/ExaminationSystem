using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Services
{
    public class ExamQuestionService
    {
        public readonly GeneralRepository<ExamQuestion> _examQuestionRepo;
        public ExamQuestionService(GeneralRepository<ExamQuestion> examQuestionRepo)
        {
            _examQuestionRepo = examQuestionRepo;
        }

        public IEnumerable<ExamQuestion> GetAll()
        {
            return _examQuestionRepo.GetAll().ToList();
            ;
        }
        public async Task<ExamQuestion> GetById(int id)
        {
            return await _examQuestionRepo.GetById(id).FirstOrDefaultAsync();
            ;
        }

        public bool Add(ExamQuestion examQuestion)
        {
            return _examQuestionRepo.Add(examQuestion);

        }
        public async Task<bool> AddAsync(ExamQuestion examQuestion)
        {
            return await _examQuestionRepo.AddAsync(examQuestion);
        }
        public bool Update(ExamQuestion examQuestion, params string[] modifiedProperties)
        {

            return _examQuestionRepo.Update(examQuestion);


        }
        public async Task<bool> UpdateAsync(ExamQuestion examQuestion, params string[] modifiedProperties)
        {

            return await _examQuestionRepo.UpdateAsync(examQuestion).ConfigureAwait(true);

        }
        public async Task<bool> RemoveQuestionFromExamAsync(int examId, int questionId)
        {
            bool exist = _examQuestionRepo.GetAll().Any(x => x.QuestionID == questionId && x.ExamID == examId);
            if (exist)
            {
                int examQuestionID = await _examQuestionRepo.GetAll().Where(x => x.ExamID == examId && x.QuestionID == questionId).Select(x => x.ID).FirstOrDefaultAsync();
                return _examQuestionRepo.Delete(examQuestionID);
            }
            return false;
        }
        
    }
}
