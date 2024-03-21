using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.ImportantRepo;
using UsersChat.Data.Repository.Message;
using UsersChat.Models;

namespace UsersChat.Controllers
{
    public class ImportantController : Controller
    {
        private readonly IImportantRepository _importantRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<AppUser> _userManager;

        public ImportantController(IImportantRepository importantRepository, IMessageRepository messageRepository, UserManager<AppUser> userManager)
        {
            _importantRepository = importantRepository;
            _messageRepository = messageRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _importantRepository.GetListByImportant(currentUser.Id);
            var result = values.Select(x => new ImportantListViewModel()
            {
                Id = x.UserMessageID,
                ReceiveName = x.ReceiverUser.Name,
                ReceiveSurname = x.ReceiverUser.Surname,
                Date = x.DateTime,
                ReceiveImageUrl = x.ReceiverUser.ImageUrl,
                Subject = x.Subject,
                SenderName= x.SenderUser.Name,
				SenderSurname = x.SenderUser.Surname,
				SenderImageUrl = x.SenderUser.ImageUrl,
			}).ToList();
            return View(result);
        }

        public IActionResult ChangeIsImportantTrue(int id)
        {
            _importantRepository.MessageIsImportantChangeTrue(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult RemoveImportant(int id)
        {
            _importantRepository.MessageIsImportantChangeFalse(id);
            return RedirectToAction("Index");
        }

	}
}
