using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using BusinessLayer.Commands.Common;
using BusinessLayer.Exceptions;
using DataAccessLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Commands.HotelCommands
{
    //ICommandHandler<UpdateHotelCommand, Task>
    public class UpdateHotelCommandHandler : AsyncRequestHandler<UpdateHotelCommand>
    {
        private readonly BookingContext _dataContext;

        public UpdateHotelCommandHandler(BookingContext dataContext)
        { 
            _dataContext = dataContext;
        }

        protected override async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Hotel;
            var hotel = await _dataContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == dto.HotelId, cancellationToken);
            Guard.Against.NullHotel(hotel, dto.HotelId);
            Mapper.Map(dto, hotel);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }

}
