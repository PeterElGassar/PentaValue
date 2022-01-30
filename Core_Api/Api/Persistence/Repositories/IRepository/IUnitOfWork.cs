using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IAppUserRepository AppUser { get; }

        IIndustryRepository Industry { get; }
        ICompanyRepository Company { get; }
        ICompanyIndustryRepository CompanyIndustry { get; }
        ICompanyAddressRepository CompanyAddress { get; }

        ICompanyNumbersRepository CompanyNumber { get; }
        ICandidateRepository CandidateProfile { get; }

        ICandidatePhonNumberRepository CandidatePhonNumber{ get; }

        void Complete();
    }
}
