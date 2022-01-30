using Api.Helpers;
using Api.Models.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface ICompanyRepository:IRepository<CompanyProfile>
    {
        void Update(CompanyProfile companyProfile);

        SaveImageResult SaveCompanyLogo(IFormFile file,string companyName);
        
    }
}
