using CommandsComponent.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsComponent.Persistence
{
    public class DataPrueba
    {
        public static async Task InsertarDataAsync(CommandsContext context)
        {
            var dotnet = Guid.NewGuid();
            var npm = Guid.NewGuid();
            if (!context.Platform.Any())
            {
                var platforms = new List<Platform>
                {
                    new Platform
                    {
                        PlatformId = dotnet,
                        DateAdded = DateTime.Now,
                        PlatformName = "dotnet"
                    },
                    new Platform
                    {
                        PlatformId = npm,
                        DateAdded = DateTime.Now,
                        PlatformName = "npm"
                    }
                };

                foreach (var platform in platforms)
                {
                    await context.Platform.AddAsync(platform);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Command.Any())
            {
                var commands = new List<Command>
                {
                    new Command
                    {
                        CommandId = Guid.NewGuid(),
                        HowTo = "Build a Project",
                        Line = "dotnet build",
                        PlatformId = dotnet
                    },
                    new Command
                    {
                        CommandId = Guid.NewGuid(),
                        HowTo = "Run a Project",
                        Line = "dotnet run",
                        PlatformId = dotnet
                    },
                    new Command
                    {
                        CommandId = Guid.NewGuid(),
                        HowTo = "Install packages",
                        Line = "npm install",
                        PlatformId = npm
                    }
                };

                foreach (var command in commands)
                {
                    await context.Command.AddAsync(command);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
