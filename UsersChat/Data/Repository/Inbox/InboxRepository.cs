using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Inbox
{
    public class InboxRepository : IInboxRepository
    {
        private readonly Context _context;

        public InboxRepository(Context context)
        {
            _context = context;
        }
        public List<UserMessage> GetListByUserId(int id)
        {
            var values = _context.UserMessages.Where(x=>x.ReceiveUserID == id && x.IsImportant==false && x.IsTrash==false).Include(x=>x.SenderUser).OrderByDescending(x=>x.DateTime).ToList();
            return values;
        }
    }
}
