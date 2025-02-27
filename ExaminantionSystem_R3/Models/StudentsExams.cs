using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminantionSystem_R3.Models
{
    public class StudentsExams : BaseModel
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Exam")]
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
        public decimal Grade { get; set; }

    }
}
