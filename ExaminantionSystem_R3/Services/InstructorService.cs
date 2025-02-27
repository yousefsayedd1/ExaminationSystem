using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminationSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Services
{
    public class InstructorService
    {
        GeneralRepository<Instructor> _instructorRepo
            ;
        public InstructorService(GeneralRepository<Instructor> instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _instructorRepo.GetAll().ToList();
            ;
        }
        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorRepo.GetById(id).FirstOrDefaultAsync();
            ;
        }

        public bool Add(Instructor instructor)
        {
            return _instructorRepo.Add(instructor);

        }
        public async Task<bool> AddAsync(Instructor instructor)
        {
            return await _instructorRepo.AddAsync(instructor);
        }
        public bool Update(Instructor instructor, params string[] modifiedProperties)
        {

            return _instructorRepo.Update(instructor);


        }
        public async Task<bool> UpdateAsync(Instructor instructor, params string[] modifiedProperties)
        {

            return await _instructorRepo.UpdateAsync(instructor).ConfigureAwait(true);

        }
        public bool Delete(int id)
        {
            return _instructorRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _instructorRepo.DeleteAsync(id).ConfigureAwait(true);

        }
    }
}
