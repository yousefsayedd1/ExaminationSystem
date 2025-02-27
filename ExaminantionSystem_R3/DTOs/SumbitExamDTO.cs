using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs
{
    public class SumbitExamDTO
    {
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}