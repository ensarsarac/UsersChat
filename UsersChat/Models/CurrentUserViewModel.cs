using System.ComponentModel.DataAnnotations;

namespace UsersChat.Models
{
    public class CurrentUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}
