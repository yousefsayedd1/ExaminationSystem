using AutoMapper;
using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, AddQuestionDTO>().ReverseMap();
        }
    }
}
