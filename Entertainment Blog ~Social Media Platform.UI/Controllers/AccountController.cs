using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet,AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken,AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInDTO logIn)
        {
            if (ModelState.IsValid)
            {
                var userFindEmail = await _userManager.FindByEmailAsync(logIn.Email);
                var userFindName = await _userManager.FindByNameAsync(logIn.UserName);
                if (userFindEmail != null && userFindName != null)
                {
                    if (userFindEmail == userFindName)
                    {
                        await _signInManager.SignOutAsync();
                        if (await _userManager.CheckPasswordAsync(userFindEmail, logIn.Password) == false)
                        {
                            return View(logIn);
                        }
                        else
                        {
                            if (logIn.Password == logIn.ConfirmPasword)
                            {
                                await _signInManager.CheckPasswordSignInAsync(userFindEmail, logIn.Password, false);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View(logIn);
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
