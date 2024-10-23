This project is built using **.NET 6** and follows the principles of **Clean Architecture** to ensure a scalable and maintainable solution. The project uses several design patterns and practices, including the Mediator pattern for handling complex business logic, Unit of Work and Repository patterns for managing data access, and DTOs (Data Transfer Objects) to streamline data exchange between layers.

Key features:

**Mediator Pattern**: Decouples request handling from business logic by using CQRS (Command-Query Responsibility Segregation) for commands and queries.

**Unit of Work & Repository Patter**n: Implements a clean, abstract data access layer to centralize database operations, ensuring consistency across multiple operations.

**Clean Architecture**: Organizes code into distinct layers, enforcing clear boundaries between business logic, infrastructure, and user interfaces.

**Middlewares**: Custom middlewares are used to handle cross-cutting concerns such as error handling, logging, and authentication.

**DTOs**: Simplify data transfer between API and application layers, ensuring separation of concerns.

Technologies
**.NET 6 / C#**

**Mediator Pattern (CQRS)**

**Unit of Work & Repository Pattern**

**Clean Architecture**

**Custom Middlewares**

**DTOs**

Setup Instructions

Clone the repository.

Navigate to the project directory.

Build the project using the .NET CLI or Visual Studio.

Run migrations (if applicable) and start the application.
