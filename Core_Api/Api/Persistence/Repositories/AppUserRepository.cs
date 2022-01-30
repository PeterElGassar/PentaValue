using Api.Models;
using Api.Persistence.Dtos;
using Api.Persistence.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class AppUserRepository : MainRepository<AppUser>, IAppUserRepository
    {

        private readonly Context _context;

        //private readonly SignInManager<AppUser> _signInManager;

        //private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(
            Context context): base(context)
        {
            _context = context;

        }

        //public async Task<IdentityResult> Register(AppUserDto appUserDto)
        //{
        //    IdentityResult result ;

        //    var newUser = new AppUser
        //    {
        //        UserName = appUserDto.UserName,
        //        Email = appUserDto.Email
        //    };

        //    result = await _userManager.CreateAsync(newUser, appUserDto.PasswordHash);


        //    return result;
        //}

        public void Update(AppUser appUser)
        {
            var objFromDb = _context.AppUsers.FirstOrDefault(u => u.Id == appUser.Id);

            if (objFromDb != null)
            {
                objFromDb.UserName = appUser.UserName;
                _context.SaveChanges();
            }
        }
    }
}
