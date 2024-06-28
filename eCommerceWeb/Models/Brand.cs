using eCommerceWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class Brand:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Marka Adı")]
        [Required(ErrorMessage = "Ad kısmı eksik bırakılamaz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Marka adı 3-50 karakter arasında olmalıdır...")]
        public string Name { get; set; }

        [Display(Name = "Marka Hakkında")]
        public string? Description { get; set; }

        [Display(Name = "Marka Logosu")]
        [Required(ErrorMessage = "Bir Logo gereklidir")]
        public string LogoUrl { get; set; }

        //Relations
        public List<Product>? Products { get; set; }

    }
}
