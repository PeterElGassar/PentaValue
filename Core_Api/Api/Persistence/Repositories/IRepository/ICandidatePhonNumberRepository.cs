using Api.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface ICandidatePhonNumberRepository:IRepository<ProfileCandidatePhonNumber>
    {
        void Update(ProfileCandidatePhonNumber profileCandidatePhonNumber);
    }
}
