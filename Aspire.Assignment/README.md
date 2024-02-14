![banner](assets/banner.png?raw=true)

# Aspire Marketplace App  - ASP.NET Core Boilerplate

Aspire Assignment App  is a  solution, built to demonstrate implementing base solution 

# What is CQRS?

CQRS stands for Command Query Responsibility Segregation. It is an Architectural Design Pattern that advocates segregating or grouping the methods based on how they impact the data and design them separately according to their requirements. CQRS helps segregate functionalities into two different models - Commands and Queries, there by creating a clear separation of concerns for each functionality.

# Technologies

* ASP.NET Core (.NET 6)
* Entity Framework Core (EFCore 6)
* MediatR for .NET 6
* Fluent Validation for .NET 6
* SQLite

# About the Boilerplate

This boilerplate is a perfect starter for developers looking to implement CQRS. It also helps beginners better understand the concept of CQRS and how its implemented, while keeping the code simple.

# What do you get?

1. Clean Architecture with well-defined layers for API, Persistence, Core, Contracts and Migrations
2. Implemented [UnitOfWork](https://referbruv.com/blog/posts/understanding-and-implementing-unitofwork-pattern-in-aspnet-core) with Generic Repository
3. Preconfigured Entity Framework Core migrations with SQLite
4. Segregated Commands and Queries with their Handlers
5. [Fluent Validation](https://referbruv.com/blog/posts/implementing-fluent-validation-in-aspnet-core-%28net-5%29-mvc) on the input model within the Command classes
6. Preconfigured Swagger UI

# Getting Started

To get started, follow the below steps:

1. Install .NET 6 SDK
2. Clone the Solution into your Local Directory
3. Navigate to the Marketplace.API directory
4. Run the solution

Read the complete article to learn more:

[Implementing CQRS using Mediator in ASP.NET Core](https://referbruv.com/blog/posts/implementing-cqrs-using-mediator-in-aspnet-core-explained)












