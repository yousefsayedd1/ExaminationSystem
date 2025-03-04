using AutoMapper;
using ExaminantionSystem_R3.DTOs.Choices;
using ExaminantionSystem_R3.Models;

namespace ExaminantionSystem_R3.DTOs.Profiles
{
    public class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            CreateMap<Choice, AddChoiceDTO>().ReverseMap();
            CreateMap<Choice, GetAllChoicesDTO>().ReverseMap();
            CreateMap<Choice, GetByIdChoiceDTO>().ReverseMap();
            CreateMap<Choice, UpdateChoiceDTO>().ReverseMap();
        }
    }
}
