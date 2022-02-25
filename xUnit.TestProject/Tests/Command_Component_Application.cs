using AutoMapper;
using Commands.Component.Dtos;
using Commands.Component.Persistence;
using Commands.Component.Profiles;
using Commands.Component.Services;
using Commands.Component.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySandbox.Main.API;
using MySandbox.Main.Services;
using MySandbox.Main.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using xUnit.TestProject.Fixture;
using Xunit;

namespace xUnit.TestProject.Tests
{
    public class Command_Component_Application : IClassFixture<FixtureService>
    {
        private readonly ICommandApplication _commandApplication;
        private readonly IPlatformApplication _platformApplication;
        public Command_Component_Application(FixtureService fixture)
        {
            // 1) Inicilizamos DI
            ServiceCollection services = fixture.ServiceProvidersForTestPropouses();

            // 2) Inyectamos todos los servicios que queramos probar 
            services.AddDbContext<CommandsContext>(opt =>
            {
                opt.UseSqlServer(fixture.Configuration.GetSection("ConnectionStrings:SqlServer").Value);
            });

            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<ICommandApplication, CommandApplication>();
            services.AddTransient<IPlatformApplication, PlatformApplication>();
            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommandsProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // 4) Construimos 
            ServiceProvider serviceProvider = fixture.BuildServices();

            // 5) Obtenemos referencias para usarlas de DI 
            _commandApplication = serviceProvider.GetService<ICommandApplication>();
            _platformApplication = serviceProvider.GetService<IPlatformApplication>();
        }

        [Fact]
        public async void GetAllCommands()
        {
            // Arrange  
            Response<List<CommandDto>> response = new Response<List<CommandDto>>();
            // Act
            response = await _commandApplication.GetAllCommands();

            // Assert
            Assert.NotNull(response.Data);
        }
    }
}
