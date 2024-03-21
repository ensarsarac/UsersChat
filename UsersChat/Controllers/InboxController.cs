using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.ImportantRepo;
using UsersChat.Data.Repository.Inbox;
using UsersChat.Data.Repository.Message;
using UsersChat.Data.Repository.TrashRepo;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class InboxController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IInboxRepository _inboxRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ITrashRepository _trashRepository;

		public InboxController(UserManager<AppUser> userManager, IInboxRepository inboxRepository, IMessageRepository messageRepository, ITrashRepository trashRepository)
		{
			_userManager = userManager;
			_inboxRepository = inboxRepository;
			_messageRepository = messageRepository;
			_trashRepository = trashRepository;
		}

		public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _inboxRepository.GetListByUserId(currentUser.Id);
            var results = values.Select(x => new InboxViewModel()
            {
                Subject = x.Subject,
                Date = x.DateTime,
                Message = x.Content,
                Name = x.SenderUser.Name,
                Surname = x.SenderUser.Surname,
                Status = x.Status,
                ImageUrl = x.SenderUser.ImageUrl,
                Id = x.UserMessageID,
            }).ToList();
            return View(results);
        }
        
        public IActionResult ReadMail(int id)
        {
            _messageRepository.ChangeStatusFalse(id);
            var value = _messageRepository.GetMessageById(id);
            MessageDetailsViewModel model = new MessageDetailsViewModel()
            {
                Date=value.DateTime,
                Email=value.SenderUser.Email,
                Id = id,
                Message=value.Content,
                Name=value.SenderUser.Name,
                Subject=value.Subject,
                Surname = value.SenderUser.Surname
            };
            return View(model);
        }
        public IActionResult IsTrashTrue(int id)
        {
            _trashRepository.ChangeIsTrashTrue(id);
            return RedirectToAction("Index");
        }
       

    }
}
