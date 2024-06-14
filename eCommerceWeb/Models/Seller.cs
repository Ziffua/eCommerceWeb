using eCommerceWeb.Data.Base;

namespace eCommerceWeb.Models
{
    public class Seller:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string PictureUrl { get; set; }

        //Relations
        public List<Product>? Products { get; set; } //Nullable to get free from the dependency to it while creating a new seller item
    }
}
