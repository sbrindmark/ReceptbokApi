using Microsoft.EntityFrameworkCore;
using ReceptbokApi.Models;

namespace ReceptbokApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Recipe>().HasData(
        new Recipe { Id = 1, Title = "Pannkakor", Image = "", Description = "Enkla och goda" },
        new Recipe { Id = 2, Title = "Köttbullar", Image = "", Description = "Runda" }
    );
}

    public DbSet<Recipe> Recipes { get; set; }
}