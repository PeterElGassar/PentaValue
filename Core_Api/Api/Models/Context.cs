using Api.Models.BasicModels;
using Api.Models.Candidate;
using Api.Models.Company;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Context: IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> opt):base(opt)
        {

        }

        public DbSet<Industry> Industries { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<ProfileCandidatePhonNumber> ProfileCandidatePhonNumbers { get; set; }



        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<CompanyPhonNumber> CompanyPhoneNumbers { get; set; }
        public DbSet<CandidateCareerInfo> CandidateCareerInfos { get; set; }
        public DbSet<Media> Medias { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }



    }
}
