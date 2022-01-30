using Api.Models;
using Api.Persistence.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        void Update(AppUser appUser);

        //Task<IdentityResult> Register(AppUserDto appUserDto);


    }
}
