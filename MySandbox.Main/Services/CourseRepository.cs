using Courses.Component.Dtos;
using Courses.Component.Services.Contracts;
using MySandbox.Main.API;
using MySandbox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.Services
{
    public class CourseRepository : ICourseApplication
    {
        private readonly ICourseRepository _courseRepository;
        public CourseRepository(ICourseRepository _courseRepository)
        {
            this._courseRepository = _courseRepository;
        }
        public async Task<Response<CursoDto>> CreateCommand(CursoDto cursoDto)
        {
            Response<CursoDto> response = new Response<CursoDto>();
            CursoDto course = await _courseRepository.CreateCourse(cursoDto);
            if (course == null)
            {
                response.setError("ups", "No se pudo guardar el curso");
                return response;
            }

            response.SetSuccess("Success!", "Se guardo el curso");
            response.Data = course;
            return response;
        }

        public async Task<Response<CursoDto>> DeleteCommand(Guid id)
        {
            Response<CursoDto> response = new Response<CursoDto>();
            CursoDto course = await _courseRepository.DeleteCourse(id);
            if (course == null)
            {
                response.setError("ups", "No se pudo eliminar el curso");
                return response;
            }

            response.SetSuccess("Success!", "Se elimino el curso");
            response.Data = course;
            return response;
        }

        public async Task<Response<List<CursoDto>>> GetAllCommands()
        {
            Response<List<CursoDto>> response = new Response<List<CursoDto>>();
            List<CursoDto> listCourse = await _courseRepository.GetAllCourses();
            if (listCourse == null)
            {
                response.setError("ups", "No se pudo obtener los datos");
                return response;
            }

            response.SetSuccess("Success!", "Aqui estan los datos");
            response.Data = listCourse;
            return response;
        }

        public async Task<Response<CursoDto>> GetCommandById(Guid id)
        {
            Response<CursoDto> response = new Response<CursoDto>();
            CursoDto course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                response.setError("ups", "No se pudo obtener los datos");
                return response;
            }

            response.SetSuccess("Success!", "Aqui estan los datos");
            response.Data = course;
            return response;
        }

        public async Task<Response<CursoDto>> UpdateCommand(CursoDto cursoDto, Guid id)
        {
            Response<CursoDto> response = new Response<CursoDto>();
            CursoDto course = await _courseRepository.UpdateCourse(cursoDto, id);
            if (course == null)
            {
                response.setError("ups", "No se pudo modificar el curso");
                return response;
            }

            response.SetSuccess("Success!", "Se modifico el curso");
            response.Data = course;
            return response;
        }
    }
}
