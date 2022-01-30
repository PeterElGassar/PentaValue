using Api.Models;
using Api.Models.Company;
using Api.Persistence.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class CompanyAddressRepository : MainRepository<CompanyAddress> ,ICompanyAddressRepository
    {
        
        private readonly Context _context;
        public CompanyAddressRepository(Context context) : base(context)
        {
            _context = context;
        }

        public void Delete(CompanyAddress companyAddress)
        {
            //path this parameter Mapped Before Invoke this method
            var companyAddessInDb = _context.CompanyAddresses
                .FirstOrDefault(ca => ca.Id == companyAddress.Id);

            if (companyAddessInDb != null)
            {
                companyAddessInDb.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public void Update(CompanyAddress companyAddress)
        {
            //path this parameter Mapped Before Invoke this method
            var companyAddessInDb = _context.CompanyAddresses
                .FirstOrDefault(ca => ca.Id == companyAddress.Id);

            if (companyAddessInDb != null)
            {
                companyAddessInDb.Country = companyAddress.Country;
                companyAddessInDb.City = companyAddress.City;
                companyAddessInDb.Street = companyAddress.Street;
                companyAddessInDb.ZipCode = companyAddress.ZipCode;
                
                _context.SaveChanges();
            }
        }



    }
}
