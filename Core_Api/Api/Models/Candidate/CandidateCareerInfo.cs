using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Candidate
{
    public class CandidateCareerInfo
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobLevel { get; set; }
        public string JobNature { get; set; }
        public string Objective { get; set; }

        public int CurrentSalary { get; set; }
        public int ExpectedSalary { get; set; }


        public int CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; }
    }
}
