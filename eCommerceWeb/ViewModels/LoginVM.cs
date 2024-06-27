using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="E-posta adresi")]
        [Required(ErrorMessage ="E-posta adresi bilgisi eksik veya hatalı")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
