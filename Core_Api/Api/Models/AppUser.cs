using Api.Models.Candidate;
using Api.Models.Company;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AppUser:IdentityUser
    {

        public CandidateProfile CandidateProfile { get; set; }

        public  CompanyProfile CopmanyProfile { get; set; }

        public string Role { get; set; }

        public string DisplayName { get; set; }
    }
}
