using eCommerceWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class Brand:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Marka İsmi")]
        public string Name { get; set; }
        [Display(Name = "Marka Hakkında")]
        public string Description { get; set; }
        [Display(Name = "Marka Logosu")]
        public string LogoUrl { get; set; }
        //Relations
        public List<Product>? Products { get; set; }

    }
}
