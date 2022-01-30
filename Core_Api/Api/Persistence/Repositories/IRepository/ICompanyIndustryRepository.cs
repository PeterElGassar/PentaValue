using Api.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface ICompanyIndustryRepository:IRepository<CompanyIndustry>
    {
        void Update(CompanyIndustry companyIndustry);
        void Delete(CompanyIndustry companyIndustry);
    }
}
