using ExaminantionSystem_R3.DTOs.Questions;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Services
{
    public class QuestionService
    {
        GeneralRepository<Question> _questionRepo;
        public QuestionService(GeneralRepository<Question> questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public IEnumerable<GetQuestionDTO> GetAll()
        {
            return _questionRepo.GetAll().Project<GetQuestionDTO>();
        }
        public async Task<IEnumerable<GetQuestionWithChoicesDTO>> GetAllWithIncludeAsync()
        {
            return  await _questionRepo.GetAll()
                .Include(x => x.Choices)
                .Project<GetQuestionWithChoicesDTO>().ToListAsync();
        }
        public GetQuestionDTO GetById(int id)
        {
            return _questionRepo.GetById(id).Map<GetQuestionDTO>();
        }

        public bool Add(AddQuestionDTO question)
        {
             
            return _questionRepo.Add(question.Map<Question>());
        }
        public async Task<bool> AddAsync(AddQuestionDTO question)
        {
            return await _questionRepo.AddAsync(question.Map<Question>());
        }
        public bool Update(UpdateQuestionDTO question, params string[] modifiedProperties)
        {
            
            return _questionRepo.Update(question.Map<Question>(),
                nameof(Question.Head), nameof(Question.Level), nameof(Question.CourseID));
            

        }
        public async Task<bool> UpdateAsync(UpdateQuestionDTO question, params string[] modifiedProperties)
        {
            return await _questionRepo.UpdateAsync(question.Map<Question>(), nameof(Question.Head), nameof(Question.Level), nameof(Question.CourseID));

        }
        public bool Delete(int id)
        {
            return _questionRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _questionRepo.DeleteAsync(id);

        }
        public GetQuestionWithChoicesDTO GetByIdWithInclude(int id)
        {
            return _questionRepo.GetById(id).Include(x => x.Choices).FirstOrDefault().Map<GetQuestionWithChoicesDTO>();
        }
        public IEnumerable<GetQuestionDTO> GetByLevel(QuestionLevel questionLevel, int HowManyQuestions)
        {
            IEnumerable<GetQuestionDTO> questions = _questionRepo.GetAll().Where(x => x.Level == questionLevel).OrderBy(x => Guid.NewGuid()).Take(HowManyQuestions).Project<GetQuestionDTO>();
            return questions;
        }
    }
}
