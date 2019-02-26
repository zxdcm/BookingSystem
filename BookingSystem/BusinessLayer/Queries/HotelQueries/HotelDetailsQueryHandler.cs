using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using BusinessLayer.Commands.HotelCommands;
using BusinessLayer.DTOs.HotelDTOs;
using BusinessLayer.Exceptions;
using BusinessLayer.Specification;
using DataAccessLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Queries.HotelQueries
{
    public class HotelDetailsQueryHandler : IRequestHandler<HotelDetailsQuery, HotelDetailsDto>
    {
        private readonly BookingContext _dataContext;

        public HotelDetailsQueryHandler(BookingContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HotelDetailsDto> Handle(HotelDetailsQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _dataContext.Hotels
                .GetQuery(new HotelDetailsSpecification(request.HotelId))
                .FirstOrDefaultAsync(cancellationToken);

            Guard.Against.NullHotel(hotel, request.HotelId);

            return Mapper.Map<HotelDetailsDto>(hotel);
        }
    }
}
