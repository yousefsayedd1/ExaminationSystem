using ExaminantionSystem_R3.Models.Enums;

namespace ExaminantionSystem_R3.DTOs.Questions
{
    public class AddQuestionDTO
    {
        public string Head { get; set; }
        public QuestionLevel Level { get; set; }
        public int CourseID { get; set; }
    }
}
