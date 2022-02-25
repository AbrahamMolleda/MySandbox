using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace xUnit.TestProject.Fixture
{
    public class FixtureService : IDisposable
    {
        public IConfigurationRoot Configuration { get; set; }
        ServiceProvider _serviceProvider { get; set; }
        ServiceCollection _services { get; set; }

        public FixtureService()
        {
            _services = new ServiceCollection();
        }

        public ServiceCollection ServiceProvidersForTestPropouses()
        {
            // Inyeccion de configuration :-)
            IConfigurationBuilder config = new ConfigurationBuilder()
                                  .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true)
                                  .AddEnvironmentVariables();
            IConfigurationRoot configurationRoot = config.Build();
            Configuration = configurationRoot;

            _services.AddSingleton<IConfiguration>(configurationRoot);
            return _services;

        }

        public ServiceProvider BuildServices()
        {

            ServiceProviderOptions options = new ServiceProviderOptions()
            {
                ValidateScopes = false
            };

            _serviceProvider = _services.BuildServiceProvider(options);

            return _serviceProvider;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
