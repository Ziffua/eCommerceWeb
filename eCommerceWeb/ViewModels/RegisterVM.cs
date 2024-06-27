using eCommerceWeb.Models;
using System.ComponentModel.DataAnnotations;
namespace eCommerceWeb.ViewModels

{
    public class RegisterVM
    {
        [Display(Name ="Ad ve Soyad")]
        [Required(ErrorMessage ="Lütfen İsim bilgisini giriniz")]
        public string FullName { get; set; }

        [Display(Name = "E-posta")]
        [Required(ErrorMessage ="E-posta bilgisi gereklidir")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Şifre (Tekrar)")]
        [Required(ErrorMessage ="Şifre doğrulama gereklidir")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public bool IsSeller { get; set; }

        [Display(Name ="Dükkanının İsmi")]
        public string? ShopName { get; set; }
        [Display(Name = "Kısaca dükkanını tanıt")]
        public string? ShopAbout { get; set; }
        [Display(Name = "Dükkan logosu")]
        public string? ShopPicture { get; set; }

    }
}
