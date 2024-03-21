using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.TrashRepo
{
	public class TrashRepository : ITrashRepository
	{
		private readonly Context _context;

		public TrashRepository(Context context)
		{
			_context = context;
		}

		public void ChangeIsTrashFalse(int id)
		{
			var value=_context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
			value.IsTrash = false;
			_context.SaveChanges();
		}

		public void ChangeIsTrashTrue(int id)
		{
			var value = _context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
			value.IsTrash = true;
			_context.SaveChanges();
		}

		public void DeleteMessage(int id)
		{
			_context.UserMessages.Remove(_context.UserMessages.Find(id));
			_context.SaveChanges();
		}

		public List<UserMessage> GetUserMessageIsTrashTrue(int userId)
		{
			var values = _context.UserMessages.Where(x=>(x.ReceiveUserID == userId || x.SenderUserID==userId) && x.IsTrash==true && x.IsImportant==false).Include(z=>z.SenderUser).Include(x=>x.ReceiverUser).ToList();
			return values;
		}
	}
}
