using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class CompanyAddresesDto
    {
        public int Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }
    
    }
}
