using AllPurpose.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Controllers
{
    [Route("/graphql")]
    public class GraphController : Controller
    {
        private IGraphQLClient GQLClient { get; }
        private AllPurpOptions Options { get; }
        public class GraphQLBody
        {
            public string Query { get; set; }
            public string Variables { get; set; }
        }
        public GraphController(IGraphQLClient graphQLApi, IOptions<AllPurpOptions> options)
        {
            GQLClient = graphQLApi;
            Options = options.Value;
        }

        // GraphQL usually works with post but since most of them need proper format to send, dont need Client
        //[HttpPost("/animelist")]
        //public async Task<IActionResult> GetAnime([FromBody]GraphQLBody body)
        //{            
        //    var result = await GQLClient.SendRequest(body.Query, body.Variables);
        //    return Content(result);
        //}

        //[HttpPost("/starwars")]
        //public async Task<IActionResult> GetStarWars([FromBody] GraphQLBody body)
        //{
        //    var result = await GQLClient.SendRequest(body.Query, body.Variables);
        //    return Content(result);
        //}
    }
}
