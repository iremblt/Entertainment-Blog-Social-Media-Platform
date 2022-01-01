using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
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
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            //Email ve username unique olmalı onu bussinessda vs ekle!!!!!
            if (ModelState.IsValid)
            {
                await _userService.Register(register);
                return RedirectToAction("Index","Home");
            }
            //var users = await _userManager.FindByEmailAsync(register.Email);
            //var userss = await _userManager.FindByNameAsync(register.UserName);
            //if (users != null && userss != null)
            //{
            //    var user = _mapper.Map<RegisterDTO, ApplicationUser>(register);
            //    user.Id = Guid.NewGuid().ToString();
            //    var result = await _userManager.CreateAsync(user, register.Password);
            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            ModelState.AddModelError("", error.Description);
            //        }
            //    }
            //}
            return View(register);
        }
    }
}
