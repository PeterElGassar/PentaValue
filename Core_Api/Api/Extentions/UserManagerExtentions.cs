using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Extentions
{
    public static class UserManagerExtentions
    {
        public static async Task<AppUser> FindByEmailWithCandidatProfile
            (this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;

            return await input.Users
                .Include(u => u.CandidateProfile)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

         public static async Task<AppUser> FindByEmailFromClaimsPrincipal
            (this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(u => u.Email == email);
        }


        //Company Functions

        public static async Task<AppUser> FindByEmailWithProfileCompany
            (this UserManager<AppUser> input, ClaimsPrincipal user)
        { 
            var email = user?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;

            return await input.Users
                .Include(u => u.CopmanyProfile)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public static async Task<AppUser> FindByEmailWithCandidateProfile
            (this UserManager<AppUser> input, ClaimsPrincipal user)
        { 
            var email = user?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;

            return await input.Users
                .Include(u => u.CandidateProfile)
                .FirstOrDefaultAsync(u => u.Email == email);
        }


    }
}
