using ExaminantionSystem_R3.DTOs.ExamQuestion;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;


namespace ExaminantionSystem_R3.Services
{
    public class ExamQuestionService
    {
        public readonly GeneralRepository<ExamQuestion> _examQuestionRepo;
        public ExamQuestionService(GeneralRepository<ExamQuestion> examQuestionRepo)
        {
            _examQuestionRepo = examQuestionRepo;
        }

        public IEnumerable<GetAllExamQuestionDTO> GetAll()
        {
            return _examQuestionRepo.GetAll().Project<GetAllExamQuestionDTO>().ToList();
            
        }
        public async Task<GetByIdExamQuestionDTO> GetById(int id)
        {
            return (await _examQuestionRepo.GetById(id).FirstOrDefaultAsync()).Map<GetByIdExamQuestionDTO>();
            ;
        }

        public bool Add(AddExamQuestionDTO examQuestion)
        {
            return _examQuestionRepo.Add(examQuestion.Map<ExamQuestion>());

        }
        public async Task<bool> AddAsync(AddExamQuestionDTO examQuestion)
        {
            return await _examQuestionRepo.AddAsync(examQuestion.Map<ExamQuestion>());
        }
        public bool Update(UpdateExamQuestionDTO examQuestion, params string[] modifiedProperties)
        {

            return _examQuestionRepo.Update(examQuestion.Map<ExamQuestion>(),nameof(ExamQuestion.ExamID), nameof(ExamQuestion.QuestionID), nameof(ExamQuestion.Grade));


        }
        public async Task<bool> UpdateAsync(UpdateExamQuestionDTO examQuestion, params string[] modifiedProperties)
        {

            return await _examQuestionRepo.UpdateAsync(examQuestion.Map<ExamQuestion>(), nameof(ExamQuestion.ExamID), nameof(ExamQuestion.QuestionID), nameof(ExamQuestion.Grade)).ConfigureAwait(true);

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
