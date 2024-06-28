using eCommerceWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class Shop:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Dükkan Adı")]
        [Required(ErrorMessage = "Dükkan adı bilgisi eksik bırakılamaz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Dükkan Adı 3-50 karakter arasında olmalıdır...")]
        public string Name { get; set; }

        [Display(Name = "Hakkında")]
        public string? About { get; set; }

        [Display(Name="Dükkan resmi")]
        [Required(ErrorMessage = "Bir Dükkan resmi gereklidir")]
        public string PictureUrl { get; set; }


        //Relations
        public List<Product>? Products { get; set; } //Nullable to get free from the dependency to it while creating a new shop item
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
