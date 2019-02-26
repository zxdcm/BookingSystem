using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.DTOs.HotelDTOs;
using MediatR;

namespace BusinessLayer.Queries.HotelQueries
{
    public class HotelDetailsQuery : IRequest<HotelDetailsDto>
    {
        public int HotelId { get; }

        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
