using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animals.Api.RequestLimiterSpace;
using System.Net;

namespace Animals.Api.Middlewarse
{
    public class RequestLimitMiddleWare
    {
        private readonly RequestDelegate _next;
        private int _time;
        private int _count;

        public RequestLimitMiddleWare(RequestDelegate next, int time, int count)
        {
            _next = next;
            _time = time;
            _count = count;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var limiter = RequestLimiter.GetInstance(_time, _count);
            if (limiter.Count())
            {
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                return;
            }

            await _next(context);
        }
    }
}
