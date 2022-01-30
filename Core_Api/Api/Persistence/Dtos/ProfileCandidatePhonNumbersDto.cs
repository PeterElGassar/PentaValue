using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class ProfileCandidatePhonNumbersDto
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int CandidateProfileId { get; set; }
    }
}
