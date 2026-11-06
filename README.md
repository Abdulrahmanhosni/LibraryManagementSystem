Library Management System

A console-based library management system built with .NET 10, Entity Framework Core, and SQL Server. Demonstrates Code-First approach, entity configuration, database migrations, and seed data.

Tech Stack
	
Runtime	.NET 10
ORM	Entity Framework Core 10 (Code-First)
Database	SQL Server
Configuration	appsettings.json
Features
Code-First database design with EF Core Migrations
Separate IEntityTypeConfiguration per entity
Many-to-Many relationship between Book and Category
Automatic migration on startup
Seed data via DbSeeder
Clean error handling for connection and database errors
Project Structure
LibraryManagementSystem/
├── Configurations/
│   ├── AuthorConfig.cs
│   ├── BookConfig.cs
│   ├── CategoryConfig.cs
│   ├── LoanConfig.cs
│   └── MemberConfig.cs
├── Data/
│   ├── DbSeeder.cs
│   ├── DbSettings.cs
│   ├── LibraryDbContext.cs
│   └── LibraryDbContextFactory.cs
├── Migrations/
├── Models/
│   ├── Author.cs
│   ├── Book.cs
│   ├── Category.cs
│   ├── Loan.cs
│   └── Member.cs
├── Program.cs
└── appsettings.example.json
Relationships
Author → Book : One-to-Many
Book ↔ Category : Many-to-Many
Book → Loan : One-to-Many
Member → Loan : One-to-Many
Getting Started
Prerequisites
.NET 10 SDK
SQL Server (local or remote)
EF Core CLI: dotnet tool install --global dotnet-ef
Setup

1. Clone the repository

bash
git clone https://github.com/Abdulrahmanhosni/LibraryManagementSystem.git
cd LibraryManagementSystem

2. Configure your connection string

Copy appsettings.example.json and create appsettings.json:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

3. Run the project

bash
dotnet run --project LibraryManagementSystem/LibraryManagementSystem.csproj

Migrations are applied automatically on startup. Seed data is inserted if the database is empty.

Manual Migrations
bash
dotnet ef database update --project LibraryManagementSystem/LibraryManagementSystem.csproj
Security Note

appsettings.json is excluded from source control via .gitignore. Use appsettings.example.json as a template.
