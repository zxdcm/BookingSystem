using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookingSystem.Commands.Commands.AccountCommands.DTOs;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.AccountCommands.MappingProfiles
{
    public class AccountMappingProfiles : Profile
    {
        public AccountMappingProfiles()
        {
            CreateMap<SignUpDto, User>()
                .ForSourceMember(u => u.Password, cfg => cfg.DoNotValidate());
        }
    }
}
