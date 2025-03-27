using ExaminantionSystem_R3.DTOs.StudentsExams;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;

namespace ExaminantionSystem_R3.Services
{
    public class StudentsExamsService
    {
        public readonly GeneralRepository<StudentsExams> _studentsExamsRepo;
        public StudentsExamsService(GeneralRepository<StudentsExams> studentsExamsRepo)
        {
            _studentsExamsRepo = studentsExamsRepo;
        }
        public bool Add(AddStudentsExamsDTO studentsExams)
        {
            return _studentsExamsRepo.Add(studentsExams.Map<StudentsExams>());
        }

    }
}
