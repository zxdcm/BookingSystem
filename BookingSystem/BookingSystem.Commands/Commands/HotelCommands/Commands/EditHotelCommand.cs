using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.HotelCommands.Commands
{
    public class EditHotelCommand : ICommand<Task<Result>>
    {
        public EditedHotelDto Hotel { get; }

        public EditHotelCommand(EditedHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
    public class EditHotelCommandHandler : ICommandHandler<EditHotelCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public EditHotelCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(EditHotelCommand command)
        {
            var dto = command.Hotel;

            var hotel = await _dataContext.Hotels.FindAsync(dto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), dto.HotelId);

            _mapper.Map(dto, hotel);
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
