using Commands.Component.Dtos;
using Commands.Component.Services.Contracts;
using MySandbox.Main.API;
using MySandbox.Main.Helpers;
using MySandbox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySandbox.Main.Services
{
    public class CommandApplication : ICommandApplication
    {
        private readonly ICommandRepository _commandRepository;
        public CommandApplication(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Response<CommandDto>> CreateCommand(CommandDto command)
        {
            Response<CommandDto> response = new Response<CommandDto>();
            CommandDto commandRecibed = await _commandRepository.CreateCommand(command);
            if (commandRecibed == null)
            {
                response.setError("ups", "No se pudo guardar el comando");
                return response;
            }

            response.SetSuccess("Success!", "Se guardo el comando");
            response.Data = commandRecibed;
            return response;
        }

        public async Task<Response<CommandDto>> DeleteCommand(Guid id)
        {
            Response<CommandDto> response = new Response<CommandDto>();
            CommandDto commandDeleted = await _commandRepository.DeleteCommand(id);
            if (commandDeleted == null)
            {
                response.setError("ups", "No se pudo eliminar el comando");
                return response;
            }

            response.SetSuccess("Success!", "Se elimino el comando");
            response.Data = commandDeleted;
            return response;
        }

        public async Task<Response<List<CommandDto>>> GetAllCommands()
        {
            //Response<List<CommandDto>> response = new Response<List<CommandDto>>();
            List<CommandDto> commandsList = await _commandRepository.GetAllCommands();
            Response<List<CommandDto>> response = ResponseValidator<List<CommandDto>>.ValidateData(
                commandsList, 
                "Aqui esta la lista de comandos", 
                "No se pudo obtener la lista de comandos"
                );
            /*if (commandsList == null)
            {
                response.setError("ups", "No se pudo obtener la lista de comandos");
                return response;
            }
            response.SetSuccess("Success!", "Aqui esta la lista de comandos");
            response.Data = commandsList;
            */
            return response;
        }


        public async Task<Response<IndividualCommandDto>> GetCommandById(Guid id)
        {
            Response<IndividualCommandDto> response = new Response<IndividualCommandDto>();
            IndividualCommandDto commandFound = await _commandRepository.GetCommandById(id);
            if (commandFound == null)
            {
                response.setError("ups", "No se pudo obtener el comando");
                return response;
            }
            response.SetSuccess("Success!", "Aqui esta el comando");
            response.Data = commandFound;
            return response;
        }

        public async Task<Response<CommandDto>> UpdateCommand(CommandDto command, Guid id)
        {
            Response<CommandDto> response = new Response<CommandDto>();
            CommandDto commandFound = await _commandRepository.UpdateCommand(command, id);
            if (commandFound == null)
            {
                response.setError("ups", "No se pudo actualizar el comando");
                return response;
            }
            response.SetSuccess("Success!", "Aqui esta el comando actualizado");
            response.Data = commandFound;
            return response;
        }
    }
}
