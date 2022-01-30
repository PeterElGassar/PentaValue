using Api.Models;
using Api.Models.Company;
using Api.Persistence.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class CompanyIndustryRepository : MainRepository<CompanyIndustry>, ICompanyIndustryRepository
    {
        private readonly Context _context;

        public CompanyIndustryRepository(Context context):base(context)
        {
            _context = context;
        }

        public void Delete(CompanyIndustry companyIndustry)
        {
            var entityInDB = _context.CompanyIndustries.FirstOrDefault(ci => ci.CompanyProfileId == companyIndustry.CompanyProfileId);

            if (entityInDB != null)
            {
                entityInDB.IsDeleted = true;
                _context.SaveChanges();

            }
        }

        public void Update  (CompanyIndustry model)
        {
            var entityInDB = _context.CompanyIndustries.FirstOrDefault(ci => ci.CompanyProfileId == model.CompanyProfileId);

            if (entityInDB != null)
            {
                entityInDB.IndustryName = model.IndustryName;
                entityInDB.CompanyProfileId = model.CompanyProfileId;
                _context.SaveChanges();
            }
        }
    }
}
