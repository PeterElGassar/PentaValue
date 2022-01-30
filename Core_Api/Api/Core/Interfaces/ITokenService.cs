using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
