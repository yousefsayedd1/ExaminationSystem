
using System.Text.Json.Serialization;

namespace ExaminantionSystem_R3.Models
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        [JsonIgnore]
        public ICollection<Question>? questions { get; set; }
        [JsonIgnore]
        public ICollection<Exam>? Exams { get; set; }
        [JsonIgnore]
        public ICollection<StudentsCourses>? StudentsCourses { get; set; }

    }
}
