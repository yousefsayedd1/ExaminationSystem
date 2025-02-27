using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminantionSystem_R3.Services;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChoiceController : ControllerBase
    {
        ChoiceService _choiceService;
        
        QuestionService _questionService;
        public ChoiceController(ChoiceService choiceService, QuestionService questionService)
        {
            _choiceService = choiceService;
            _questionService = questionService;
        }
        [HttpPost]
        public IActionResult Add(Choice choice)
        {

            return Ok(_choiceService.Add(choice));
            
        }
        [HttpPut]
        public async Task<IActionResult> EditAsync(Choice choice)
        {
            return Ok( await _choiceService.UpdateAsync(choice)
                .ConfigureAwait(true));
            
        }
      
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _choiceService.DeleteAsync(id)
                .ConfigureAwait(true);

            return Ok(isDeleted);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _choiceService.GetAllAsync());
                
        }
    }
}
