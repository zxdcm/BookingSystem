using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Commands.Common;
using DataAccessLayer.Entities;
using MediatR;

namespace BusinessLayer.Commands.HotelCommands
{
    public class CreateHotelCommandHandler : AsyncRequestHandler<CreateHotelCommand>
    { 
        private readonly BookingContext _dataContext;

        public CreateHotelCommandHandler(BookingContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected override async Task Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Hotel;
            var hotel = Mapper.Map<Hotel>(dto);
            await _dataContext.Hotels.AddAsync(hotel, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
