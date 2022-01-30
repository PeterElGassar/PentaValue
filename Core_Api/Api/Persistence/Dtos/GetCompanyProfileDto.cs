using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class GetCompanyProfileDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ImgLogoPath { get; set; }


        public DateTime FoundedDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanySize { get; set; }

        public string LinkedIn { get; set; }

        public string Feacbook { get; set; }

        public string Website { get; set; }

        public string AppUserId { get; set; }

        public List<CompanyIndustryDto> CompanyIndustries { get; set; }
        public List<CompanyAddresesDto> CompanyAddresses { get; set; }
        public List<CompanyPhoneNumbersDto> CompanyPhonNumbers { get; set; }
    }
}
