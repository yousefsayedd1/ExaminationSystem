﻿using ExaminantionSystem_R3.Models.Enums;

namespace ExaminantionSystem_R3.Services
{
    public class UpdateExamDTO
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public ExamType Type { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }


    }
}