using System.Text.Json.Serialization;

namespace ExaminantionSystem_R3.Models
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        
        [JsonIgnore]
        public ICollection<StudentsCourses> StudentsCourses { get; set; }
        [JsonIgnore]
        public ICollection<StudentsExams> StudentsExams { get; set; }
    }
}
