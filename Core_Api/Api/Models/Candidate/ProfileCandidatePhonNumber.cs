using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Candidate
{
    public class ProfileCandidatePhonNumber
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }
        public int CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; }
    }
}
