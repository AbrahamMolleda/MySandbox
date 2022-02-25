using CommandsComponent.Dtos;
using MySandbox.Main.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.Services.Contracts
{
    public interface IPlatformApplication
    {
        Task<Response<List<PlatformDto>>> GetAllPlatformsWithCommands();
        Task<Response<IndividualPlatformDto>> GetPlatformWithCommands(Guid id);
    }
}
