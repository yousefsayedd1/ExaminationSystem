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

        public IEnumerable<Question> GetAll()
        {
            return _questionRepo.GetAll();
        }
        public async Task<IEnumerable<Question>> GetAllWithIncludeAsync()
        {
            return await _questionRepo.GetAll()
                .Include(x => x.Choices)
                .ToListAsync();
        }
        public IEnumerable<Question> GetById(int id)
        {
            return _questionRepo.GetById(id);
        }

        public bool Add(AddQuestionDTO question)
        {
             
            return _questionRepo.Add(question.Map<Question>());
        }
        public async Task<bool> AddAsync(Question question)
        {
            return await _questionRepo.AddAsync(question);
        }
        public bool Update(Question question, params string[] modifiedProperties)
        {
            
            return _questionRepo.Update(question);
            

        }
        public async Task<bool> UpdateAsync(Question question, params string[] modifiedProperties)
        {
            return await _questionRepo.UpdateAsync(question);

        }
        public bool Delete(int id)
        {
            return _questionRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _questionRepo.DeleteAsync(id);

        }
        public Question GetByIdWithInclude(int id)
        {
            return _questionRepo.GetById(id).Include(x => x.Choices).FirstOrDefault();
        }
        public IEnumerable<Question> GetByLevel(QuestionLevel questionLevel, int HowManyQuestions)
        {
            IEnumerable<Question> questions = _questionRepo.GetAll().Where(x => x.Level == questionLevel).OrderBy(x => Guid.NewGuid()).Take(HowManyQuestions);
            return questions;
        }
    }
}
