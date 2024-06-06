using Practice.Models;
using System.ComponentModel.DataAnnotations;

namespace Practice.ViewModels.Products
{
    public class ProductEditVM
    {        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price can't be empty")]
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> NewImages { get; set; }
        public List<ProductEditImageVM> ExistImages { get; set; }

    }
}
