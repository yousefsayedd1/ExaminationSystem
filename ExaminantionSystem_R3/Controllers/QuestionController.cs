using ExaminantionSystem_R3.DTOs.Questions;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminantionSystem_R3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        QuestionService _questionService;
        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost] 
        public async Task<IActionResult> Add(AddQuestionDTO question)
        {
            //await _questionService.AddAsync(question)
            //    .ConfigureAwait(true);
            _questionService.Add(question); 
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestionDTO question)
        {
            bool isUpdated = await _questionService.UpdateAsync(question)
                    .ConfigureAwait(true);
            return Ok(isUpdated);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _questionService.GetAllWithIncludeAsync()
                .ConfigureAwait(true));
            

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            
            bool isDeleted = await _questionService.DeleteAsync(id);
            return Ok(isDeleted);
        }
        [HttpGet]
        public  IActionResult GetByID(int id)
        {
            GetQuestionWithChoicesDTO question = _questionService.GetByIdWithInclude(id);

            return Ok(question);
        }
    }
}
