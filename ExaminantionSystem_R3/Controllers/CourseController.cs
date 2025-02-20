using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        CourseRepository _courseRepository;
        public CourseController(CourseRepository courseRepository )
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            await _courseRepository.AddAsync(course)
                .ConfigureAwait(true);

            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseRepository.GetAll()
                .ToListAsync()
                .ConfigureAwait(true));
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            Course crs = await _courseRepository.GetById(id).FirstOrDefaultAsync();
                

            return Ok(crs);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await _courseRepository.DeleteAsync(id).ConfigureAwait(true));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Course course)
        {   
            return Ok(await _courseRepository.UpdateAsync(course,nameof(course.Name)).ConfigureAwait(true));
        }
    }
}
