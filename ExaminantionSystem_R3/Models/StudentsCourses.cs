using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminantionSystem_R3.Models
{
    public class StudentsCourses : BaseModel
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CouresID { get; set; }
        public Course Course { get; set; }
        public decimal Grade { get; set; }
    }
}
