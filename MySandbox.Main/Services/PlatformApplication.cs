using CommandsComponent.Dtos;
using CommandsComponent.Services.Contracts;
using MySandbox.Main.API;
using MySandbox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.Services
{
    public class PlatformApplication : IPlatformApplication
    {
        private readonly ICommandRepository _commandRepository;
        public PlatformApplication(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public async Task<Response<List<PlatformDto>>> GetAllPlatformsWithCommands()
        {
            Response<List<PlatformDto>> response = new Response<List<PlatformDto>>();
            List<PlatformDto> listPlatformDtos = await _commandRepository.GetAllCommandsByPlatform();
            if (listPlatformDtos == null)
            {
                response.setError("ups", "No se pudo obtener la data");
                return response;
            }
            response.SetSuccess("Success!", "Aqui esta la data");
            response.Data = listPlatformDtos;
            return response;
        }

        public async Task<Response<IndividualPlatformDto>> GetPlatformWithCommands(Guid id)
        {
            Response<IndividualPlatformDto> response = new Response<IndividualPlatformDto>();
            IndividualPlatformDto platformDto = await _commandRepository.GetAllCommandsForOnePlatfom(id);
            if(platformDto == null)
            {
                response.setError("ups", "No se pudo obtener la data");
                return response;
            }
            response.SetSuccess("Success!", "Aqui esta la data");
            response.Data = platformDto;
            return response;
        }
    }
}
