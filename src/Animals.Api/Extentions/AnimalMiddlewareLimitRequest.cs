using Animals.Api.Middlewarse;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Api.Extentions
{
    public static class AnimalMiddlewareLimitRequest
    {
        public static IApplicationBuilder UseRequestLimit (this IApplicationBuilder app, int time, int count)
        {
            return app.UseMiddleware<RequestLimitMiddleWare>(time, count);
        }
    }
}
