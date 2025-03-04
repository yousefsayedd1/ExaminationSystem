using AutoMapper;
using ExaminantionSystem_R3.DTOs.Questions;
using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, AddQuestionDTO>().ReverseMap();
            CreateMap<Question, GetQuestionDTO>().ReverseMap();
            CreateMap<Question, GetQuestionWithChoicesDTO>().ReverseMap();
            CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
         

        }
    }
}
