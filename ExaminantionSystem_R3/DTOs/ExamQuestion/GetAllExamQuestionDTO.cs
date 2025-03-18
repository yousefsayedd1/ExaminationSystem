using ExaminantionSystem_R3.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminantionSystem_R3.DTOs.ExamQuestion
{
    public class GetAllExamQuestionDTO
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public int Grade { get; set; }
    }
}
