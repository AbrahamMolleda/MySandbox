using Courses.Component.Dtos;
using MySandbox.Main.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.Services.Contracts
{
    public interface ICourseApplication
    {
        Task<Response<CursoDto>> CreateCommand(CursoDto cursoDto);
        Task<Response<List<CursoDto>>> GetAllCommands();
        Task<Response<CursoDto>> GetCommandById(Guid id);
        Task<Response<CursoDto>> UpdateCommand(CursoDto cursoDto, Guid id);
        Task<Response<CursoDto>> DeleteCommand(Guid id);
    }
}
