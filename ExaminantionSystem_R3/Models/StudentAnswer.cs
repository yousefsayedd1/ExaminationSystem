namespace ExaminantionSystem_R3.Models
{
    public class StudentAnswer : BaseModel
    {
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public int ChoiceID { get; set; }

        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }
        public Choice Choice { get; set; }
    }
}
