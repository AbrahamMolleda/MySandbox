﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Domain
{
    public class Precio
    {
        public Guid PrecioId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioCompra { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
