using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptbokApi.Data;
using ReceptbokApi.Models;

namespace ReceptbokApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly AppDbContext _context;
    public RecipesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
    {
        return await _context.Recipes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> Create([FromBody] RecipeDto dto)
    {
        var recipe = new Recipe
        {
            Title = dto.Title,
            Image = dto.Image,
            Description = dto.Description,
        };

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

    return Ok(recipe);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Recipe>> Update(int id, [FromBody] RecipeDto dto)
    {
        var existing = await _context.Recipes.FindAsync(id);
        if (existing == null) return NotFound();
        existing.Title = dto.Title;
        existing.Image = dto.Image;
        existing.Description = dto.Description;
        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.Recipes.FindAsync(id);
        if (existing == null) return NotFound();

        _context.Recipes.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("upload")]
    public async Task<ActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Ingen fil vald");

        var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsDir);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsDir, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var url = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
        return Ok(new { url });
    }
}