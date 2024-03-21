using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Message
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public void AddMessage(UserMessage message)
        {
            _context.UserMessages.Add(message);
            _context.SaveChanges();
        }

		public void ChangeIsImportantFalse(int id)
		{
			var value = _context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
			value.IsImportant = false;
			_context.SaveChanges();
		}

		public void ChangeIsImportantTrue(int id)
        {
            var value = _context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
            value.IsImportant = true;
            _context.SaveChanges();
        }

        public void ChangeStatusFalse(int id)
        {
            var value=_context.UserMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
            value.Status = true;
            _context.SaveChanges();
        }

        public UserMessage GetMessageById(int id)
        {
            var value = _context.UserMessages.Where(x=>x.UserMessageID == id).Include(y=>y.SenderUser).Include(z=>z.ReceiverUser).FirstOrDefault();
            return value;
        }
    }
}
