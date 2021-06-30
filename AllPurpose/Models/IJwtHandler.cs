using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPurpose.Models
{
    public interface IJwtHandler
    {
        bool ValidateJwt(string encodedJwt);
        string GenerateJwt();
    }
}
