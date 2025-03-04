using AutoMapper;
using ExaminantionSystem_R3.DTOs.Coureses;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Services;

namespace ExaminantionSystem_R3.DTOs.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, GetCourseDTO>().ReverseMap();
            CreateMap<Course, AddCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
        }
    }
}
