using System.Linq;
using AutoMapper;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.BookingCommands.MappingProfiles
{
    public class BookingMappingProfiles : Profile
    {
        public BookingMappingProfiles()
        {
            CreateMap<NewBookingDto, Booking>();
            CreateMap<CompleteBookingDto, Booking>()
                    .ForMember(b => b.BookingExtraServices, 
                               conf => conf.MapFrom(dto => dto.ExtraServicesIds
                               .Select(id => new BookingExtraService()
                               {
                                   ExtraServiceId = id,
                                   BookingId = dto.BookingId
                               })));
        }
    }
}
