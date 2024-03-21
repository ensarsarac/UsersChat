namespace UsersChat.Data.Entities
{
	public class Trash
	{
        public int TrashID { get; set; }
        public int UserMessageID { get; set; }
        public UserMessage UserMessage { get; set; }
    }
}
