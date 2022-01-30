using Api.Core.Interfaces;
using Api.Extentions;
using Api.Models;
using Api.Models.Candidate;
using Api.Persistence.Dtos;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AccountController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;


        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _ITokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;



        public AccountController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService ITokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ITokenService = ITokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<ActionResult<AppUserDto>> GetCurrentUser()
        {

            var user = await _userManager.FindByEmailFromClaimsPrincipal(HttpContext.User);

            return new AppUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Token = _ITokenService.CreateToken(user),
                DisplayName = user.DisplayName,
                Role = user.Role
            };

        }


        [HttpGet("emailexists")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> checkEmailExistsAsync([FromQuery] string email)
        {

            return await _userManager.FindByEmailAsync(email) != null;

        }

        [HttpGet("CandidateProfile")]

        public async Task<ActionResult<CandidatProfileDto>> GetCandidateProfile()
        {

            var user = await _userManager.FindByEmailWithCandidatProfile(HttpContext.User);
            return _mapper.Map<CandidateProfile, CandidatProfileDto>(user.CandidateProfile);

        }


        [HttpPut("CandidateProfile")]

        public async Task<ActionResult<CandidatProfileDto>> UpdateCandidateProfile
            (CandidatProfileDto profile)
        {
            //user with including
            var user = await _userManager.FindByEmailWithCandidatProfile(HttpContext.User);

            user.CandidateProfile = _mapper.Map<CandidatProfileDto, CandidateProfile>(profile);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(_mapper.Map<CandidateProfile, CandidatProfileDto>(user.CandidateProfile));

            return BadRequest("Proplem while updating the user");

        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto RegisterDto)
        {

            //IdentityResult result = await _unitOfWork.AppUser.Register(AppUserDto);

            //if (AppUserDto == null) return BadRequest(404);


            //var userExists = await _userManager.FindByEmailAsync(AppUserDto.Email);
            //if (userExists != null)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Message = "User already exists!" });


            if (checkEmailExistsAsync(RegisterDto.Email).Result.Value)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = 500, Message = "Email already exists!" });

            }

            var newUser = new AppUser
            {
                DisplayName = RegisterDto.DisplayName,
                Email = RegisterDto.Email,
                UserName = RegisterDto.Email,
                Role = RegisterDto.Role
            };

            var result = await _userManager.CreateAsync(newUser, RegisterDto.Password);
            var roleResult = await _userManager.AddToRoleAsync(newUser, RegisterDto.Role);

            if (!result.Succeeded || !roleResult.Succeeded)
                return StatusCode(StatusCodes.Status400BadRequest, result.Errors);



            var currentUser = await _userManager.FindByEmailAsync(RegisterDto.Email);

            return new AppUserDto()
            {
                Id = currentUser.Id,
                DisplayName = RegisterDto.DisplayName,
                Email = RegisterDto.Email,
                Token = _ITokenService.CreateToken(newUser),
                Role = RegisterDto.Role
            };
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto loginDto)
        {

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return
                 StatusCode(StatusCodes.Status401Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Status = 401, Message = "Invalid Email or Password" });

            return new AppUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Token = _ITokenService.CreateToken(user),
                DisplayName = user.DisplayName,
                Role = user.Role
            };
        }


        [HttpGet("Auth")]
        public ActionResult<string> TestAuth()
        {
            return "Your Auth";
        }

        [HttpPost]
        [Route("test/{token}")]
        public async Task<IActionResult> TestGoogle([FromRoute] string token)
        {
            var google = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings()
            {

                Audience = new[] { "347336624379-12kv3a2hlfmh4gklnj49ji0kbd8ic2ic.apps.googleusercontent.com" }


            });
            return Ok();
        }




    }
}
