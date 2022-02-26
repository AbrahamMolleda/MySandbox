using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Dtos
{
    public class CursoInstructorDto
    {
        public Guid CursoId { get; set; }
        public Guid InstructorId { get; set; }
    }
}
