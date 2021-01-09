using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace asp_net_Project_WSEI.Models
{
    
    public class Product
    {
        
        public int PID { get; set; }
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Please insert correct price")]
        [Display(Name = "Product label")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "Category")]
        public string ProductCategory { get; set; }
    }
}