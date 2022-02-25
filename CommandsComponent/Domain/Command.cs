using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsComponent.Domain
{
    public class Command
    {
        public Guid CommandId { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public Guid? PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
