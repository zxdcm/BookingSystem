using AutoMapper;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.MappingProfiles
{
    public class ExtraServiceMappingProfile : Profile
    {
        public ExtraServiceMappingProfile()
        {
            CreateMap<NewExtraServiceDto, ExtraService>();
            CreateMap<EditedExtraServiceDto, ExtraService>();
        }
    }
}
