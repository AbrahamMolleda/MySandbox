using AutoMapper;
using Commands.Component.Domain;
using Commands.Component.Dtos;
using Commands.Component.Persistence;
using Commands.Component.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commands.Component.Services
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommandsContext _context;
        private readonly IMapper _mapper;
        public CommandRepository(CommandsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommandDto> CreateCommand(CommandDto command)
        {
            if (command == null)
                return null;

            var platform = await _context.Platform.FirstOrDefaultAsync(p => p.PlatformName == command.PlatformName);

            var commandToCreate = new Command()
            {
                CommandId = Guid.NewGuid(),
                HowTo = command.HowTo,
                Line = command.Line,
                PlatformId = platform.PlatformId
            };

            await _context.Command.AddAsync(commandToCreate);
            await _context.SaveChangesAsync();
            var commandDto = _mapper.Map<Command, CommandDto>(commandToCreate);
            return commandDto;

        }

        public async Task<IndividualCommandDto> GetCommandById(Guid id)
        {

            var command = await _context.Command
                .Include(x => x.Platform)
                .FirstOrDefaultAsync(c => c.CommandId == id);

            if (command == null)
                return null;

            var commandDto = _mapper.Map<Command, IndividualCommandDto>(command);

            return commandDto;

        }

        public async Task<List<CommandDto>> GetAllCommands()
        {
            var commands = await _context.Command
                .Include(x => x.Platform)
                .ToListAsync();

            if (commands == null)
                return null;

            var commandDtos = _mapper.Map<List<Command>, List<CommandDto>>(commands);

            return commandDtos;

        }

        public async Task<CommandDto> DeleteCommand(Guid id)
        {
            var command = await _context.Command.FindAsync(id);

            if (command == null)
                return null;

            _context.Remove(command);
            await _context.SaveChangesAsync();
            var commandDto = _mapper.Map<Command, CommandDto>(command);
            return commandDto;
        }

        public async Task<CommandDto> UpdateCommand(CommandDto command, Guid id)
        {
            var commandFound = await _context.Command.FindAsync(id);
            if (commandFound == null) return null;

            var platform = await _context.Platform.FirstOrDefaultAsync(p => p.PlatformName == command.PlatformName);

            commandFound.HowTo = command.HowTo ?? commandFound.HowTo;
            commandFound.Line = command.Line ?? commandFound.Line;
            commandFound.PlatformId = platform.PlatformId ?? commandFound.PlatformId;

            await _context.SaveChangesAsync();

            var commandDto = _mapper.Map<Command, CommandDto>(commandFound);
            return commandDto;
        }

        public async Task<List<PlatformDto>> GetAllCommandsByPlatform()
        {
            var platforms = await _context.Platform
                .Include(x => x.Commands)
                .ToListAsync();

            var platformsDtos = _mapper.Map<List<Platform>, List<PlatformDto>>(platforms);
            return platformsDtos;
        }

        public async Task<IndividualPlatformDto> GetAllCommandsForOnePlatfom(Guid id)
        {
            var platform = await _context.Platform
                .Include(x => x.Commands)
                .FirstOrDefaultAsync(p => p.PlatformId == id);

            if (platform == null)
                return null;

            var platformDto = _mapper.Map<Platform, IndividualPlatformDto>(platform);

            return platformDto;
        }
    }
}
