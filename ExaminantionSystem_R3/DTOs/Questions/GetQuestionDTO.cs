using ExaminantionSystem_R3.Models.Enums;

namespace ExaminantionSystem_R3.DTOs.Questions
{
    public class GetQuestionDTO
    {
        public int ID { get; set; }
        public string Head { get; set; }
        public QuestionLevel Level { get; set; }
        public int CourseID { get; set; }
    }
}