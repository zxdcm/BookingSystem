using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.Commands
{
    public class EditExtraServiceCommand : ICommand<Result>
    {
        public EditedExtraServiceDto ExtraService{ get; }

        public EditExtraServiceCommand(EditedExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }

    public class EditExtraServiceCommandHandler : ICommandHandler<EditExtraServiceCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;
            
        public EditExtraServiceCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(EditExtraServiceCommand command)
        {
            var extraServiceDto = command.ExtraService;
            var extraService = await _dataContext.ExtraServices.FindAsync(extraServiceDto.ExtraServiceId);
            if (extraService == null)
                return Result.NullEntityError(nameof(ExtraService), extraServiceDto.ExtraServiceId);

            _mapper.Map(extraServiceDto, extraService);
            await _dataContext.SaveChangesAsync();

            return Result.Ok(extraService.ExtraServiceId);
        }
    }
}
