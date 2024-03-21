using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.Message;
using UsersChat.Data.Repository.Sendbox;
using UsersChat.Data.Repository.TrashRepo;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class SendboxController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISendboxRepository _sendboxRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ITrashRepository _trashRepository;

        public SendboxController(UserManager<AppUser> userManager, ISendboxRepository sendboxRepository, IMessageRepository messageRepository, ITrashRepository trashRepository)
        {
            _userManager = userManager;
            _sendboxRepository = sendboxRepository;
            _messageRepository = messageRepository;
            _trashRepository = trashRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _sendboxRepository.GetListByUserId(currentUser.Id);
            var result = values.Select(x => new SendBoxViewModel()
            {
                Name=x.ReceiverUser.Name,
                Id=x.UserMessageID,
                Subject=x.Subject,
                Surname=x.ReceiverUser.Surname,
                ImageUrl=x.ReceiverUser.ImageUrl,
                Date = x.DateTime,
            }).ToList();
            return View(result);
        }
        public async Task<IActionResult> SendBoxViewMail(int id)
        {
            var value = _messageRepository.GetMessageById(id);
            MessageDetailsViewModel model = new MessageDetailsViewModel()
            {
                Date = value.DateTime,
                Email = value.ReceiverUser.Email,
                Id = id,
                Message = value.Content,
                Name = value.ReceiverUser.Name,
                Subject = value.Subject,
                Surname = value.ReceiverUser.Surname
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
