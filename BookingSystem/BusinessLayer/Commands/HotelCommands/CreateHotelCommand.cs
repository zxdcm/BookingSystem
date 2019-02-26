using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Commands.Common;
using BusinessLayer.DTOs.HotelDTOs;

namespace BusinessLayer.Commands.HotelCommands
{
    public class CreateHotelCommand : BaseCommand<CommandResponse>
    {
        public CreateHotelDto Hotel { get; }

        public CreateHotelCommand(CreateHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
}
