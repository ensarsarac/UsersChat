using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.Message
{
    public interface IMessageRepository
    {
        void AddMessage(UserMessage message);
        UserMessage GetMessageById(int id);
        void ChangeStatusFalse(int id);
        void ChangeIsImportantTrue(int id);
        void ChangeIsImportantFalse(int id);
    }
}
