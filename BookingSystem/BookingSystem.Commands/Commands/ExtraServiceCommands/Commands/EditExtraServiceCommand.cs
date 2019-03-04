using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.Commands
{
    public class EditExtraServiceCommand : ICommand<Result>, ICommand<Task<Result>>
    {
        public EditedExtraServiceDto ExtraService{ get; }

        public EditExtraServiceCommand(EditedExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }

    public class EditExtraServiceCommandHandler : ICommandHandler<EditExtraServiceCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;
            
        public EditExtraServiceCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(EditExtraServiceCommand command)
        {
            var dto = command.ExtraService;
            var hotel = await _dataContext.Hotels.FindAsync(dto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), dto.HotelId);

            _mapper.Map(dto, hotel);
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
