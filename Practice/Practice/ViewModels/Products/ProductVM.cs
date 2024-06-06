﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practice.ViewModels.Products
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
