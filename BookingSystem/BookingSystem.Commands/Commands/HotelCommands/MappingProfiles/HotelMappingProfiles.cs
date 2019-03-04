using System.Linq;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.HotelCommands.MappingProfiles
{
    public class HotelMappingProfiles : Profile
    {
        public HotelMappingProfiles()
        {
            CreateMap<NewHotelDto, Hotel>();
            CreateMap<EditedHotelDto, Hotel>()
                .ForMember(h => h.ExtraServices, ext => ext.MapFrom(
                    dto => dto.ExtraServices.Select(service => new ExtraService()
                    {
                        HotelId = dto.HotelId,
                        ExtraServiceId = service.ExtraServiceId
                    })));
        }
    }
}
