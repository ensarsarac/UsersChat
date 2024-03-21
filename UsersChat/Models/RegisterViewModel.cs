using System.ComponentModel.DataAnnotations;

namespace UsersChat.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Ad alanı boş bırakılamaz.")]
        [MinLength(3,ErrorMessage ="Lütfen en az 3 karakter giriniz.")]
        [MaxLength(50,ErrorMessage ="Lütfen en fazla 50 karakter giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "Lütfen en az 3 karakter giriniz.")]
        [MaxLength(50, ErrorMessage = "Lütfen en fazla 50 karakter giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "Lütfen en az 3 karakter giriniz.")]
        [MaxLength(50, ErrorMessage = "Lütfen en fazla 50 karakter giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage ="Email formatına uygun giriniz.")]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password{ get; set; }
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz.")]
        [Compare("Password", ErrorMessage ="Şifreler Uyuşmuyor..")]
        public string ConfirmPassword{ get; set; }
        public string? ImageUrl { get; set; }
    }
}
