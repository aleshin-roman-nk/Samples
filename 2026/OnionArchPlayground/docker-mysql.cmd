@echo off
docker rm -f my-mysql >nul 2>&1

docker run -d ^
  --name my-mysql ^
  -e MYSQL_ROOT_PASSWORD=32167 ^
  -e MYSQL_DATABASE=myappdb ^
  -e MYSQL_USER=myuser ^
  -e MYSQL_PASSWORD=32167 ^
  -p 3306:3306 ^
  -v d:\_MYSQL_DATA_\:/var/lib/mysql ^
  --restart unless-stopped ^
  mysql:8.0

docker logs -f my-mysql

echo === MySQL is ready ===
pause