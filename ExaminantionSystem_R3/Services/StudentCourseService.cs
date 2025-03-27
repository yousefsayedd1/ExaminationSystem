using ExaminantionSystem_R3.Repositories;

namespace ExaminantionSystem_R3.Services
{
    public class StudentCourseService
    {
        public readonly GeneralRepository<StudentCourse> _studentCourseRepo;
        public StudentCourseService(GeneralRepository<StudentCourse> studentCourseRepo)
        {
            _studentCourseRepo = studentCourseRepo;
        }
        public bool Add(AddStudentsCoursesDTO studentCourse)
        {
            return _studentCourseRepo.Add(studentCourse.Map<StudentCourse>());
        }
    }
}
