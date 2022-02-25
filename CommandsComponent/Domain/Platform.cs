using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Component.Domain
{
    public class Platform
    {
        public Guid? PlatformId { get; set; }
        public string PlatformName { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Command> Commands { get; set; }
    }
}
