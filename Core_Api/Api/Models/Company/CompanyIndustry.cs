using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Company
{
    public class CompanyIndustry
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }


        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public bool IsDeleted { get; set; }
    }
}
