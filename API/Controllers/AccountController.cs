using API.Tools;
using AutoMapper;
using Business.Services;
using DTO.DTOS.UsersDTO.LoginDTO;
using DTO.DTOS.UsersDTO.RegisterDTO;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signIn;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager,IUserService users,IMapper mapper,IEmailService serivce,SignInManager<AppUser> signIn)
        {

            _userManager = userManager;
            _signIn = signIn;
            _mapper = mapper;
            _emailService= serivce;
            _userService = users;


        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(NewUserDTO dto)
        {

            AppUser appUser = new();
            _mapper.Map(dto, appUser);
            
            IdentityResult result = await _userManager.CreateAsync(appUser, dto.Password);
           
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                   return Ok(item.Description);
                }
                return BadRequest();
            }
            else
            {
                IdentityResult addRole = await _userManager.AddToRoleAsync(appUser, "Customer");
                _emailService.ConfirmCodeForNewUser(appUser);

                return Ok("İstifadəçi uğurla yaradıldı!");

            }
          



        }
        [HttpPost("ConfirmAccount")]
        public async Task<IActionResult> ConfirmAccount(ConfirmMailDTO dto)
        {
            AppUser appUser=await _userManager.FindByEmailAsync(dto.Email);
            if (appUser is null)
            {
                return NotFound("Belə bir elektron ünvan sistemdə mövcud deyil!");
            }
            if (dto.ConfirmCode!=appUser.ConfirmCode)
            {

                return BadRequest("Daxil edilmiş təsdiqləmə kodu yalnışdır!");
            }
            appUser.EmailConfirmed = true;
            await _userManager.UpdateAsync(appUser);
            return Ok("Hesabınız doğrulandı!");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO dto)
        {
            AppUser appUser = await _userManager.Users.Where(x => x.UserName == dto.EmailOrUserName || x.Email == dto.EmailOrUserName).FirstOrDefaultAsync();
            if (appUser==null)
            {

                return Ok("İstifadəçi tapılmadı");
            }
            var SignInResult = await _signIn.CheckPasswordSignInAsync(appUser, dto.Password,false);
            if (!SignInResult.Succeeded)
            {
                return BadRequest("Daxil etdiyiniz məlumatlar düzgün deyil!");
            }
            else
            {
                return Created("",JwtTokenGenerator.GenerateToken(dto));
            }
          
           
        }
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> RegisterForAdmin(NewUserDTO dto)
        {
            AppUser appUser = new();
            _mapper.Map(dto, appUser);
            appUser.EmailConfirmed=true;
            IdentityResult result = await _userManager.CreateAsync(appUser, dto.Password);
            IdentityResult addRole = await _userManager.AddToRoleAsync(appUser, "Admin");
           
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    Ok(item.Description);
                }
            }
            return Ok("Admin uğurla yaradıldı!");
        }

    }
    }
