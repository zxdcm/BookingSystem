using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;

namespace BookingSystem.Commands.RoomCommands
{
    public class AddRoomCommand : ICommand<Task<Result>>
    {
    }
}
