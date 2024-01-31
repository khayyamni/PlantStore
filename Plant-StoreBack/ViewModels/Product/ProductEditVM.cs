﻿using Plant_StoreBack.Models;
using System.ComponentModel.DataAnnotations;

namespace Plant_StoreBack.ViewModels.Product
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
