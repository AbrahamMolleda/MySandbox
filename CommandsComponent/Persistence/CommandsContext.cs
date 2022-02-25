using Commands.Component.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Component.Persistence
{
    public class CommandsContext : DbContext
    {
        public CommandsContext(DbContextOptions<CommandsContext> options) : base(options)
        {

        }

        public DbSet<Command> Command { get; set; }
        public DbSet<Platform> Platform { get; set; }
    }
}
