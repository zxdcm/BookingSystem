using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.DTOs.HotelDTOs;
using DataAccessLayer.Entities;

namespace BusinessLayer.Utils
{
    public class MappingConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Hotel, HotelDetailsDto>().ReverseMap();
                cfg.CreateMap<Hotel, CreateHotelDto>().ReverseMap();
                cfg.CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
            });
        }
    }
}
