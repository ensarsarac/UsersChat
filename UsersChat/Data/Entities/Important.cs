namespace UsersChat.Data.Entities
{
    public class Important
    {
        public int ImportantID { get; set; }
        public int UserMessageID { get; set; }
        public UserMessage UserMessage { get; set; }
    }
}
