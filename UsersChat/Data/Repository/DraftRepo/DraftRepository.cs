using Microsoft.EntityFrameworkCore;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.DraftRepo
{
    public class DraftRepository : IDraftRepository
    {
        private readonly Context _context;

        public DraftRepository(Context context)
        {
            _context = context;
        }

        public void AddDraft(Draft draft)
        {
            _context.Drafts.Add(draft);
            _context.SaveChanges();
        }

        public Draft GetDraftById(int id)
        {
            var values = _context.Drafts.Where(x => x.DraftID == id).Include(y => y.ReceiverUser).FirstOrDefault();
            return values;
        }

        public List<Draft> GetDraftList(int id)
        {
            var values = _context.Drafts.Where(x=>x.SenderUserID == id).Include(y=>y.ReceiverUser).ToList();
            return values;
        }

        public void RemoveDraft(int id)
        {
            var value = _context.Drafts.Where(x=>x.DraftID==id).FirstOrDefault();
            _context.Drafts.Remove(value);
            _context.SaveChanges();
        }
    }
}
