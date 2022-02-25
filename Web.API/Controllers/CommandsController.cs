using Commands.Component.Domain;
using Commands.Component.Dtos;
using Microsoft.AspNetCore.Mvc;
using MySandbox.Main.API;
using MySandbox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApplication _application;
        public CommandsController(ICommandApplication application)
        {
            _application = application;
        }
        
        [HttpGet]
        public async Task<ActionResult<Response<List<CommandDto>>>> GetAllCommands()
        {
            return Ok(await _application.GetAllCommands());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<IndividualCommandDto>>> GetCommandById(Guid id)
        {
            return Ok(await _application.GetCommandById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response<CommandDto>>> CreateCommand(CommandDto command)
        {
            return Ok(await _application.CreateCommand(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<CommandDto>>> UpdateCommand(CommandDto command, Guid id)
        {
            return Ok(await _application.UpdateCommand(command, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<CommandDto>>> DeleteCommand(Guid id)
        {
            return Ok(await _application.DeleteCommand(id));
        }

        

    }
}
