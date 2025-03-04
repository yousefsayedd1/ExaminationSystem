using ExaminantionSystem_R3.DTOs.Choices;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Services
{
    public class ChoiceService
    {
        GeneralRepository<Choice> _choiceService;
        public ChoiceService(GeneralRepository<Choice> choiceService)
        {
            _choiceService = choiceService;
        }
        public async Task<IEnumerable<GetAllChoicesDTO>> GetAllAsync()
        {
            return await _choiceService.GetAll().Project<GetAllChoicesDTO>().ToListAsync();
        }
        public GetByIdChoiceDTO GetById(int id)
        {
            return _choiceService.GetById(id).Map<GetByIdChoiceDTO>();
        }

        public bool Add(AddChoiceDTO choice)
        {
            return _choiceService.Add(choice.Map<Choice>());
        }
        public async Task<bool> AddAsync(AddChoiceDTO choice)
        {
            return await _choiceService.AddAsync(choice.Map<Choice>());
        }
        public bool Update(UpdateChoiceDTO entity, params string[] modifiedProperties)
        {
            return _choiceService.Update(entity.Map<Choice>(), nameof(Choice.Text), nameof(Choice.IsCorrect), nameof(Choice.QuestionId));
        }
        public async Task<bool> UpdateAsync(UpdateChoiceDTO entity, params string[] modifiedProperties)
        {
            return await _choiceService.UpdateAsync(entity.Map<Choice>(), nameof(Choice.Text), nameof(Choice.IsCorrect), nameof(Choice.QuestionId));
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
