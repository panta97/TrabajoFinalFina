using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cashflow.Dtos;
using Cashflow.Models;

namespace Cashflow.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Flujo, FlujoDto>();
            Mapper.CreateMap<FlujoDto, Flujo>();

            Mapper.CreateMap<Periodo, PeriodoDto>();
            Mapper.CreateMap<PeriodoDto, Periodo>();
        }
    }
}