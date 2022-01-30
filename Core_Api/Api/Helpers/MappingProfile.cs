using Api.Models.BasicModels;
using Api.Models.Candidate;
using Api.Models.Company;
using Api.Persistence.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidateProfile, CandidatProfileDto>();
            
            CreateMap<CompanyProfile, CompanyProfile>();
            //CompanyProfile
            CreateMap<CompanyProfile, CompanyProfileDto>();
            CreateMap<CompanyProfileDto, CompanyProfile>();

            CreateMap<CompanyIndustry, CompanyIndustryDto>();

            CreateMap<CompanyProfile, GetCompanyProfileDto>();

            //CreateMap<GetCompanyProfileDto, CompanyProfile>();
            CreateMap<Industry, CompanyIndustryDto>();


            CreateMap<CompanyAddress, CompanyAddress>();

            CreateMap<CompanyAddress, CompanyAddresesDto>();

            CreateMap<CompanyPhonNumber, CompanyPhoneNumbersDto>();
            CreateMap< CompanyPhoneNumbersDto, CompanyPhonNumber>();

            //Candidate Profile
            CreateMap<ProfileCandidatePhonNumber, ProfileCandidatePhonNumbersDto>();

            CreateMap<ProfileCandidatePhonNumbersDto, ProfileCandidatePhonNumber>();
            CreateMap<CandidatProfileDto, CandidateProfile>();  

        }
    }
}
