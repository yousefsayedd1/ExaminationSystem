using ExaminantionSystem_R3.DTOs;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminationSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Services
{
    public class StudentService 
    {
        GeneralRepository<Student> _StudentRepo;
        Context _context = new Context();
        public StudentService(GeneralRepository<Student> studentRepo)
        {
            _StudentRepo = studentRepo;
        }

        public IEnumerable<Student> GetAll()
        {
            return _StudentRepo.GetAll().ToList();
            
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _StudentRepo.GetById(id).FirstOrDefaultAsync();
            
        }

        public bool Add(Student student)
        {
            return _StudentRepo.Add(student);

        }
        public async Task<bool> AddAsync(Student student)
        {
            return await _StudentRepo.AddAsync(student);
        }
        public bool Update(Student student, params string[] modifiedProperties)
        {

            return _StudentRepo.Update(student);


        }
        public async Task<bool> UpdateAsync(Student student, params string[] modifiedProperties)
        {

            return await _StudentRepo.UpdateAsync(student).ConfigureAwait(true);

        }
        public bool Delete(int id)
        {
            return _StudentRepo.Delete(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _StudentRepo.DeleteAsync(id).ConfigureAwait(true);

        }

        public decimal ViewBestGrad(int courseId)
        {

            return _context.StudentsCourses
                .Where(x => x.CouresID == courseId)
                .Select(x => x.Grade)
                .Max();
        }
        public decimal ViewAvgerageGrad(int courseId)
        {
            return _context.StudentsCourses
                .Where(x => x.CouresID == courseId)
                .Select(x => x.Grade)
                .Average();
        }

       
    }
}

