using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Company
{
    public class CompanyPhonNumber
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }

        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }

    }
}
