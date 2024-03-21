using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            //RegisterViewModelValidator validationRules = new RegisterViewModelValidator();
            //ValidationResult result = validationRules.Validate(model);
            AppUser user = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Email = model.Email,
                ImageUrl="default-image.jpg",
                
            };
            if(ModelState.IsValid)
            {
                var userCreate=await _userManager.CreateAsync(user, model.Password);
                if (userCreate.Succeeded) {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in userCreate.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            
            return View(model);
        }
        
    }
}
