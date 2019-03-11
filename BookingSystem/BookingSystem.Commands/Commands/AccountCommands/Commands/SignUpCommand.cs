using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.AccountCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Commands.Properties;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookingSystem.Commands.Commands.AccountCommands.Commands
{
    public class SignUpCommand : ICommand<Result>
    {
        public SignUpDto User { get; }

        public SignUpCommand(SignUpDto user)
        {
            User = user;
        }
    }

    public class SignUpCommandHandler : ICommandHandler<SignUpCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IPasswordHasher _hasher;
        private readonly IMapper _mapper;

        public SignUpCommandHandler(BookingWriteContext dataContext, 
            IPasswordHasher hasher, 
            IMapper mapper)
        {
            _dataContext = dataContext;
            _hasher = hasher;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(SignUpCommand command)
        {
            var userDto = command.User;

            var userExist = await _dataContext.Users.AnyAsync(u => u.Email == userDto.Email);
            if (userExist)
                return Result.Error(string.Format(ErrorsResources.UserAlreadyExist, userDto.Email));

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = _hasher.HashPassword(userDto.Password);
            _dataContext.Users.Add(user);

            await _dataContext.SaveChangesAsync();
            return Result.Ok(user.UserId);
        }
    }
}
