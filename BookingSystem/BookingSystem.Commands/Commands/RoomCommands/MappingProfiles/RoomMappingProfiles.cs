using AutoMapper;
using BookingSystem.Commands.Commands.RoomCommands.DTOs;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.RoomCommands.MappingProfiles
{
    public class RoomMappingProfiles : Profile
    {
        public RoomMappingProfiles()
        {
            CreateMap<NewRoomDto, Room>();
            CreateMap<EditedRoomDto, Room>();
        }
    }
}
