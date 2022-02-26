using AutoMapper;
using Courses.Component.Domain;
using Courses.Component.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Curso, CursoDto>()
                .ForMember(dto => dto.Instructores, opt => opt.MapFrom(src => src.InstructoresLink.Select(ins => ins.Instructor).ToList()));
            CreateMap<CursoInstructor, CursoInstructorDto>();
            CreateMap<Instructor, InstructorDto>();
        }
    }
}
