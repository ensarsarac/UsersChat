namespace UsersChat.Models
{
    public class InboxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; }
    }
}
