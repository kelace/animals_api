using Animals.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Infrastructure.Extentions
{
    public static class AnimalsServiceExtention
    {
        public static IServiceCollection AddAppServiceConfigure(this IServiceCollection service)
        {
            return service.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
