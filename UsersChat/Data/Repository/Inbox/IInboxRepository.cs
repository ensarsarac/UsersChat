using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Inbox
{
    public interface IInboxRepository
    {
        List<UserMessage> GetListByUserId(int id);
    }
}
