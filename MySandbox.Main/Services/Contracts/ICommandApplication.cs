using Commands.Component.Dtos;
using MySandbox.Main.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySandbox.Main.Services.Contracts
{
    public interface ICommandApplication
    {
        Task<Response<CommandDto>> CreateCommand(CommandDto command);
        Task<Response<List<CommandDto>>> GetAllCommands();
        Task<Response<IndividualCommandDto>> GetCommandById(Guid id);
        Task<Response<CommandDto>> UpdateCommand(CommandDto command, Guid id);
        Task<Response<CommandDto>> DeleteCommand(Guid id);
    }
}
