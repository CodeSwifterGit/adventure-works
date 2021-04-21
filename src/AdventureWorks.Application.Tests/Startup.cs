using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using AdventureWorks.Application.Extensions;
using AdventureWorks.Application.Infrastructure;
using AdventureWorks.Application.Infrastructure.AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Tests.Fakes.Services;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Common.Models;
using AdventureWorks.Domain;
using AdventureWorks.Infrastructure;
using AdventureWorks.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AdventureWorks.Application.Tests
{
    public class Startup
    {
        private ServerConfiguration _serverConfiguration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Singletons
            services.AddSingleton<IEnvironmentInformationProvider>(new FakeEnvironmentInformationProvider());

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            // Register all query managers
            services.AddScopedForClassesEndingWith(typeof(AutoMapperProfile).GetTypeInfo().Assembly, "QueryManager");


            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            // Add database context
            services.AddDbContext<AdventureWorksContext>(options =>
                {
                    options.UseInMemoryDatabase("AdventureWorksDB-" + Guid.NewGuid());
                    options.UseLazyLoadingProxies();
                    options.ConfigureWarnings(warningOptions =>
                    {
                        warningOptions.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                    });
                }
            );

            services.AddScoped(service =>
                (IAdventureWorksContext)service.GetService(typeof(AdventureWorksContext)));
            services.AddScoped<AdventureWorksSeeder>();

            var fileName = "appsettings.json";
            _serverConfiguration = GetConfigurationFromJson(fileName);
            services.AddSingleton(_serverConfiguration);


            // Register framework (some of them should be fake) services
            services.AddScoped<IAuthenticatedUserService, FakeAuthenticatedUserService>();
            services.AddTransient<INotificationService, FakeNotificationService>();
            services.AddTransient<ICrudWarningService, FakeCrudWarningService>();
            services.AddTransient<IDateTime, MachineDateTime>();
        }

        private ServerConfiguration GetConfigurationFromJson(string fileName)
        {
            var codeBase = Assembly.GetExecutingAssembly().Location;
            var uri = new UriBuilder(codeBase ?? string.Empty);
            var path = Uri.UnescapeDataString(uri.Path);

            var file = Path.Combine(Path.GetDirectoryName(path), fileName);

            return JsonConvert.DeserializeObject<ServerConfiguration>(File.ReadAllText(file));
        }
    }
}