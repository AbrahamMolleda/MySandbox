using AutoMapper;
using Courses.Component.Domain;
using Courses.Component.Dtos;
using Courses.Component.Persistence;
using Courses.Component.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CursosContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(CursosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<CursoDto> DeleteCourse(Guid id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null) return null;

            var precio = await _context.Precio.Select(p => p.CursoId == id).FirstOrDefaultAsync();
            var cursoInstructor = await _context.CursoInstructor.Select(ci => ci.CursoId).ToListAsync();

            _context.Remove(precio);
            _context.Remove(cursoInstructor);
            _context.Remove(curso);

            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                var cursoborrado = _mapper.Map<Curso, CursoDto>(curso);
                return cursoborrado;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<CursoDto>> GetAllCourses()
        {
            var cursos = await _context.Curso
                    .Include(x => x.InstructoresLink)
                    .ThenInclude(x => x.Instructor)
                    .ToListAsync();

            if (cursos == null)
                return null;

            var cursosDto = _mapper.Map<List<Curso>, List<CursoDto>>(cursos);
            return cursosDto;
        }

        public async Task<CursoDto> GetCourseById(Guid id)
        {
            var curso = await _context.Curso
                .Include(x => x.InstructoresLink)
                .ThenInclude(x => x.Instructor)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null)
                return null;

            var cursoDto = _mapper.Map<Curso, CursoDto>(curso);
            return cursoDto;
        }

        public async Task<CursoDto> UpdateCourse(CursoDto cursoDto, Guid id)
        {
            var curso = await _context.Curso
                .Include(x => x.InstructoresLink)
                .ThenInclude(x => x.Instructor)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null)
                return null;

            curso.Titulo = cursoDto.Titulo ?? curso.Titulo;
            curso.Descripcion = cursoDto.Descripcion ?? curso.Descripcion;

            if (cursoDto.PrecioCompra != null)
            {
                var precio = await _context.Precio.FirstOrDefaultAsync(c => c.CursoId == id);
                precio.PrecioCompra = cursoDto.PrecioCompra ?? precio.PrecioCompra;
            }


            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                var cursoSaved = await _context.Curso
                    .Include(x => x.InstructoresLink)
                    .ThenInclude(x => x.Instructor)
                    .FirstOrDefaultAsync(c => c.CursoId == id);

                var cursoSavedDto = _mapper.Map<Curso, CursoDto>(cursoSaved);
                return cursoSavedDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<CursoDto> CreateCourse(CursoDto cursoDto)
        {
            var _cursoId = Guid.NewGuid();
            var curso = new Curso
            {
                CursoId = _cursoId,
                Titulo = cursoDto.Titulo,
                Descripcion = cursoDto.Descripcion
            };
            await _context.Curso.AddAsync(curso);

            var precio = new Precio
            {
                CursoId = _cursoId,
                PrecioCompra = cursoDto.PrecioCompra ?? 0
            };

            if (cursoDto.Instructores != null)
            {
                foreach (var instructor in cursoDto.Instructores)
                {
                    var cursoInstructor = new CursoInstructor
                    {
                        CursoId = _cursoId,
                        InstructorId = instructor.InstructorId
                    };
                    await _context.CursoInstructor.AddAsync(cursoInstructor);
                }
            }

            var resultado = await _context.SaveChangesAsync();


            if (resultado > 0)
            {
                var cursoSaved = await _context.Curso
                    .Include(x => x.InstructoresLink)
                    .ThenInclude(x => x.Instructor)
                    .FirstOrDefaultAsync(c => c.CursoId == _cursoId);

                var cursoSavedDto = _mapper.Map<Curso, CursoDto>(cursoSaved);
                return cursoSavedDto;
            }
            else
            {
                return null;
            }

        }
    }
}
