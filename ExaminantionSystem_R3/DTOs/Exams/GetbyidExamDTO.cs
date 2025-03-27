using ExaminantionSystem_R3.Models.Enums;
using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs.Exams
{
    public class GetbyidExamDTO
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public ExamType Type { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }


    }
}