using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Domain
{
    public class Comentario
    {
        public Guid ComentarioId { get; set; }
        public string ComentarioLista { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
