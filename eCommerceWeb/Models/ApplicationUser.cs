using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Ad ve Soyad")]
        public string FullName { get; set; }
        public Shop? Shop { get; set; }
    }
}
