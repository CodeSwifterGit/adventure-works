using AdventureWorks.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace AdventureWorks.Web.Api.Services
{
    public class EnvironmentInformationProvider : IEnvironmentInformationProvider
    {
        public EnvironmentInformationProvider(IWebHostEnvironment environment)
        {
            if (environment != null)
            {
                EnvironmentName = environment.EnvironmentName;
                ApplicationName = environment.ApplicationName;
                ContentRootPath = environment.ContentRootPath;
                WebRootPath = environment.WebRootPath;
            }
        }

        public string EnvironmentName { get; }
        public string ApplicationName { get; }
        public string ContentRootPath { get; }
        public string WebRootPath { get; }
    }
}