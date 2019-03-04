using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.Commands
{
    public class AddExtraServiceCommand : ICommand<Task<Result>>
    {
        public NewExtraServiceDto ExtraService { get; }

        public AddExtraServiceCommand(NewExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }

    public class AddExtraServiceCommandHandler : ICommandHandler<AddExtraServiceCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public AddExtraServiceCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(AddExtraServiceCommand command)
        {
            var dto = command.ExtraService;
            var hotel = await _dataContext.Hotels.FindAsync(dto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), dto.HotelId);

            var extraService = _mapper.Map<ExtraService>(dto);
            await _dataContext.ExtraServices.AddAsync(extraService);
            return Result.Ok();
        }
    }
}
