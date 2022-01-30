using Api.Helpers;
using Api.Models;
using Api.Models.Company;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class CompanyRepository : MainRepository<CompanyProfile>, ICompanyRepository
    {
        private readonly Context _context;
        //private readonly IMapper _mapper;

        public CompanyRepository(Context context) :base(context)
        {
            _context = context;
            //_mapper = mapper;
        }
 

        public void Update(CompanyProfile companyProfile)
        {
            var companyProfileInDB = _context
                .CompanyProfiles.FirstOrDefault(cp => cp.AppUserId == companyProfile.AppUserId);

            if (companyProfileInDB != null)
            {
                companyProfileInDB.CompanyName = companyProfile.CompanyName;
                companyProfileInDB.CompanyDescription = companyProfile.CompanyDescription;
                //companyProfileInDB.ImgLogoPath = companyProfile.ImgLogoPath;
                companyProfileInDB.FoundedDate = companyProfile.FoundedDate;
                companyProfileInDB.CompanySize = companyProfile.CompanySize;
                companyProfileInDB.LinkedIn = companyProfile.LinkedIn;
                companyProfileInDB.Feacbook = companyProfile.Feacbook;
                companyProfileInDB.Website = companyProfile.Website;
                companyProfileInDB.AppUserId = companyProfile.AppUserId;
                 //var newCompanyProfile = _mapper.Map<CompanyProfile, CompanyProfile>(companyProfileInDB);
                _context.SaveChanges();
            }
        }



        public SaveImageResult SaveCompanyLogo(IFormFile file, string companyName)
        {


            //extract the first file whitch attached in the request body
                var folderName = Path.Combine("Resources", "CompaniesLogos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                var fullPath = Path.Combine(pathToSave, fileName);
                    var dbLogoPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return new SaveImageResult { Status = true, Path = dbLogoPath };
                }
                else
                {
                    return new SaveImageResult { Status = true };
                }
            

            
        }
    }
}
