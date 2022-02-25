using AutoMapper;
using Commands.Component.Domain;
using Commands.Component.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Component.Profiles
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
