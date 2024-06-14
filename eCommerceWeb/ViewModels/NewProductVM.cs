﻿using eCommerceWeb.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.ViewModels
{
    //This model is used to get and carry the data to create a new Product
    public class NewProductVM
    {
        [Key]
        public int id { get; set; }
        
        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name="Details")]
        [Required(ErrorMessage ="Detail info is required")]
        public string Details { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price info is required")]
        public double Price { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity info is required")]
        public int Quantity { get; set; }
        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "Product Image is required")]
        public string PictureUrl { get; set; }
        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Category is required")]
        public ProductCategory Category { get; set; }
        [Display(Name = "Select Brand")]
        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }
        [Display(Name = "Select Seller")]
        [Required(ErrorMessage = "Shor info is required")]
        public int SellerId { get; set; }
    }
}
