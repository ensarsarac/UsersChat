using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.TrashRepo;
using UsersChat.Models;

namespace UsersChat.Controllers
{
	public class TrashController : Controller
	{
		private readonly ITrashRepository _rashRepository;
		private readonly UserManager<AppUser> _userManager;

		public TrashController(ITrashRepository rashRepository, UserManager<AppUser> userManager)
		{
			_rashRepository = rashRepository;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var currentUser =await _userManager.FindByNameAsync(User.Identity.Name);
			var values=_rashRepository.GetUserMessageIsTrashTrue(currentUser.Id);
			var result = values.Select(x => new TrashListViewModel()
			{
				Id=x.UserMessageID,
				Date=x.DateTime,
				SenderImageUrl=x.SenderUser.ImageUrl,
				SenderName=x.SenderUser.Name,
				Subject=x.Subject,
				SenderSurname = x.SenderUser.Surname,
				ReceiveName=x.ReceiverUser.Name,
				ReceiveSurname=x.ReceiverUser.Surname,
				ReceiveImageUrl=x.ReceiverUser.ImageUrl,

			}).ToList();
			return View(result);
		}

		public IActionResult TakeOutTrash(int id)
		{
			_rashRepository.ChangeIsTrashFalse(id);
			return RedirectToAction("Index");
		}

		public IActionResult RemoveMessage(int id)
		{
			_rashRepository.DeleteMessage(id);
			return RedirectToAction("Index");
		}
		
		
	}
}
