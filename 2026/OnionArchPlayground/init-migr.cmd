dotnet ef migrations add InitialCreate ^
  --project Infrastructure ^
  --startup-project WebAPI ^
  --context AppDbContext ^
  --output-dir Persistence/Migrations