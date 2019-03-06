using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.Commands
{
    public class AddExtraServiceCommand : ICommand<Result>
    {
        public NewExtraServiceDto ExtraService { get; }

        public AddExtraServiceCommand(NewExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }

    public class AddExtraServiceCommandHandler : ICommandHandler<AddExtraServiceCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public AddExtraServiceCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(AddExtraServiceCommand command)
        {
            var extraServiceDto = command.ExtraService;

            var hotel = await _dataContext.Hotels.FindAsync(extraServiceDto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), extraServiceDto.HotelId);

            var extraService = _mapper.Map<ExtraService>(extraServiceDto);
            _dataContext.ExtraServices.Add(extraService);
            await _dataContext.SaveChangesAsync();

            return Result.Ok(extraService.ExtraServiceId);
        }
    }
}
