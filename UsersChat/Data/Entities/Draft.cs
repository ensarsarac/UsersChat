namespace UsersChat.Data.Entities
{
    public class Draft
    {
        public int DraftID { get; set; }
        public int SenderUserID { get; set; }
        public AppUser SenderUser { get; set; }
        public int ReceiveUserID { get; set; }
        public AppUser ReceiverUser { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
}
