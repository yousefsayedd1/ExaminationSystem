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
        [JsonIgnore]
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        [JsonIgnore]

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        [JsonIgnore]
        public ICollection<StudentsExams> StudentsExams { get; set; }

    }
}
