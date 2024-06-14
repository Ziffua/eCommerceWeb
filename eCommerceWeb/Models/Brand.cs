using eCommerceWeb.Data.Base;

namespace eCommerceWeb.Models
{
    public class Brand:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        //Relations
        public List<Product>? Products { get; set; }

    }
}
