using ExaminantionSystem_R3.DTOs;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet]
        public async Task<Student> GetById(int id)
        {
            return await _studentService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> Add(Student student)
        {
            return await _studentService.AddAsync(student);
        }

        [HttpPut]
        public async Task<bool> Update(int id, Student student)
        {
            if (id != student.ID)
            {
                return false;
            }

            return await _studentService.UpdateAsync(student);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _studentService.DeleteAsync(id);
        }

        [HttpGet]
        public decimal ViewBestGrad(int courseId)
        {
            return _studentService.ViewBestGrad(courseId);
        }

        [HttpGet]
        public decimal ViewAvgerageGrad(int courseId)
        {
            return _studentService.ViewAvgerageGrad(courseId);
        }
    }
}
