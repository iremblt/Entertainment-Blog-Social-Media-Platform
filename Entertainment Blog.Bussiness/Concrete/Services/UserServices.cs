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
        // Error larnı ekle
        public async Task SignIn(SignInDTO signIn)
        {
            var user=new ApplicationUser();
            if (signIn.EmailOrUserName.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(signIn.EmailOrUserName);
            }
            else
            {
                user = await _userManager.FindByNameAsync(signIn.EmailOrUserName);
            }
            if(user != null) 
            {
                if (await _userManager.CheckPasswordAsync(user, signIn.Password)==true) 
                {
                    if (signIn.ConfirmPassword == signIn.Password) 
                    {
                        await _signInManager.PasswordSignInAsync(user,signIn.Password,false,false);
                    }
                }
            }
            //var userFindEmail = await _userManager.FindByEmailAsync(signIn.Email);
            //var userFindName = await _userManager.FindByNameAsync(signIn.UserName);
            //if (userFindEmail != null && userFindName != null)
            //{
            //    if (userFindEmail == userFindName)
            //    {
            //        await _signInManager.SignOutAsync();
            //        if (await _userManager.CheckPasswordAsync(userFindEmail, signIn.Password) == true)
            //        {
            //            if (signIn.Password == signIn.ConfirmPassword)
            //            {
            //                await _signInManager.PasswordSignInAsync(userFindEmail,signIn.Password,true,false);
            //            }
            //        }
            //    }
            //}
        }
        public async Task Register(RegisterDTO register) 
        {
            var users=await _userManager.FindByEmailAsync(register.Email);
            var userss=await _userManager.FindByNameAsync(register.UserName);
            //if(users != null && userss != null) 
            //{
            //    var user=_mapper.Map<RegisterDTO,ApplicationUser>(register);
            //    //user.Id = Guid.NewGuid().ToString();
            //    await _userManager.CreateAsync(user,register.Password);
            //}
            if (users == null && userss == null)
            {
                var user = _mapper.Map<RegisterDTO, ApplicationUser>(register);
                user.Id = Guid.NewGuid().ToString();
                await _userManager.CreateAsync(user, register.Password);
            }
        }
    }
}
