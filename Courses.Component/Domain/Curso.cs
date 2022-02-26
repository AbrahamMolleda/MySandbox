using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Domain
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Precio Precio { get; set; }
        public ICollection<Comentario> ComentarioLista { get; set; }
        public ICollection<CursoInstructor> InstructoresLink { get; set; }
    }
}
