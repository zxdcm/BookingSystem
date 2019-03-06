using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.HotelCommands.Commands
{
    public class EditHotelExtraServicesCommand : ICommand<Result>
    {
        public EditedHotelDto Hotel { get; }

        public EditHotelExtraServicesCommand(EditedHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
    public class EditHotelExtraServicesCommandHandler : ICommandHandler<EditHotelCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public EditHotelExtraServicesCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(EditHotelCommand command)
        {
            var hotelDto = command.Hotel;

            var hotel = await _dataContext.Hotels.FindAsync(hotelDto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), hotelDto.HotelId);

            _mapper.Map(hotelDto, hotel);

            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
