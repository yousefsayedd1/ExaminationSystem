namespace ExaminantionSystem_R3.DTOs.Choices
{
    public class GetAllChoicesDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
    }
}