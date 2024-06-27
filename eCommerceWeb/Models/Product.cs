using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Ürün İsmi")]
        public string Name { get; set; }
        [Display(Name = "Ürün detayları")]
        public string Details { get; set; }
        [Display(Name = "Fiyat")]
        public double Price { get; set; }
        [Display(Name = "Ürün Stoku")]
        public int Quantity { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string PictureUrl { get; set; }
        [Display(Name = "Kategori")]
        public ProductCategory Category { get; set; }
        [Display(Name = "Ürünün Görüntülenme Sayısı")]
        public int ViewCount { get; set; }
        
        //Relations
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

    }
}
