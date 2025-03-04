using ExaminantionSystem_R3.DTOs;
using ExaminantionSystem_R3.DTOs.Coureses;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminantionSystem_R3.Services;
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
        CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourseDTO course)
        {
            await _courseService.AddAsync(course)
                .ConfigureAwait(true);

            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_courseService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            GetCourseDTO crs = await _courseService.GetByIdAsync(id);
            return Ok(crs);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _courseService.DeleteAsync(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDTO course)
        {   
            return Ok(await _courseService.UpdateAsync(course));
        }
    }
}
