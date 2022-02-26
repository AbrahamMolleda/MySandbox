using Courses.Component.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Component.Persistence
{
    public class CursosContext : DbContext
    {
        public CursosContext(DbContextOptions<CursosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new { ci.InstructorId, ci.CursoId });
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
    }
}
