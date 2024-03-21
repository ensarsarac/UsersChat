using Microsoft.AspNetCore.Identity;

namespace UsersChat.Data.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<UserMessage> SenderUsers{ get; set; }
        public List<UserMessage> ReceiverUsers { get; set; }

        public List<Draft> SenderUsersDraft { get; set; }
        public List<Draft> ReceiverUsersDraft { get; set; }
    }
}
