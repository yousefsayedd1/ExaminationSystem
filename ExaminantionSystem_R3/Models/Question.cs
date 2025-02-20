using ExaminantionSystem_R3.Models.Enums;
using System.Text.Json.Serialization;

namespace ExaminantionSystem_R3.Models
{
    public class Question : BaseModel
    {
        public string Head { get; set; }
        public QuestionLevel Level { get; set; }
        public int CourseID { get; set; }
        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public ICollection<Choice>? Choices { get; set; }
        [JsonIgnore]
        public ICollection<ExamQuestion>? ExamQuestion { get; set; }
    }
}
