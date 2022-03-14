using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper,UserManager<ApplicationUser> userManager,IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }        
        public IActionResult AllUsers()
        {
            var users = _userManager.Users;
            var lists = _mapper.Map<List<UserDetailsDTO>>(users);
            return View(lists);
        }
        [HttpPost,ValidateAntiForgeryToken]     
        public async Task<IActionResult> SignIn(SignInDTO signIn)
        {
            if (ModelState.IsValid)
            {
                await _userService.SignIn(signIn);
                return RedirectToAction("Index","Home");
            }
            return View(signIn);
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Register() 
        { 
            return View(); 
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(register);
                return RedirectToAction("Index", "Home");
            }
            return View(register);
        }
        public async Task<IActionResult> Profile() 
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var detail = await _userService.UserProfileAsync(user);
            return View(detail);
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {
            var user = await _userService.FindUserByIdAsync(id);
            if(user == null)
            {
                return View("Error");
            }
            return View(user);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditUserDTO editUser)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditUserAsync(editUser);
                return RedirectToAction("Profile");
            }
            return View(editUser);
        }
    }
}
