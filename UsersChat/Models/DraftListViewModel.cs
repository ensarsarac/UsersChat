using UsersChat.Data.Entities;

namespace UsersChat.Models
{
    public class DraftListViewModel
    {
        public int DraftID { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiveSurname{ get; set; }
        public string ReceiveEmail{ get; set; }
        public string ReceiveImage{ get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
}
