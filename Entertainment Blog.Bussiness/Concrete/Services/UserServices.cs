using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public UserServices(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager,IMapper mapper, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
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
        public async Task<UserDetailsDTO> UserProfileAsync(ApplicationUser user)
        {
            if (user == null)
            {
                return null;
            }
            else
            {
                var detail =await _userRepository.UserDetailsAsync(user);
                var map = _mapper.Map<ApplicationUser, UserDetailsDTO>(detail);
                return map;
            }
        }
        public async Task EditUserAsync(EditUserDTO user)
        {
            var edit = _mapper.Map<EditUserDTO, ApplicationUser>(user,await _userManager.FindByIdAsync(user.Id));
            await _userManager.ChangePasswordAsync(edit,edit.ConfirmPassword,user.Password);
            await _userManager.UpdateAsync(edit);
            await _userRepository.SaveAsync();
        }
        public async Task<EditUserDTO> FindUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return null;
            }
            else
            {
                var userposts = await _userRepository.UserDetailsAsync(user);
                var edituser=_mapper.Map<ApplicationUser, EditUserDTO>(userposts);
                return edituser;
            }
        }     
        public async Task<UserDetailsDTO> FindUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return null;
            }
            else
            {
                var userposts = await _userRepository.UserDetailsAsync(user);
                var edituser=_mapper.Map<ApplicationUser, UserDetailsDTO>(userposts);
                return edituser;
            }
        }
        public async Task<EditUserDTO> UserIdWithAsNoTracking(string id)
        {
            var user = await _userRepository.UserIdWithAsNoTracking(id);
            return _mapper.Map<EditUserDTO>(user);
        }
    }
}
