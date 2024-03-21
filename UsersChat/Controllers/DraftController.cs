using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.DraftRepo;
using UsersChat.Data.Repository.Message;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class DraftController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDraftRepository _draftRepository;
        private readonly IMessageRepository _messageRepository;

        public DraftController(UserManager<AppUser> userManager, IDraftRepository draftRepository, IMessageRepository messageRepository)
        {
            _userManager = userManager;
            _draftRepository = draftRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _draftRepository.GetDraftList(currentUser.Id);
            var result = values.Select(x => new DraftListViewModel()
            {
                Content = x.Content,
                DateTime = DateTime.Now,
                DraftID = x.DraftID,
                ReceiveEmail = x.ReceiverUser.Email,
                ReceiveImage = x.ReceiverUser.ImageUrl,
                ReceiveName = x.ReceiverUser.Name,
                ReceiveSurname = x.ReceiverUser.Surname,
                Subject = x.Subject,
            }).ToList();
            return View(result);
        }
        public async Task<IActionResult> SendDraft(int id)
        {
            var x = _draftRepository.GetDraftById(id);
            TempData["id"] = id;
            DraftListViewModel model = new DraftListViewModel()
            {
                Content = x.Content,
                DateTime = DateTime.Now,
                DraftID = x.DraftID,
                ReceiveEmail = x.ReceiverUser.Email,
                ReceiveImage = x.ReceiverUser.ImageUrl,
                ReceiveName = x.ReceiverUser.Name,
                ReceiveSurname = x.ReceiverUser.Surname,
                Subject = x.Subject,
            };
            MessageAndDraftViewModel viewModel = new MessageAndDraftViewModel()
            {
                DraftListViewModel = model,
                SendMessageViewModel = new SendMessageViewModel(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SendDraft(SendMessageViewModel model)
        {
            int mailId = (int)TempData["id"];
            _draftRepository.RemoveDraft(mailId);
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var fromUser = await _userManager.FindByEmailAsync(model.ToUser);
            UserMessage message = new UserMessage();
            message.Subject = model.Subject;
            message.Status = false;
            message.SenderUserID=currentUser.Id;
            message.Content = model.Message;
            message.ReceiveUserID =fromUser.Id;
            message.DateTime = DateTime.Now;
            _messageRepository.AddMessage(message);
            return RedirectToAction("Index");
        }
    }
}
