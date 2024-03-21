using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.DraftRepo;
using UsersChat.Data.Repository.Message;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class ComposeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageRepository _messageRepository;
        private readonly IDraftRepository _draftRepository;

        public ComposeController(UserManager<AppUser> userManager, IMessageRepository messageRepository, IDraftRepository draftRepository)
        {
            _userManager = userManager;
            _messageRepository = messageRepository;
            _draftRepository = draftRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMessageViewModel model)
        {
            var fromUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var toUser = await _userManager.FindByEmailAsync(model.ToUser);

            UserMessage message = new UserMessage();
            message.SenderUserID = fromUser.Id;
            message.ReceiveUserID = toUser.Id;
            message.Subject = model.Subject;
            message.Content = model.Message;
            message.DateTime = DateTime.Now;
            message.Status = false;
            message.IsImportant = false;
            _messageRepository.AddMessage(message);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveDraft(SendMessageViewModel model)
        {
            var fromUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var toUser = await _userManager.FindByEmailAsync(model.ToUser);
            Draft message = new Draft();
            message.SenderUserID = fromUser.Id;
            message.ReceiveUserID = toUser.Id;
            message.Subject = model.Subject;
            message.Content = model.Message;
            message.DateTime = DateTime.Now;
            _draftRepository.AddDraft(message);
            return RedirectToAction("Index", "Draft");
        }
    }
}
