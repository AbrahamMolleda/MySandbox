using Courses.Component.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Services.Contracts
{
    public interface ICourseRepository
    {
        Task<List<CursoDto>> GetAllCourses();
        Task<CursoDto> GetCourseById(Guid id);
        Task<CursoDto> CreateCourse(CursoDto cursoDto);
        Task<CursoDto> UpdateCourse(CursoDto cursoDto, Guid id);
        Task<CursoDto> DeleteCourse(Guid id);


    }
}
