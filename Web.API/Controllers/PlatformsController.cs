using CommandsComponent.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySandbox.Main.API;
using MySandbox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformApplication _application;
        public PlatformsController(IPlatformApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<PlatformDto>>>> GetAllPlatformsWithCommands()
        {
            return Ok(await _application.GetAllPlatformsWithCommands());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<List<PlatformDto>>>> GetAllPlatformsWithCommands(Guid id)
        {
            return Ok(await _application.GetPlatformWithCommands(id));
        }
    }
}
