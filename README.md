🛒 Simple Clean Architecture Shop API

A Clean Architecture shop project built with .NET 9, implementing CQRS and Mediator patterns.
It includes role-based permission management, and Redis caching is used to speed up permission and role lookups.

###  📦 Features

-  Clean Architecture structure

-  CQRS + Mediator patterns

-  Role-based permissions

-  Redis caching for permissions and roles

-  SQL Server database

-  Dockerized for easy setup

###  🐳 Running with Docker

1.Copy .env.example to .env in the Shop.Api folder.

2.Update configuration values in .env (SQL Server connection string, Redis settings, etc.).

3.In the project root, run:

docker compose up --build

4.Open your browser and type http://localhost:8080

Happy coding and enjoy exploring the project! 😄✨
