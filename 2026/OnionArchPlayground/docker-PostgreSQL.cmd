@echo off
docker rm -f my-postgres >nul 2>&1

docker run -d ^
  --name my-postgres ^
  -e POSTGRES_PASSWORD=32167 ^
  -e POSTGRES_USER=roma ^
  -e POSTGRES_DB=roma_db ^
  -p 5432:5432 ^
  -v d:\_POSTGRES_DATA_\:/var/lib/postgresql/data ^
  --restart unless-stopped ^
  postgres:16

docker logs -f my-postgres

echo === PostgreSQL is ready ===
pause
