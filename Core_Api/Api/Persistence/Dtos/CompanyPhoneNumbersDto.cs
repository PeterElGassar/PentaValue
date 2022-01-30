using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class CompanyPhoneNumbersDto
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int CompanyProfileId { get; set; }
    }
}
