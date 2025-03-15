# TicketSystem

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/TicketSystem) version 8.0.6.

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Help
To learn more about the template go to the [project website](https://github.com/jasontaylordev/CleanArchitecture). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.

## 🚀 Steps to Setup & Running the Project

1️⃣ Configure the Database Connection
Open appsettings.json (do the same for appsettings.Development.json).

Update the DefaultConnection string with your SQL Server instance:

json
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TicketManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
}
```

2️⃣ Apply Database Migrations
Run the following commands to apply migrations and update the database:

```bash
dotnet ef migrations add "Seeding" --project src/Infrastructure --startup-project src/WebUI --output-dir Persistence/Migrations

dotnet ef database update --project src/Infrastructure --startup-project src/WebUI
```

3️⃣ Run the Project
To start the application, navigate to the WebUI project and run:

```bash
dotnet run --project src/WebUI
```

The API will be available at http://localhost:5000 (or another configured port).

🧪 Running Tests
To execute unit and integration tests, run:

```bash
dotnet test
```
