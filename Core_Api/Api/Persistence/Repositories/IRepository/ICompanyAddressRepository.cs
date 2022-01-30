using Api.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface ICompanyAddressRepository:IRepository<CompanyAddress>
    {
         void Update(CompanyAddress companyAddress);
         void Delete(CompanyAddress companyAddress);

    }
}
