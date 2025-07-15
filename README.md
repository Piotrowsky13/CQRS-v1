# Pakiet.A

A web application built with **ASP.NET 8**, implementing the **CQRS** pattern using **MediatR** for command and query separation. The project also utilizes **Entity Framework Core** for database access.

## Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- CQRS (Command Query Responsibility Segregation)
- Swagger for API documentation
- Docker Compose
- Unitest in xUnit and Moq

## First run (local)

- set Connection String in appsettings.json
- run "database-update" <- PM
- for migration run "dotnet ef migrations add Init --project . --startup-project ../Mariusz.Piotrowski" <- PowerShell from infractusture path C:\Users\USER\source\repos\Mariusz.Piotrowski\Mariusz.Piotrowski.Infrastructure>

## Docker run:
- run command "docker-compose up --build"
- check http://localhost:5181/swagger

## Swagger curls

curl -X 'POST' \
  'http://localhost:5181/api/categories' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "string"
}'

curl -X 'GET' \
  'http://localhost:5181/api/articles/stats' \
  -H 'accept: */*'
