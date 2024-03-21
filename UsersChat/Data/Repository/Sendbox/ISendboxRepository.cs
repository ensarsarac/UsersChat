using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Sendbox
{
    public interface ISendboxRepository
    {
        List<UserMessage> GetListByUserId(int id);
    }
}
