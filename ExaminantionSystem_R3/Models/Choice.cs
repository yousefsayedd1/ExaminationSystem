using System.Text.Json.Serialization;

namespace ExaminantionSystem_R3.Models
{
    public class Choice : BaseModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }

        [JsonIgnore]
        public Question? Question { get; set; }

    }
}
