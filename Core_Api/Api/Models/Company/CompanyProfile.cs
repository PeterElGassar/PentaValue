using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Company
{
    public class CompanyProfile
    {


        public CompanyProfile()
        {
            CompanyIndustries = new Collection<CompanyIndustry>();
            CompanyPhonNumbers = new Collection<CompanyPhonNumber>();
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


        public bool IsDeleted { get; set; }
        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
        public virtual ICollection<CompanyIndustry> CompanyIndustries { get; set; }
        public  ICollection<CompanyPhonNumber> CompanyPhonNumbers { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}
