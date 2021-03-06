﻿using System.Threading.Tasks;

namespace BookingSystem.Common.Interfaces
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}
