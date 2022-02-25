using AutoMapper;
using Commands.Component.Persistence;
using Commands.Component.Profiles;
using Commands.Component.Services;
using Commands.Component.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySandbox.Main.Services;
using MySandbox.Main.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1) Leemos configuraciones +  Iniciamos DI   
            IConfigurationBuilder config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables();
            IConfigurationRoot configurationRoot = config.Build();

            // 3) Configure Profile Mappings

            MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommandsProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            // 2) Inyectamos todos los servicios que queramos usar

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configurationRoot)
                .AddDbContext<CommandsContext>(opt =>
                {
                    opt.UseSqlServer(configurationRoot.GetSection("ConnectionStrings:SqlServer").Value);
                })
                .AddTransient<ICommandRepository, CommandRepository>()
                .AddTransient<ICommandApplication, CommandApplication>()
                .AddTransient<IPlatformApplication, PlatformApplication>()
                // Automapper
                .AddSingleton(mapper)
                .AddLogging()
                .BuildServiceProvider();

            // 4) Application toDo
            ICommandApplication application = serviceProvider.GetService<ICommandApplication>();
            var data = await application.GetAllCommands();

            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}
