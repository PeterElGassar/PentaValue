using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.BasicModels
{
    public class Industry
    {
        public int Id { get; set; }
        public string IndustryName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
