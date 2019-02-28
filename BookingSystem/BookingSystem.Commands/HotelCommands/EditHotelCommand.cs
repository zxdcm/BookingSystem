using System;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.DTOs.HotelDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.HotelCommands
{
    public class EditHotelCommand : BaseCommand<EditedHotelDto>, ICommand<Task<Result>>
    {
        public EditedHotelDto Hotel { get; }

        public EditHotelCommand(EditedHotelDto hotel)
        {
            Hotel = hotel;
        }

        internal sealed class EditHotelCommandHandler : ICommandHandler<EditHotelCommand, Task<Result>>
        {
            private readonly BookingWriteContext _dataContext;

            public EditHotelCommandHandler(BookingWriteContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result> ExecuteAsync(EditHotelCommand command)
            {
                var dto = command.Hotel;
                var hotel = await _dataContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == dto.HotelId);
                //Guard.Against.NullHotel(hotel, dto.HotelId);
                Mapper.Map(dto, hotel);
                throw new NotImplementedException();
                //return new Result<>().Ok();
            }
        }
    }
}
