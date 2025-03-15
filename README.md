📜 Ticket Management System - Backend
This is the backend API for the Ticket Management System, built using .NET 8 following Clean Architecture (Jason Taylor's Template).

📌 Prerequisites
Before running the project, ensure you have installed:

.NET 8 SDK

SQL Server (or use Azure SQL)

EF Core CLI (if not installed, run):

sh
dotnet tool install --global dotnet-ef
🚀 Setup & Running the Project
1️⃣ Configure the Database Connection
Open appsettings.json (or appsettings.Development.json).

Update the DefaultConnection string with your SQL Server instance:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TicketManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
}

2️⃣ Apply Database Migrations
Run the following commands to apply migrations and update the database:

sh
dotnet ef migrations add "Seeding" --project src/Infrastructure --startup-project src/WebUI --output-dir Persistence/Migrations

dotnet ef database update --project src/Infrastructure --startup-project src/WebUI

3️⃣ Run the Project
To start the application, navigate to the WebUI project and run:

sh
dotnet run --project src/WebUI
The API will be available at http://localhost:5000 (or another configured port).

🧪 Running Tests
To execute unit and integration tests, run:

sh
dotnet test
📂 Project Structure
bash

📦 TicketManagementSystem
 ┣ 📂 src
 ┃ ┣ 📂 Application      # Business logic (CQRS, DTOs, Validation)
 ┃ ┣ 📂 Domain           # Entities, Enums, Aggregates
 ┃ ┣ 📂 Infrastructure   # Database, Repository, External Services
 ┃ ┣ 📂 WebUI            # API Controllers, Middleware, Authentication
 ┣ 📂 tests              # Unit & Integration Tests
 ┗ 📄 README.md
📌 Additional Notes
The project follows Clean Architecture principles with CQRS and MediatR.
Ensure SQL Server is running before executing migrations.
Use appsettings.Development.json for local environment configuration.
