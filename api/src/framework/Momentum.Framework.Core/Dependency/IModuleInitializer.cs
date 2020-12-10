using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Momentum.Framework.Core.Dependency
{
    public interface IModuleInitializer
    {
        //https://github.com/simplcommerce/SimplCommerce/blob/2c6b1b2ad85afd8b84b34e63d12ca24c4e14dbde/src/SimplCommerce.Infrastructure/Modules/IModuleInitializer.cs#L7
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
