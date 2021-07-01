using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Models
{
    public class AllPurpOptions
    {
        public string KeyvaultUrl { get; set; }
        public string JwtSecret { get; set; }
        public string PokemonApi { get; set; }
        public string CountriesApi { get; set; }
        public string NasaApi { get; set; }
    }
}
