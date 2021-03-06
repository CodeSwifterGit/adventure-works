using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.Extensions;
using AdventureWorks.Application.Infrastructure;
using AdventureWorks.Application.Infrastructure.AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Security;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Common.Models;
using AdventureWorks.Common.Security;
using AdventureWorks.Domain;
using AdventureWorks.Infrastructure;
using AdventureWorks.Infrastructure.Services;
using AdventureWorks.Persistence;
using AdventureWorks.Web.Api.Extensions;
using AdventureWorks.Web.Api.Filters;
using AdventureWorks.Web.Api.Helpers;
using AdventureWorks.Web.Api.Services;
using FluentValidation.AspNetCore;
using Joonasw.AspNetCore.SecurityHeaders;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;

namespace AdventureWorks.Web.Api
{
    public class Startup
    {
        private IWebHostEnvironment RuntimeEnvironment { get; }
        private IConfiguration Configuration { get; }
        private ServerConfiguration _serverConfiguration;
        private string WebRoot;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            RuntimeEnvironment = env;

            WebRoot = Path.Combine(GetRootDirectory(), "ClientApp", "dist", "index.html");
        }

        private string GetRootDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().Location;
            var path = codeBase.Replace('/', Path.DirectorySeparatorChar);

            return path;
        }

        private bool UseHsts()
        {
            var hstsVar = Environment.GetEnvironmentVariable("USE_HSTS")?.ToLower() ?? "";
            if (string.IsNullOrEmpty(hstsVar) || hstsVar == "false" || hstsVar == "0")
            {
                return false;
            }

            return true;
        }

        private bool UseSSL()
        {
            var httpsVar = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")?.ToLower() ?? "";
            return httpsVar.Contains("https://");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Singletons
            services.AddSingleton<IEnvironmentInformationProvider>(new EnvironmentInformationProvider(RuntimeEnvironment));

            // Ensure nothing non-secure passes to any controller
            if (!RuntimeEnvironment.IsDevelopment() && !RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase) && UseHsts())
            {
                services.Configure<MvcOptions>(o => o.Filters.Add(new RequireHttpsAttribute()));

                // TODO: We need to register adventureworks.com to the list of hsts preloaded domains https://hstspreload.org/
                services.AddHsts(o =>
                {
                    o.MaxAge = TimeSpan.FromDays(365);
                    o.Preload = true;
                    o.IncludeSubDomains = true;
                });
            }

            if (!RuntimeEnvironment.IsDevelopment() && !RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase) && UseSSL())
            {
                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                });
            }


            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            _serverConfiguration = ConfigurationHelper<ServerConfiguration>.GetConfigurationFromJson(RuntimeEnvironment);

            services.AddSingleton(_serverConfiguration);

            // Add AutoMapper
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            })));

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<ICrudWarningService, CrudWarningService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Register AuthenticatedUserService service
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<IAuthManagementService, AuthManagementService>();

            // Register all query managers
            services.AddScopedForClassesEndingWith(typeof(AutoMapperProfile).GetTypeInfo().Assembly, "QueryManager");

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            // Add database context
            services.AddDbContext<AdventureWorksContext>(_serverConfiguration.ConnectionStrings
                .AdventureWorksDatabase);
            services.AddScoped(service =>
                (IAdventureWorksContext)service.GetService(typeof(AdventureWorksContext)));

            // Add seeder
            services.AddScoped<AdventureWorksSeeder>();

            // Add support for proper validation return messages
            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AutoMapperProfile>());

            services.AddDataProtection(o => { o.ApplicationDiscriminator = "AdventureWorks"; });

            services.Configure<BrotliCompressionProviderOptions>
                (options => options.Level = CompressionLevel.Fastest);

            services.Configure<GzipCompressionProviderOptions>
                (options => options.Level = CompressionLevel.Fastest);

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "image/svg+xml", "image/jpeg", "image/png", "text/html", "application/javascript",
                    "application/json", "text/json", "text/css"
                });
            });

            services.AddControllers();

            if (!RuntimeEnvironment.IsDevelopment() && !RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                    options.ForwardLimit = 2;
                });
            }

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            services
                .AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilterAttribute)); })
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            // Add authentication services
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => RuntimeEnvironment.IsProduction() || RuntimeEnvironment.IsStaging();
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = _serverConfiguration.SecurityProvider.Authority;
                    options.Audience = _serverConfiguration.SecurityProvider.Audience;
                });

            var authDomain = _serverConfiguration.SecurityProvider.Authority;

            services.AddAuthorization(options =>
            {
                foreach (var securityPolicy in SecurityPoliciesFactory.Policies)
                    options.AddPolicy(securityPolicy.Name,
                        policy =>
                        {
                            foreach (var permission in securityPolicy.Permissions)
                                policy.Requirements.Add(new PermissionRequirement(permission.Name, authDomain));
                        });
            });

            // register the scope authorization handler
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            // Consider making this publicly available
            if (RuntimeEnvironment.IsDevelopment() ||
                RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddSwaggerDocument(settings =>
                {
                    settings.Title = "AdventureWorks API";
                });
            }

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                if (RuntimeEnvironment.IsProduction() || RuntimeEnvironment.IsStaging())
                {
                    options.SuppressModelStateInvalidFilter = true;
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (RuntimeEnvironment.IsDevelopment() || RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseForwardedHeaders();
                app.UseExceptionHandler("/Error");

                if (UseHsts())
                {
                    Console.WriteLine("Using HSTS");
                    HstsBuilderExtensions.UseHsts(app);
                }

                if (UseSSL())
                {
                    Console.WriteLine("Using SSL");
                    app.UseHttpsRedirection();
                }
            }

            // Add request logging to be able to identify attacks
            app.Use(async (ctx, next) =>
            {
                if (ctx?.Connection?.RemoteIpAddress != null)
                {
                    using (LogContext.PushProperty("IPAddress", ctx.Connection.RemoteIpAddress))
                    {
                        await next();
                    }
                }
            });
            app.UseSerilogRequestLogging();

            // Hacker prevention
            app.UseCsp(csp =>
                {
                    if (RuntimeEnvironment.IsDevelopment() || RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
                    {
                        csp.AllowScripts
                            .FromSelf()
                            .From("http://localhost:4200")
                            .From("https://localhost:6220")
                            .From("http://localhost:6221")
                            .From("https://www.googletagmanager.com")
                            .AllowUnsafeInline()
                            .AllowUnsafeEval();
                        csp.AllowStyles
                            .FromSelf()
                            .From("http://localhost:4200")
                            .From("https://localhost:6220")
                            .From("http://localhost:6221")
                            .From("https://fonts.googleapis.com")
                            .AllowUnsafeInline();
                        csp.AllowImages
                            .FromSelf()
                            .From("data:")
                            .From("http://localhost:4200")
                            .From("https://localhost:6220")
                            .From("http://localhost:6221");
                        csp.AllowFonts.FromAnywhere();
                    }
                    else
                    {
                        csp.AllowScripts
                            .FromSelf()
                            .From("https://www.googletagmanager.com")
                            .AllowUnsafeInline()
                            .AllowUnsafeEval();
                        csp.AllowStyles
                            .FromSelf()
                            .From("https://fonts.googleapis.com")
                            .AllowUnsafeInline();
                        csp.AllowImages
                            .FromSelf()
                            .From("data:");
                        csp.AllowFonts
                            .FromAnywhere();
                    }
                })
                .UseXFrameOptions(new XFrameOptionsOptions(XFrameOptionsOptions.XFrameOptionsValues.Deny))
                .UseReferrerPolicy(new ReferrerPolicyOptions(ReferrerPolicyOptions.ReferrerPolicyValue.NoReferrer))
                .UseXXssProtection(new XXssProtectionOptions(true, true))
                .UseXContentTypeOptions(new XContentTypeOptionsOptions(false));

            app.UseResponseCompression();
            app.UseStaticFiles();

            if (!RuntimeEnvironment.IsDevelopment() &&
                !RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseSpaStaticFiles();
            }
            else
            {
                app.UseCors(c =>
                    c.WithOrigins("http://localhost:4200", "https://localhost:6220", "http://localhost:6221"));
            }

            // Consider making this publicly available
            if (RuntimeEnvironment.IsDevelopment() ||
                RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseOpenApi();

                // Access Swagger UI using https://localhost:6220/swagger/v1/swagger.json
                app.UseSwaggerUi3(s =>
                {
                    s.DocumentTitle = "AdventureWorks API";
                });
            }

            if (RuntimeEnvironment.IsDevelopment())
                Console.WriteLine("Environment: " + RuntimeEnvironment.EnvironmentName);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    "api",
                    "api/[controller]/{action}/{id?}");

                config.MapControllerRoute(
                    "auth",
                    "auth/[controller]/{action}/{id?}");
            });

            if (!RuntimeEnvironment.IsDevelopment() && !RuntimeEnvironment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseRootRewrite();
                app.UseSpa(config => { });
            }
        }
    }
}