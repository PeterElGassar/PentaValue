using Api.Models;
using Api.Models.Company;
using Api.Persistence.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{

    public class CompanyNumbersRepository: MainRepository<CompanyPhonNumber>,ICompanyNumbersRepository
    {
        private readonly Context _context;

        public CompanyNumbersRepository(Context context):base(context)
        {
            _context = context;
        }

        public void Delete(CompanyPhonNumber modal)
        {
            var companyPhonNumberInBd = _context.CompanyPhoneNumbers
              .FirstOrDefault(x => x.Id == modal.Id);

            if (companyPhonNumberInBd != null)
            {
                companyPhonNumberInBd.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public void Update(CompanyPhonNumber modal)
        {
            var companyPhonNumberInBd = _context.CompanyPhoneNumbers
                .FirstOrDefault(x => x.Id == modal.Id);

            if(companyPhonNumberInBd!= null)
            {
                companyPhonNumberInBd.PhoneNumber = modal.PhoneNumber;
                _context.SaveChanges();
            }


        }
    }


}
