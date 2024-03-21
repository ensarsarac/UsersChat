using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            EditProfileViewModel model = new EditProfileViewModel();
            model.Name = value.Name;
            model.Surname = value.Surname;
            model.UserName = value.UserName;
            model.Email = value.Email;
            model.ImageUrl = value.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditProfileViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);

                await model.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.UserName;
            if (model.Password != null)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                }
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("LogOut", "Login");
            }
            return View(model);
        }
    }
}
