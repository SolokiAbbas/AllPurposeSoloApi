using AllPurpose.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllPurpose.Controllers
{
    [Route("/general")]
    public class GeneralApiController : Controller
    {
        private IGeneralApiClient GAClient { get; }
        private AllPurpOptions Options { get; }
        public GeneralApiController(IGeneralApiClient generalApi, IOptions<AllPurpOptions> options)
        {
            GAClient = generalApi;
            Options = options.Value;
        }

        [HttpGet("/pokemon/{pokemonName}")]
        public async Task<IActionResult> GetPokemon(string pokemonName)
        {
            var result = await GAClient.GetRequest(Options.PokemonApi + pokemonName);
            return Content(result);
        }
        [HttpGet("/countries/{countryName}")]
        public async Task<IActionResult> GetCountries(string countryName)
        {
            var result = await GAClient.GetRequest(Options.CountriesApi + countryName);
            return Content(result);
        }

    }
}
