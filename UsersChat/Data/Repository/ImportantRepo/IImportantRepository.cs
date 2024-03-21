using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.ImportantRepo
{
    public interface IImportantRepository
    {
        void MessageIsImportantChangeTrue(int id);
        void MessageIsImportantChangeFalse(int id);
        List<UserMessage> GetListByImportant(int userId);
    }
}
