using AllPurpose.Logic;
using AllPurpose.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private IJwtHandler JwtHandler { get; }
        public HomeController(IJwtHandler jwtHandler)
        {
            JwtHandler = jwtHandler;
        }

        [HttpGet("healthcheck")]
        public IActionResult HealthCheck()
        {
            return Content("Okay", "text/plain");
        }

        [HttpGet("getjwt")]
        public IActionResult GetJwt()
        {
            return Content(JwtHandler.GenerateJwt());
        }

        [Attributes.JwtAuthorize]
        [HttpPost("testjwt")]
        public IActionResult TestJwt()
        {
            return Ok("Jwt Validated");
        }

    }
}
