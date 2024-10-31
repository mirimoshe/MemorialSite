using Common.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Service
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap<DeceasdDetailesDto, DeceasdDetails>().ReverseMap();
            CreateMap<ResponseDetailsDto, ResponseDetails>().ReverseMap();
            CreateMap<StoryDetailesDto, StoryDetailes>().ReverseMap();
            CreateMap<UserDetailesDto, UserDetailes>().ReverseMap();
        }
    }
}
