using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReceptbokApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "Pannkakor är som allra godast när de är tunna och frasiga. Här har du ett recept på pannkakor där du får precis det. Sätt guldkant på dagen med nygräddade pannkakor. Servera tillsammans med något sött eller salt.", "https://images.unsplash.com/photo-1587339144367-f1cacbecac82?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Pannkakor" },
                    { 2, "Köttbullar med gräddsås och kokt potatis är en klassisk husmansrätt som är populär hos hela familjen, alltid ett säkert kort! Servera med pressgurka och lingon.", "https://images.unsplash.com/photo-1600688685721-852c38f6e8a6?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Köttbullar med gräddsås, lingon och pressgurka" },
                    { 3, "Laxfilé i ugn med kokt potatis och en enkel romsås. Detta är världens godaste lax, både enligt vuxna och barn. Enkel och så uppskattad rätt!", "https://images.unsplash.com/photo-1560717845-968823efbee1?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Lax i ugn" },
                    { 4, "Hemgjord pizzadeg med torrjäst eller färsk jäst, vatten och mjöl. Enkelt och så gott att toppa med det du gillar bäst!", "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?q=80&w=1469&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Pizza" },
                    { 5, "Carnitas är mexikanska tacos där långbakad fläskkarré i ugn blir så mört så att det faller isär – perfekt för att äta tacos som i Mexiko. Servera hemgjord Crema Mexicana (syrad grädde) och andra goda tillbehör till carnitas för en autentisk och festlig tacoupplevelse.", "https://plus.unsplash.com/premium_photo-1661730329741-b3bf77019b39?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Carnitas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
