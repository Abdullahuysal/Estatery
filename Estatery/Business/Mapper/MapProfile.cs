using AutoMapper;
using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<House, HouseResponse>();
            CreateMap<HouseRequest, House>();
            CreateMap<HouseUpdateRequest, House>();
            CreateMap<Land, LandResponse>();
            CreateMap<LandUpdateRequest, Land>();
        }
    }
}
