using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.ImportantRepo
{
    public class ImportantRepository : IImportantRepository
    {
        private readonly Context _context;

        public ImportantRepository(Context context)
        {
            _context = context;
        }

        public List<UserMessage> GetListByImportant(int userId)
        {
            var values = _context.UserMessages.Where(x=>x.IsImportant==true && (x.SenderUserID==userId || x.ReceiveUserID == userId)).Include(z=>z.SenderUser).Include(z=>z.ReceiverUser).ToList();
            return values;
        }

		public void MessageIsImportantChangeFalse(int id)
		{
			var value = _context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
			value.IsImportant = false;
			_context.SaveChanges();
		}

		public void MessageIsImportantChangeTrue(int id)
        {
            var value=_context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
            value.IsImportant = true;
            _context.SaveChanges();
        }
    }
}
