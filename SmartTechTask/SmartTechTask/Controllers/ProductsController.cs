using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTechTask.ActionFilters;
using SmartTechTask.Helper;
using SmartTechTask.Models;
using SmartTechTask.Models.DTOs;
using SmartTechTask.Services.Interfaces;

namespace SmartTechTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUploadServive _upload;

        public ProductsController(IProductService productService, IMapper mapper, IUploadServive upload)
        {
            _mapper = mapper;
            _productService = productService;
            _upload = upload;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProductsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            await _productService.DeleteProductAsync(id);
            return Ok(new
            {
                Sucess = true,
                Message = "Product Deleted sucessfully"
            });


        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto product)
        {
            await _productService.AddProductAsync(_mapper.Map<Product>(product));
            return Ok(new
            {
                Sucess = true,
                Message = "Product saved sucessfully"
            });
        }
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            await _upload.Upload(file);
            return Ok(new
            {
                Sucess = true,
                Message = "Saved Successfully"
            });

        }


    }
}