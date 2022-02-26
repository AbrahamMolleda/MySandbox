using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Dtos
{
    public class CursoDto
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PrecioCompra { get; set; }
        public ICollection<InstructorDto> Instructores { get; set; }
    }
}
