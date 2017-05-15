using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Adly.Dtos;
using Adly.Models;

namespace Adly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // To DTO
            Mapper.CreateMap<Advertisement, AdvertisementDto>();

            // To Domain
            Mapper.CreateMap<AdvertisementDto, Advertisement>();
            Mapper.CreateMap<AdvertisementDto, Advertisement>().ForMember(a => a.Id, opt => opt.Ignore());
            Mapper.CreateMap<AdvertisementDto, Advertisement>().ForMember(a => a.Date, opt => opt.Ignore());
            Mapper.CreateMap<AdvertisementDto, Advertisement>().ForMember(a => a.Views, opt => opt.Ignore());
        }
    }
}