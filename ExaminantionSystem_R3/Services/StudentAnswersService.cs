namespace ExaminantionSystem_R3.Services
{
    public class StudentAnswersService
    {
        public readonly GeneralRepository<StudentAnswer> _studentAnswerRepo;
        public StudentAnswersService(GeneralRepository<StudentAnswer> studentAnswerRepo)
        {
            _studentAnswerRepo = studentAnswerRepo;
        }
        public bool Add(AddStudentAnswerDTO studentAnswer)
        {
            return _studentAnswerRepo.Add(studentAnswer.Map<StudentAnswer>());
        }
    }
}
