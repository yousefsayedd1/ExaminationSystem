using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs
{
    public class SubmitExamDTO
    {
        public ICollection<StudentAnswerDTO> StudentAnswers { get; set; }
    }
}