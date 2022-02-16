using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class UserServices : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public UserServices(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task SignIn(SignInDTO signIn)
        {
            var user = new ApplicationUser();
            if (signIn.EmailOrUserName.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(signIn.EmailOrUserName);
            }
            else
            {
                user = await _userManager.FindByNameAsync(signIn.EmailOrUserName);
            }
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, signIn.Password) == true)
                {
                    if (signIn.ConfirmPassword == signIn.Password)
                    {
                        await _signInManager.PasswordSignInAsync(user, signIn.Password, false, false);
                    }
                }
            }
        }
        public async Task Register(RegisterDTO register) 
        {
            var users=await _userManager.FindByEmailAsync(register.Email);
            var userss=await _userManager.FindByNameAsync(register.UserName);
            if (users == null && userss == null)
            {
                var user = _mapper.Map<RegisterDTO, ApplicationUser>(register);
                user.Id = Guid.NewGuid().ToString();
                user.ConfirmPassword = register.Password;
                await _userManager.CreateAsync(user, register.Password);
            }
        }

        public UserDetailsDTO ProfileDetails(ApplicationUser user) 
        {
            if(user == null)
            {
                return null;
            }
            else
            {
                var details = _mapper.Map<ApplicationUser, UserDetailsDTO>(user);
                return details;
            }
        }
    }
}
