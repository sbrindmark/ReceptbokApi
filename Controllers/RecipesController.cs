using Microsoft.AspNetCore.Mvc;
using ReceptbokApi.Models;

namespace ReceptbokApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private static readonly List<Recipe> _recipes = new()
    {
        new Recipe {Id = 1, Title = "Pannkakor", Image = "", Description = "Enkla och goda"},
        new Recipe {Id = 2, Title = "Köttbullar", Image = "", Description = "Runda"},
    };

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAll()
    {
        return _recipes;
    }

    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
    {
        newRecipe.Id = _recipes.Count == 0 ? 1 : _recipes.Max(r => r.Id) + 1;
        _recipes.Add(newRecipe);
        return Ok(newRecipe);
    }

    [HttpPut("{id}")]
    public ActionResult<Recipe> Update(int id, [FromBody] Recipe updateRecipe)
    {
        var existing = _recipes.FirstOrDefault(r => r.Id == id);
        if (existing == null) return NotFound();
        existing.Title = updateRecipe.Title;
        existing.Image = updateRecipe.Image;
        existing.Description = updateRecipe.Description;
        return Ok(existing);
    }
}