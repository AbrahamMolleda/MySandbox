using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Domain
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ICollection<CursoInstructor> CursoLink { get; set; }
    }
}
