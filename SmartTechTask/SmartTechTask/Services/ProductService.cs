using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartTechTask.Data;
using SmartTechTask.Helper;
using SmartTechTask.Models;
using SmartTechTask.Models.DTOs;
using SmartTechTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _product;


        public ProductService(ProductContext product)
        {
            _product = product;
        }

        public async Task AddProductAsync(Product product)
        {
                await _product.AddAsync(product);
                await _product.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            _product.Remove(_product.Product.Find(id));
            await _product.SaveChangesAsync();

        }

        public Task EditProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _product.Product.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            //  var pageIndex = new SqlParameter("@PageIndex", PageIndex);
            //  var PageSize = new SqlParameter("@pageSize", pageSize);
            //  var Search = new SqlParameter("@search",  search==null?"":search);
            //return await _product.Product.FromSqlRaw("GetProducts @PageIndex, @pageSize,@search", pageIndex, PageSize, Search).ToListAsync();
            return await _product.Product.ToListAsync();
        }
    }
}
