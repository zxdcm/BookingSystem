using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Commands.Common;
using BusinessLayer.DTOs.HotelDTOs;

namespace BusinessLayer.Commands.HotelCommands
{
    public class UpdateHotelCommand : BaseCommand<CommandResponse>
    {
        public UpdateHotelDto Hotel { get; }

        public UpdateHotelCommand(UpdateHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
}
