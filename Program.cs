using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RepositoryScanner.Implementations;
using RepositoryScanner.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryScanner
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        /// <summary>
        /// Application starting point.
        /// </summary>
        /// <param name="args">Optional command line parameters, first should represent username, second a repository name</param>
        static async Task Main(string[] args)
        {
            RegisterServices();
            var scope = serviceProvider.CreateScope();

            var consoleApplication = scope.ServiceProvider.GetRequiredService<ConsoleApplication>();
            await consoleApplication.StartAsync(args);

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IRepositoryCommunicationService, GitHubCommunicationService>();
            services.AddSingleton<ICommitsService, CommitsService>();
            services.AddSingleton<ICommitsRepository, CommitsRepository>();
            services.AddSingleton<ConsoleApplication>();

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }

            if (serviceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }
        }
    }
}