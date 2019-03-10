using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.AccountCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Commands.Properties;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.AccountCommands.Commands
{
    public class SignInCommand : ICommand<Result>
    {
        public SignInDto User { get; }

        public SignInCommand(SignInDto user)
        {
            User = user;
        }
    }

    public class SignInCommandHandler : ICommandHandler<SignInCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IPasswordHasher _hasher;

        public SignInCommandHandler(BookingWriteContext dataContext, IPasswordHasher hasher)
        {
            _dataContext = dataContext;
            _hasher = hasher;
        }

        public async Task<Result> ExecuteAsync(SignInCommand command)
        {
            var userDto = command.User;

            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null)
                return Result.Error(string.Format(ErrorsResources.UserNotFound, userDto.Email));

            if (_hasher.VerifyPassword(user.PasswordHash, userDto.Password))
            {
                return Result.Ok(user.UserId);
            }

            return Result.Error(ErrorsResources.InvalidPassword);
        }
    }
}
