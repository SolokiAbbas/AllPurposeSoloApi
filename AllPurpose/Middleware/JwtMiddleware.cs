using AllPurpose.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private IJwtHandler JwtHandler { get; }
        public JwtMiddleware(RequestDelegate next, IJwtHandler jwtHandler)
        {
            _next = next;
            JwtHandler = jwtHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            context.Items["User"] = null;

            if (JwtHandler.ValidateJwt(token))
            {
                context.Items["User"] = "User"; 
            }
            
            await _next(context);
        }
    }
}
