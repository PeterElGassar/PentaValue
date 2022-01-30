using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Company
{
    public class CompanyAddress
    {
        public int Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public bool IsDeleted { get; set; }

        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }



    }
}
