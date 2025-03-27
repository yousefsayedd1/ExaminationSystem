using AutoMapper;
using ExaminantionSystem_R3.DTOs.ExamQuestion;
using ExaminantionSystem_R3.DTOs.Exams;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Services;

namespace ExaminantionSystem_R3.DTOs.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, GetAllExamsDTO>().ReverseMap();
            CreateMap<Exam, GetbyidExamDTO>().ReverseMap();
            CreateMap<Exam, CreateExamDTO>().ReverseMap();
            CreateMap<Exam, CreateRandomExamDTO>().ReverseMap();
            CreateMap<Exam, GetCourseExamDTO>().ReverseMap();
            CreateMap<Exam, UpdateExamDTO>().ReverseMap();
        }
    }
}
