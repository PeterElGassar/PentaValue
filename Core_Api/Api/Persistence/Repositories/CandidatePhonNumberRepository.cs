using Api.Models;
using Api.Models.Candidate;
using Api.Persistence.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class CandidatePhonNumberRepository : MainRepository<ProfileCandidatePhonNumber>, ICandidatePhonNumberRepository
    {
        private readonly Context _context;

        public CandidatePhonNumberRepository(Context context):base(context)
        {
            _context = context;
        }


        public void Update(ProfileCandidatePhonNumber profileCandidatePhonNumber)
        {
            throw new NotImplementedException();
        }
    }
}
