using ExaminantionSystem_R3.Models.Enums;
using System.Text.Json.Serialization;

namespace ExaminantionSystem_R3.Models
{
    public class Exam : BaseModel
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public ExamType Type { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<StudentsExams> StudentsExams { get; set; }

    }
}
