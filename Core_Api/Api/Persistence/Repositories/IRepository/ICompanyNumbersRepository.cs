using Api.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{

    public interface ICompanyNumbersRepository:IRepository<CompanyPhonNumber>
    {

        public void Update(CompanyPhonNumber companyPhonNumber);
        public void Delete(CompanyPhonNumber companyPhonNumber);

    }



}
