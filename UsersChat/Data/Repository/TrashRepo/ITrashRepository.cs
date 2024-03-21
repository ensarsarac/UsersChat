using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.TrashRepo
{
	public interface ITrashRepository
	{
		void ChangeIsTrashFalse(int id);
		void ChangeIsTrashTrue(int id);
		void DeleteMessage(int id);
		List<UserMessage> GetUserMessageIsTrashTrue(int userId);

	}
}
