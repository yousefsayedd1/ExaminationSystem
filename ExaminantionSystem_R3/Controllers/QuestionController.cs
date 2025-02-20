using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        QuestionRepository _questionRepository;
        public QuestionController(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpPost] 
        public async Task<IActionResult> Add(Question question)
        {
            await _questionRepository.AddAsync(question)
                .ConfigureAwait(true);
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Question question)
        {
            bool isUpdated = await _questionRepository.UpdateAsync(question)
                    .ConfigureAwait(true);
            return Ok(isUpdated);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _questionRepository.GetAll()
                .Include(x => x.Choices)
                .ToListAsync()
                .ConfigureAwait(true));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            
            bool isDeleted = await _questionRepository.DeleteAsync(id);
            return Ok(isDeleted);
        }
        [HttpGet]
        public  IActionResult GetByID(int id)
        {
            Question question = _questionRepository.GetByIdWithInclude(id);

            return Ok(question);
        }
    }
}
