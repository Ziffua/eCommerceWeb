using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Enums;

namespace eCommerceWeb.Models
{
    public class Product:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public ProductCategory Category { get; set; }
        
        //Relations
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

    }
}
