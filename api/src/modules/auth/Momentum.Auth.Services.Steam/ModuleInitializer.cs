using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Momentum.Auth.Services.Steam;
using Momentum.Framework.Core.Dependency;
using Momentum.Framework.Core.Services;

namespace Momentum.Auth.Services
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtSteamService>();
        }


    }
}
