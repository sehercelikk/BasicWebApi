using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnekWebApi.Dto;
using OrnekWebApi.Models;

namespace OrnekWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static DataContext _context;

    public ProductsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _context.Products
        .Where(a => a.IsActive == true)
        .Select(p => ProductToDto(p)).ToListAsync();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int? id)
    {
        if (id == null)
            return StatusCode(404, "Aradığınız Kayıt Bulunamadı");
        var result = await _context.Products
        .Where(a => a.Id == id)
        .Select(p => ProductToDto(p))
        .FirstOrDefaultAsync();
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        var kontrol = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
        if (kontrol == null)
            return NotFound();
        kontrol.IsActive = product.IsActive;
        kontrol.Price = product.Price;
        kontrol.ProductName = product.ProductName;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return NotFound();
        }
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
        if (result == null && id == null)
        {
            return NotFound();
        }
        _context.Products.Remove(result);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private static ProductDto ProductToDto(Product p)
    {
        var entity = new ProductDto();
        if (p != null)
        {
            entity.Id = p.Id;
            entity.Price = p.Price;
            entity.ProductName = p.ProductName;
        }
        return entity;
    }
}