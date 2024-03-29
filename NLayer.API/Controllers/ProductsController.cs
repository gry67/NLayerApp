﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }





        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            //products'ları list of ProductDto'ya çevir. Yani client'a göndermek için sadeleştir.
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomReponseDto<List<ProductDto>>.Success(200,productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            //products'ları list of ProductDto'ya çevir. Yani client'a göndermek için sadeleştir.
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomReponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));

            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomReponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomReponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);

            return CreateActionResult(CustomReponseDto<NoContentDto>.Success(204));
        }

    }

}
