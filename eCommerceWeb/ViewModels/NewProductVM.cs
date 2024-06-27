using eCommerceWeb.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.ViewModels
{
    //This model is used to get and carry the data to create a new Product
    public class NewProductVM
    {
        [Key]
        public int id { get; set; }
        
        [Display(Name = "Ürün İsmi")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name= "Ürün detayları")]
        [Required(ErrorMessage ="Detail info is required")]
        public string Details { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Price info is required")]
        public double Price { get; set; }
        [Display(Name = "Ürün Stoku")]
        [Required(ErrorMessage = "Quantity info is required")]
        public int Quantity { get; set; }
        [Display(Name = "Ürün Resmi")]
        [Required(ErrorMessage = "Product Image is required")]
        public string PictureUrl { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Category is required")]
        public ProductCategory Category { get; set; }
        [Display(Name = "Marka")]
        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }
        [Display(Name = "Dükkan")]
        [Required(ErrorMessage = "Shor info is required")]
        public int ShopId { get; set; }
    }
}
