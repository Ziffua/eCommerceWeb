using eCommerceWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class Shop:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Dükkan Adı")]
        public string Name { get; set; }
        [Display(Name = "Hakkında")]
        public string About { get; set; }
        [Display(Name="Dükkan resmi")]
        public string PictureUrl { get; set; }

        //Relations
        public List<Product>? Products { get; set; } //Nullable to get free from the dependency to it while creating a new shop item
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
