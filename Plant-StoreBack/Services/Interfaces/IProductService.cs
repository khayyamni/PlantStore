﻿using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);

    }
}