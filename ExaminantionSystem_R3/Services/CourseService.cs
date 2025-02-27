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

        public IEnumerable<Course> GetAll()
        {
            return _courseRepo.GetAll().ToList();
;
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseRepo.GetById(id).FirstOrDefaultAsync();
            ;
        }

        public bool Add(Course course)
        {
            return _courseRepo.Add(course);
            
        }
        public async Task<bool> AddAsync(Course course)
        {
             return  await _courseRepo.AddAsync(course);
        }
        public bool Update(Course course, params string[] modifiedProperties)
        {
           
            return _courseRepo.Update(course);
            

        }
        public async Task<bool> UpdateAsync(Course course, params string[] modifiedProperties)
        {

            return await _courseRepo.UpdateAsync(course).ConfigureAwait(true);

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
