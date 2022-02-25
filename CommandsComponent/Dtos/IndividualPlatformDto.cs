using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Component.Dtos
{
    public class IndividualPlatformDto
    {
        public string PlatformName { get; set; }
        public ICollection<CommandDto> Commands { get; set; }
    }
}
