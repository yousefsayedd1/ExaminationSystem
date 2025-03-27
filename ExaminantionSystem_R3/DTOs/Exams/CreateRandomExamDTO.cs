using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.DTOs.ExamQuestion;

namespace ExaminantionSystem_R3.DTOs.Exams
{
    public class CreateRandomExamDTO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public ICollection<GetAllExamQuestionDTO> ExamQuestions { get; set; }
    }
}
