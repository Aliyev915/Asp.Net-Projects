using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Data.Entities;
using ProductWebApi.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public IMapper _mapper { get; }

        public CategoriesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("")]
        public ActionResult GetAll()
        {
            List<Category> categories = _context.Categories.ToList();
            var model = _mapper.Map<List<Category>>(categories);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public ActionResult GetDetail(int? Id)
        {
            if (Id == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            Category category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if (category == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });

            var model = category;
            return Ok(model);
        }
        [HttpPost("")]
        public ActionResult Create(CategoryPostDto productPostDto)
        {
            Category category = _mapper.Map<Category>(productPostDto);
            _context.Categories.Add(category);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int? Id,CategoryPostDto productPostDto)
        {
            if (Id == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            Category category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if (category == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });

            category = _mapper.Map<Category>(productPostDto);
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
            Category category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == Id);
            if (category == null) return NotFound(new
            {
                Code = 1404,
                Message = "Product Not Found!"
            });
            category.IsDeleted = true;
            _context.SaveChanges();
            return NoContent();
        }

    }
}
