using Api.Helpers;
using Api.Models.Candidate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
   public  interface ICandidateRepository:IRepository<CandidateProfile>
    {
        void Update(CandidateProfile candidateProfile);
        SaveImageResult SaveCandidateImage(IFormFile file, string companyName);
    }
}
