using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Sendbox
{
    public class SendboxRepository : ISendboxRepository
    {
        private readonly Context _context;

        public SendboxRepository(Context context)
        {
            _context = context;
        }
        public List<UserMessage> GetListByUserId(int id)
        {
            var values = _context.UserMessages.Where(x => x.SenderUserID == id && x.IsImportant==false && x.IsTrash==false).Include(x => x.ReceiverUser).OrderByDescending(x => x.DateTime).ToList();
            return values;
        }
    }
}
