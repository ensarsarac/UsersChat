using System.ComponentModel.DataAnnotations;

namespace UsersChat.Data.Entities
{
    public class UserMessage
    {
        [Key]
        public int UserMessageID { get; set; }
        public int SenderUserID { get; set; }
        public AppUser SenderUser { get; set; }
        public int ReceiveUserID { get; set; }
        public AppUser ReceiverUser { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
        public bool IsImportant { get; set; }
        public bool IsTrash { get; set; }
        public List<Important> Importants { get; set; }
        public List<Trash> Trashs{ get; set; }
    }
}
