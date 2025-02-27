using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Services
{
    public class ChoiceService
    {
        GeneralRepository<Choice> _choiceService;
        QuestionService _questionService;
        public ChoiceService(GeneralRepository<Choice> choiceService, QuestionService questionService)
        {
            _choiceService = choiceService;
            _questionService = questionService;
        }
        public async Task<IEnumerable<Choice>> GetAllAsync()
        {
            return await _choiceService.GetAll().ToListAsync();
        }
        public IQueryable<Choice> GetById(int id)
        {
            return _choiceService.GetById(id);
        }

        public bool Add(Choice choice)
        {
            Question question = _questionService.GetByIdWithInclude(choice.QuestionId);
            _choiceService.Add(choice);
            return _questionService.Update(question);
        }
        public async Task<bool> AddAsync(Choice choice)
        {
            return await _choiceService.AddAsync(choice);
            
        }
        public bool Update(Choice entity, params string[] modifiedProperties)
        {
            return _choiceService.Update(entity);

        }
        public async Task<bool> UpdateAsync(Choice entity, params string[] modifiedProperties)
        {
           
            return await _choiceService.UpdateAsync(entity);

        }
        public bool Delete(int id)
        {
            return _choiceService.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _choiceService.DeleteAsync(id);

        }
    

}
}
