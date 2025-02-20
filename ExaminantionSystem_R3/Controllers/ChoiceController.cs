using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChoiceController : ControllerBase
    {
        ChoiceRepository _choiceRepository;
        QuestionRepository _questionRepository;
        public ChoiceController(ChoiceRepository choiceRepository, QuestionRepository questionRepository)
        {
            _choiceRepository = choiceRepository;
            _questionRepository = questionRepository;
        }
        [HttpPost]
        public IActionResult Add(Choice choice)
        {
            Question question = _questionRepository.GetById(choice.QuestionId).Include(x => x.Choices).FirstOrDefault();

            question.Choices.Add(choice);
            _questionRepository.Update(question);
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> EditAsync(Choice choice)
        {
            await _choiceRepository.UpdateAsync(choice)
                .ConfigureAwait(true);
            return Ok(true);
        }
      
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var choice = await _choiceRepository.DeleteAsync(id)
                .ConfigureAwait(true);

            return Ok(true);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_choiceRepository.GetAll());
                
        }
    }
}
