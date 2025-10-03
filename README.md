# Employee Management System
A simple ASP.NET Core Razor Pages application for managing employee records with full CRUD (Create, Read, Update, Delete) operations using an in-memory database.

## Features
* ✅ Add new employees with name and age
* 📋 View all employees in a clean table format
* ✏️ Edit existing employee information
* 🗑️ Delete employees with confirmation dialog
* 💾 In-memory database for easy testing and development
* 🎨 Bootstrap UI for responsive and modern design

## Technology Stack
* ASP.NET Core 8.0 - Web framework
* Razor Pages - UI framework
* Entity Framework Core 9.0 - ORM
* In-Memory Database - Data storage
* Bootstrap 5 - UI styling

## Project Structure
        text
        ASP_Razor/
        ├── Pages/
        │   └── Employee.cshtml          # Razor page (UI)
        │   └── Employee.cshtml.cs       # Page model (backend logic)
        ├── Models/
        │   └── Employee.cs              # Employee data model
        ├── Data/
        │   └── AppDbContext.cs          # Database context
        └── Program.cs                   # Application startup
## Data Model
### Employee Class
        csharp
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
## Setup and Installation
1. Prerequisites
* .NET 8.0 SDK
* Visual Studio 2022 or VS Code

2. Clone and Build

        bash
        git clone https://github.com/thetnaing-dh/Employee_Management_System
        cd ASP_Razor
        dotnet build
3. Run the Application

        bash
        dotnet run
The application will be available at https://localhost:7000 (or similar port)

## Usage
### Adding an Employee
1. Navigate to the Employees page
2. Fill in the Name and Age fields
3. Click the "Add" button

### Editing an Employee
1. Click the "Edit" button next to any employee
2. Modify the name and/or age in the form
3. Click "Update" to save changes or "Cancel" to discard

### Deleting an Employee
1. Click the "Delete" button next to any employee
2. Confirm the deletion in the dialog box

### Database Configuration
The application uses Entity Framework Core with an in-memory database:

        csharp
        public class AppDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MyEmployeeDB");
            }
        
            public DbSet<Employee> Employees { get; set; }
        }
Note: The in-memory database is reset when the application restarts. For production use, consider switching to a persistent database like SQL Server, SQLite, or PostgreSQL.

## API Endpoints
The application provides the following HTTP handlers:
* OnGet() - Loads the employee list
* OnPostAdd() - Adds a new employee
* OnPostEdit(int id) - Loads employee data for editing
* OnPostUpdate() - Updates an existing employee
* OnPostDelete(int id) - Deletes an employee
* OnPostCancel() - Cancels edit mode

## Dependencies
* Microsoft.EntityFrameworkCore (9.0.9)
* Microsoft.EntityFrameworkCore.InMemory (9.0.9)

## Development
### Adding New Features
1. Update the Employee model for new properties
2. Modify the Employee.cshtml for UI changes
3. Update the EmployeeModel class for business logic
4. Run database migrations if using a persistent database

### Testing
The in-memory database makes testing easy as data is isolated per application instance and reset on restart.

## Deployment
For production deployment:
1. Replace the in-memory database with a persistent database
2. Update connection strings in configuration
3. Run database migrations
4. Deploy to Azure App Service, IIS, or other hosting platforms

## Contributing
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License
This project is open source and available under the MIT License.
