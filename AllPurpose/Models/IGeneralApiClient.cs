using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Models
{
    public interface IGeneralApiClient
    {
        Task<string> GetRequest(string url);
        Task<string> PostRequest(string url, object obj);
    }
}
