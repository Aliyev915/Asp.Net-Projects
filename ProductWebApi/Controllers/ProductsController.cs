using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Data.Entities;
using ProductWebApi.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductsController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult GetAll(int page = 1)
        {
            List<ProductListDto> products = _context.Products.Where(x=>!x.IsDeleted)
                .Skip((page-1)*5).Take(5)
                .Include(x => x.Category).Select(x=> new ProductListDto { 
                Name = x.Name,
                SalePrice = x.SalePrice,
                CostPrice = x.CostPrice,
                CategoryName = x.Category.Name,
                Count = _context.Products.Count()
            }).ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult GetDetail(int? Id)
        {
            if (Id == null) return NotFound(new { 
                Code = 1404,
                Message = "Product Not Found!"
            });
            Product product = _context.Products.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if(product==null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });

            var model = _mapper.Map<ProductDetailDto>(product);
            return Ok(model);
        }
        [HttpPost("")]
        public ActionResult Create(ProductPostDto productPostDto)
        {
            Product product = _mapper.Map<Product>(productPostDto);
            _context.Products.Add(product);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int? Id,ProductPostDto productPostDto)
        {
            if (Id == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            Product product = _context.Products.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if (product == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });

            product = _mapper.Map<Product>(productPostDto);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            Product product = _context.Products.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if (product == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            product.IsDeleted = true;
            _context.SaveChanges();
            return NoContent();
        }

    }
}
