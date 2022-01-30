
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Extentions;
using Api.Models;
using Api.Models.Company;
using Api.Persistence.Dtos;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CompanyController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper =  mapper;
        }


        [HttpGet("getCompanyProfile")]
        public async Task<ActionResult<GetCompanyProfileDto>> getCompanyProfile()
        {
            var user = await _userManager.FindByEmailWithProfileCompany(HttpContext.User);
            var compantProfile = await _unitOfWork.Company
                .GetFirstOrDefaultAsync(cp => cp.AppUserId == user.Id, "CompanyPhonNumbers,CompanyIndustries,CompanyAddresses");
            //var compantProfile = await _context.CompanyProfiles.Include(cp => cp.CompanyPhonNumbers).FirstOrDefaultAsync(cp => cp.AppUserId == user.Id);
         
            return  _mapper.Map<CompanyProfile, GetCompanyProfileDto>(compantProfile);
        }


        [HttpPost("CreateCompanyProfile")]
        public ActionResult<CompanyProfileDto> CreateCompanyProfile(CompanyProfileDto companyProfileDto)
        {

            if (companyProfileDto == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.Company.Add(_mapper.Map<CompanyProfileDto, CompanyProfile>(companyProfileDto));

            foreach (var item in companyProfileDto.CompanyIndustries)
            {
                
                _unitOfWork.CompanyIndustry.Add(item);
            }

            _unitOfWork.Complete();

            return  companyProfileDto;
        }


        
        [HttpPost("UpdateCompanyProfile")]
        public ActionResult<CompanyProfileDto> UpdateCompanyProfile(CompanyProfileDto companyProfileDto)
        {
            try
            {
                if (companyProfileDto == null)
                    return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

                _unitOfWork.Company.Update(_mapper.Map<CompanyProfileDto, CompanyProfile>(companyProfileDto));

                var allCompanyIndustries = _unitOfWork.CompanyIndustry.GetAll(x => x.CompanyProfileId == companyProfileDto.Id);

               // remove old Company Industries
                foreach (var item in allCompanyIndustries)
                {
                    _unitOfWork.CompanyIndustry.Remove(item);
                }

                ////Add new Company Industries
                foreach (var item in companyProfileDto.CompanyIndustries)
                {
                    item.CompanyProfileId = companyProfileDto.Id;
                    _unitOfWork.CompanyIndustry.Add(item);

                }
                _unitOfWork.Complete();

                return companyProfileDto;
            }
            catch (Exception e)
            {

                throw new Exception(e.InnerException.Message);
            }

        }  
        

        [HttpDelete("DeleteCompanyProfile")]
        public ActionResult DeleteCompanyProfile(int id)
        {

            
              _unitOfWork.Company.Remove(id);
              _unitOfWork.Complete();

            return Ok(new { message="Deleted Success"}) ;
        }


        [HttpPost,DisableRequestSizeLimit]
        [Route("SaveCompanyLogo")]        
        public async Task<IActionResult> SaveCompanyLogo()
        {
            try
            {
                var user = await _userManager.FindByEmailWithProfileCompany(HttpContext.User);
                var compantProfile = await _unitOfWork.Company.GetFirstOrDefaultAsync(cp => cp.AppUserId == user.Id);
                //extract the first file whitch attached in the request body

                var result = _unitOfWork.Company.SaveCompanyLogo(Request.Form.Files[0], compantProfile.CompanyName);

                if (result.Status)
                {
                    //AsignToProfileCompany(dbPath);
                    compantProfile.ImgLogoPath = result.Path;
                    _unitOfWork.Company.Update(compantProfile);
                    _unitOfWork.Complete();

                };

                return Ok(new { message = result.Path });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }

        }


        //Create Company Addesses//////
        //Create Company Addesses//////
        [HttpPost("CreateCompanyAddress")]
        public ActionResult<CompanyAddress> CreateCompanyAddress(CompanyAddress companyAddress)
        {

            if (companyAddress == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.CompanyAddress.Add(companyAddress);
            _unitOfWork.Complete();

            return companyAddress;
        }

        [HttpPut("UpdateCompanyAddress")]
        public ActionResult<CompanyAddress> UpdateCompanyAddress(CompanyAddress companyAddress)
        {
            if (companyAddress == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.CompanyAddress.Update(companyAddress);

            _unitOfWork.Complete();
            return companyAddress;
        }

        [HttpDelete("DeleteCompanyAddress")]
        public ActionResult DeleteCompanyAddress(int id)
        {           
            _unitOfWork.CompanyAddress.Remove(id);
            _unitOfWork.Complete();
            return Ok(new { message ="Deleted Success"});
        }

        [HttpGet("GetAllAddresses")]
        public  ActionResult<IEnumerable<CompanyAddress>> GetAllAddressForCompanyPofile(int companyProfileId)
        {
           
            var allCompanyAddresses =   _unitOfWork.CompanyAddress.GetAll(ca=> ca.CompanyProfileId == companyProfileId,null,"CompanyProfile");
           
            if (allCompanyAddresses == null)
                return NotFound(new { message = "No Addresses For this Company yet"});

            return Ok(allCompanyAddresses);
        }


        //Create Company Numbers//////
        //Create Company Numbers//////
        [HttpPost("CreatePhoneCompanyNumber")]
        public ActionResult<CompanyPhonNumber> CreateCompanyNumber(CompanyPhonNumber modal)
        {

            if (modal == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.CompanyNumber.Add(modal);
            _unitOfWork.Complete();

            return modal;
        }

        [HttpPut("UpdateCompanyPhoneNumber")]
        public ActionResult<CompanyPhonNumber> UpdateCompanyNumber(CompanyPhonNumber companyAddress)
        {
            if (companyAddress == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.CompanyNumber.Update(companyAddress);

            _unitOfWork.Complete();
            return companyAddress;
        }

        [HttpDelete("DeleteCompanyNumber")]
        public ActionResult DeleteCompanyNumber(int id)
        {           
            _unitOfWork.CompanyNumber.Remove(id);
            _unitOfWork.Complete();

            return Ok(new { message ="Deleted Success"});
        }
        
        [HttpGet("GetAllPhoneNumbers")]
        public  ActionResult<IEnumerable<CompanyPhonNumber>> GetAllNumbersForCompanyPofile(int companyProfileId)
        {
           
            var allCompanyAddresses =   _unitOfWork.CompanyNumber
                .GetAll(ca=> ca.CompanyProfileId == companyProfileId);
           
            if (allCompanyAddresses == null)
                return NotFound(new { message = "No Addresses For this Company yet"});

            return Ok(allCompanyAddresses);
        }

    }
}
