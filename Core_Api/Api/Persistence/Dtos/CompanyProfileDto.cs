using Api.Models.Company;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class CompanyProfileDto
    {
        public CompanyProfileDto()
        {
            CreatedAt = DateTime.Now;
        }

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

        public List<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
