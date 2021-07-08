using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Models
{
    public interface IGraphQLClient
    {
        Task<string> SendRequest(string reqQuery, string variables);
    }
}
