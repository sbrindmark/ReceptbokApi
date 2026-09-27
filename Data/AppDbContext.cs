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
        new Recipe { Id = 1, Title = "Pannkakor", Image = "https://images.unsplash.com/photo-1587339144367-f1cacbecac82?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Description = "Pannkakor är som allra godast när de är tunna och frasiga. Här har du ett recept på pannkakor där du får precis det. Sätt guldkant på dagen med nygräddade pannkakor. Servera tillsammans med något sött eller salt." },
        new Recipe { Id = 2, Title = "Köttbullar med gräddsås, lingon och pressgurka", Image = "https://images.unsplash.com/photo-1600688685721-852c38f6e8a6?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Description = "Köttbullar med gräddsås och kokt potatis är en klassisk husmansrätt som är populär hos hela familjen, alltid ett säkert kort! Servera med pressgurka och lingon." },
        new Recipe { Id = 3, Title = "Lax i ugn", Image = "https://images.unsplash.com/photo-1560717845-968823efbee1?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Description = "Laxfilé i ugn med kokt potatis och en enkel romsås. Detta är världens godaste lax, både enligt vuxna och barn. Enkel och så uppskattad rätt!" },
        new Recipe { Id = 4, Title = "Pizza", Image = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?q=80&w=1469&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Description = "Hemgjord pizzadeg med torrjäst eller färsk jäst, vatten och mjöl. Enkelt och så gott att toppa med det du gillar bäst!" },
        new Recipe { Id = 5, Title = "Carnitas", Image = "https://plus.unsplash.com/premium_photo-1661730329741-b3bf77019b39?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Description = "Carnitas är mexikanska tacos där långbakad fläskkarré i ugn blir så mört så att det faller isär – perfekt för att äta tacos som i Mexiko. Servera hemgjord Crema Mexicana (syrad grädde) och andra goda tillbehör till carnitas för en autentisk och festlig tacoupplevelse." }
    );
}

    public DbSet<Recipe> Recipes { get; set; }
}