using AutoMapper;
using CommandsComponent.Domain;
using CommandsComponent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsComponent.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>()
                .ForMember(dto => dto.PlatformName, opt => opt.MapFrom(src => src.Platform.PlatformName));
            CreateMap<Command, IndividualCommandDto>()
                .ForMember(dto => dto.PlatformName, opt => opt.MapFrom(src => src.Platform.PlatformName));
            CreateMap<Platform, PlatformDto>();
            CreateMap<Platform, IndividualPlatformDto>();
        }
    }
}
