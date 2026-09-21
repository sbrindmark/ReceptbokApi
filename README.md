# Receptbok – Backend (API)

REST-API för receptboken, byggt med ASP.NET Web API och EF Core + SQLite. Hanterar recept (CRUD) och bilduppladdning.

Frontend-repo: https://github.com/sbrindmark/receptbok

## Teknik 
- [.NET 10 SDK](https://dotnet.microsoft.com/)

## Kom igång
```bash
git clone https://github.com/sbrindmark/ReceptbokApi.git
cd ReceptbokApi
dotnet run
```
API:t startar på `http://localhost:5148`. Databasen (SQLite) skapas automatiskt vid start – inga extra kommandon behövs. Swagger finns på `http://localhost:5148/swagger`.

## Endpoints
- `GET /api/recipes` – lista alla recept
- `POST /api/recipes` – skapa ett recept
- `PUT /api/recipes/{id}` – uppdatera ett recept
- `DELETE /api/recipes/{id}` – ta bort ett recept
- `POST /api/recipes/upload` – ladda upp en bild, returnerar en URL

## Tekniska val
- **Controller-baserat Web API:** endpoints ligger i en `RecipesController`, vilket ger tydlig och lättläst struktur.
- **EF Core + SQLite:** filbaserad databas utan egen server – enkel att klona och köra lokalt. Migrations körs automatiskt vid start (`Database.Migrate()`), så databasen skapas och seedas utan extra steg.
- **DTO (`RecipeDto`):** POST/PUT tar emot en DTO utan `Id`, så klienten aldrig kan sätta interna fält – servern äger `Id`.
- **CORS med specifik origin:** endast frontend (`http://localhost:5173`) tillåts anropa API:t, i stället för att öppna för alla.
- **Bilduppladdning:** filer tas emot som `IFormFile`, sparas med unikt filnamn i `wwwroot/uploads`, och serveras som statiska filer via en URL.