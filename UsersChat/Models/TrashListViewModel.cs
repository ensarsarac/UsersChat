namespace UsersChat.Models
{
	public class TrashListViewModel
	{
		public int Id { get; set; }
		public string SenderName { get; set; }
		public string SenderSurname { get; set; }
		public string SenderImageUrl { get; set; }
		public string ReceiveName { get; set; }
		public string ReceiveSurname { get; set; }
		public string ReceiveImageUrl { get; set; }
		public string Subject { get; set; }
		public DateTime Date { get; set; }
	}
}
