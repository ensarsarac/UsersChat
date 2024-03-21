using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Models;

namespace UsersChat.ViewComponents
{
    public class _SideBarComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _SideBarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            CurrentUserViewModel model = new CurrentUserViewModel()
            {
                Name = user.Name,
                ImageUrl = user.ImageUrl,
                Surname=user.Surname,
            };
            return View(model);
        }
    }
}
