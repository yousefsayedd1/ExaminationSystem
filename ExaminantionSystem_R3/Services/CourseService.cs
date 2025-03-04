using AutoMapper;
using ExaminantionSystem_R3.DTOs;
using ExaminantionSystem_R3.DTOs.Coureses;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Services
{
    public class CourseService
    {
        GeneralRepository<Course> _courseRepo;
        public CourseService(GeneralRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
            
        }

        public IEnumerable<GetCourseDTO> GetAll()
        {
            return _courseRepo.GetAll().Project<GetCourseDTO>().ToList();
;
        }
        public async Task<GetCourseDTO> GetByIdAsync(int id)
        {
            return (await _courseRepo.GetById(id).FirstOrDefaultAsync()).Map<GetCourseDTO>();
            
        }

        public bool Add(AddCourseDTO course)
        {
            return _courseRepo.Add(course.Map<Course>());
            
        }
        public async Task<bool> AddAsync(AddCourseDTO course)
        {
             return  await _courseRepo.AddAsync(course.Map<Course>());
        }
        public bool Update(UpdateCourseDTO course, params string[] modifiedProperties)
        {
            Course updatedCourse = course.Map<Course>();

            return _courseRepo.Update(course.Map<Course>(), nameof(updatedCourse.Name), nameof(updatedCourse.Hours));
            

        }
        public async Task<bool> UpdateAsync(UpdateCourseDTO course)
        {
            Course updatedCourse = course.Map<Course>();
            return await _courseRepo.UpdateAsync(updatedCourse, nameof(updatedCourse.Name), nameof(updatedCourse.Hours)).ConfigureAwait(true);
        }
        public bool Delete(int id)
        {
            return _courseRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseRepo.DeleteAsync(id).ConfigureAwait(true);

        }
    }
}
