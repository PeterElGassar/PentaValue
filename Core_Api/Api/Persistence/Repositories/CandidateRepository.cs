using Api.Helpers;
using Api.Models;
using Api.Models.Candidate;
using Api.Persistence.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class CandidateRepository : MainRepository<CandidateProfile>, ICandidateRepository
    {
        private readonly Context _context;

        public CandidateRepository(Context context):base(context)
        {
            _context = context;
        }

     

        public SaveImageResult SaveCandidateImage(IFormFile file, string companyName)
        {

            //extract the first file whitch attached in the request body
            var folderName = Path.Combine("Resources", "CandidatesImages");
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



        public void Update(CandidateProfile candidateProfile)
        {
            var candidateInDb = _context.CandidateProfiles.FirstOrDefault(c => c.Id == candidateProfile.Id);

            if (candidateInDb != null)
            {
                candidateInDb.FirstName = candidateProfile.FirstName;
                candidateInDb.LastName = candidateProfile.LastName;
                candidateInDb.MiddleName = candidateProfile.MiddleName;
                candidateInDb.Country = candidateProfile.Country;
                candidateInDb.City = candidateProfile.City;

                candidateInDb.Street = candidateProfile.Street;
                candidateInDb.ZipCode = candidateProfile.ZipCode;
                candidateInDb.EducationLevel = candidateProfile.EducationLevel;
                //_context.SaveChanges();


            }
        }




    }
}
