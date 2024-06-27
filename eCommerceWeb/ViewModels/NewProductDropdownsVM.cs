using eCommerceWeb.Models;

namespace eCommerceWeb.ViewModels
{
    public class NewProductDropdownsVM
    {
        public List<Brand> Brands { get; set; }

        public NewProductDropdownsVM()
        {
            Brands = new List<Brand>();
        }
    }
}
