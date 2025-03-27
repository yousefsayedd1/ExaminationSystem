using AutoMapper;
using ExaminantionSystem_R3.DTOs.StudentsExams;

namespace ExaminantionSystem_R3.DTOs.Profiles
{
    public class StudentsExamsProfile : Profile
    {
        public StudentsExamsProfile()
        {
            CreateMap<Models.StudentsExams, AddStudentsExamsDTO>().ReverseMap();
        }
    }
}
