using Commands.Component.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commands.Component.Services.Contracts
{
    public interface ICommandRepository
    {
        Task<IndividualCommandDto> GetCommandById(Guid id);
        Task<List<CommandDto>> GetAllCommands();
        Task<CommandDto> CreateCommand(CommandDto command);
        Task<CommandDto> UpdateCommand(CommandDto command, Guid id);
        Task<CommandDto> DeleteCommand(Guid id);
        Task<List<PlatformDto>> GetAllCommandsByPlatform();
        Task<IndividualPlatformDto> GetAllCommandsForOnePlatfom(Guid id);
    }
}
