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
            CommandDto commandRecibed = await _commandRepository.CreateCommand(command);
            Response<CommandDto> response = ResponseValidator<CommandDto>.ValidateData(
                commandRecibed,
                "Se creo el comando",
                "No se pudo crear el comando"
                );
            return response;
        }

        public async Task<Response<CommandDto>> DeleteCommand(Guid id)
        {
            CommandDto commandDeleted = await _commandRepository.DeleteCommand(id);
            Response<CommandDto> response = ResponseValidator<CommandDto>.ValidateData(
                commandDeleted,
                "Se borro el comando",
                "No se pudo borrar el comando"
                );
            return response;
        }

        public async Task<Response<List<CommandDto>>> GetAllCommands()
        {
            List<CommandDto> commandsList = await _commandRepository.GetAllCommands();
            Response<List<CommandDto>> response = ResponseValidator<List<CommandDto>>.ValidateData(
                commandsList,
                "Aqui esta la lista de comandos",
                "No se pudo obtener la lista de comandos"
                );
            return response;
        }


        public async Task<Response<IndividualCommandDto>> GetCommandById(Guid id)
        {
            IndividualCommandDto commandFound = await _commandRepository.GetCommandById(id);
            Response<IndividualCommandDto> response = ResponseValidator<IndividualCommandDto>.ValidateData(
                commandFound,
                "Aqui esta el comando",
                "No se pudo obtener el comando"
                );
            return response;
        }

        public async Task<Response<CommandDto>> UpdateCommand(CommandDto command, Guid id)
        {
            CommandDto commandFound = await _commandRepository.UpdateCommand(command, id);
            Response<CommandDto> response = ResponseValidator<CommandDto>.ValidateData(
                commandFound,
                "Aqui esta el comando",
                "No se pudo obtener el comando"
                );
            return response;
        }
    }
}
