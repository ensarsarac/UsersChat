using Microsoft.AspNetCore.Mvc;

namespace UsersChat.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
