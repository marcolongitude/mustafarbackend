using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace mustafarbackend.Middlewares.ErrorHandling
{
    public static class UseGlobalExceptionHandler
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerCustom(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionMiddleware>();
    }
}