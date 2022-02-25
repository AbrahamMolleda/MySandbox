using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsComponent.Dtos
{
    public class CommandDto
    {
        public Guid? CommandId { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PlatformName { get; set; }
    }
}
