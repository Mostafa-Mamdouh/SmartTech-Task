using Microsoft.AspNetCore.Http;
using SmartTechTask.Models;
using SmartTechTask.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Services.Interfaces
{
   public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task EditProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
