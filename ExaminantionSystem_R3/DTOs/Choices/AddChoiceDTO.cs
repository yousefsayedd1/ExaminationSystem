namespace ExaminantionSystem_R3.DTOs.Choices
{
    public class AddChoiceDTO
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
    }
}