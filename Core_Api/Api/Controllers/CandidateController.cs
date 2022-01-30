using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Extentions;
using Api.Models;
using Api.Models.Candidate;
using Api.Persistence.Dtos;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CandidateController : BaseApiController
    {

       
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CandidateController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }



        [HttpGet("getCandidateProfile")]
        public async Task<ActionResult<CandidatProfileDto>> getCompanyProfile()
        {
            var user = await _userManager.FindByEmailWithCandidateProfile(HttpContext.User);
            var candidteProfile = await _unitOfWork.CandidateProfile
                .GetFirstOrDefaultAsync(cp => cp.AppUserId == user.Id, "ProfileCandidatePhonNumbers");
            //var compantProfile = await _context.CompanyProfiles.Include(cp => cp.CompanyPhonNumbers).FirstOrDefaultAsync(cp => cp.AppUserId == user.Id);

            return _mapper.Map<CandidateProfile, CandidatProfileDto>(candidteProfile);
        }



        [HttpPost("CreateCandidateProfile")]
        public ActionResult<CandidatProfileDto> CreateCandidateProfile(CandidatProfileDto candidatProfileDto)
        {

            if (candidatProfileDto == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

            _unitOfWork.CandidateProfile.Add(_mapper.Map<CandidatProfileDto, CandidateProfile>(candidatProfileDto));

            if (candidatProfileDto.ProfileCandidatePhonNumbers != null) { 

                foreach (var item in candidatProfileDto.ProfileCandidatePhonNumbers)
                {
                    //item.CandidateProfileId = candidatProfileDto.Id;
                    _unitOfWork.CandidatePhonNumber.Add(_mapper.Map<ProfileCandidatePhonNumbersDto, ProfileCandidatePhonNumber>(item));
                }

            }
            _unitOfWork.Complete();
            return candidatProfileDto;
        }



        [HttpPut("UpdateCandidateProfile")]
        public ActionResult<CandidatProfileDto> UpdateCandidateProfile(CandidatProfileDto candidatProfileDto)
        {
            try
            {
                if (candidatProfileDto == null)
                    return StatusCode(StatusCodes.Status404NotFound, new { Status = 404, Message = "Please Enter Full Data" });

                _unitOfWork.CandidateProfile.Update(_mapper.Map<CandidatProfileDto, CandidateProfile>(candidatProfileDto));

                var allCompanyIndustries = _unitOfWork.CandidatePhonNumber
                    .GetAll(x => x.CandidateProfileId == candidatProfileDto.Id);

                // remove old Candidate PhoneNumbers
                foreach (var item in allCompanyIndustries)
                {
                    _unitOfWork.CandidatePhonNumber.Remove(item);
                }

                ////Add new Candidate PhoneNumbers
                foreach (var item in candidatProfileDto.ProfileCandidatePhonNumbers)
                {
                    //item.CandidateProfileId = candidatProfileDto.Id;
                    //uncomment
                    _unitOfWork.CandidatePhonNumber.Add(_mapper.Map<ProfileCandidatePhonNumbersDto, ProfileCandidatePhonNumber>(item));

                }
                _unitOfWork.Complete();
                return candidatProfileDto;
            }
            catch (Exception e)
            {

                throw new Exception(e.InnerException.Message);
            }

        }



        [HttpDelete("DeleteCandidateProfile")]
        public IActionResult DeleteCandidateProfile(int id)
        {


            _unitOfWork.CandidateProfile.Remove(id);
            _unitOfWork.Complete();

            return Ok(new { message = "Deleted Success" });
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("SaveCandidateImage")]
        public async Task<IActionResult> SaveCandidateImage()
        {
            try
            {
                var user = await _userManager.FindByEmailWithProfileCompany(HttpContext.User);
                var candidateProfile = await _unitOfWork.CandidateProfile.GetFirstOrDefaultAsync(cp => cp.AppUserId == user.Id);
                //extract the first file whitch attached in the request body

                var result = _unitOfWork.CandidateProfile.SaveCandidateImage(Request.Form.Files[0], candidateProfile.FirstName);

                if (result.Status)
                {
                    //AsignToProfileCompany(dbPath);
                    candidateProfile.ProfileImgPath = result.Path;
                    _unitOfWork.CandidateProfile.Update(candidateProfile);
                    _unitOfWork.Complete();
                };

                return Ok(new { imagePath = result.Path });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }

        }


    }
}
