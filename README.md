# Rowing Technique API

A RESTful API providing comprehensive rowing technique data including stroke phases, training workouts, technique drills, and injury prevention strategies.

## 🚀 Live Demo
(Swagger) https://rowing-api-aseher.azurewebsites.net/swagger

## 📋 Overview
This API serves as a technical resource for rowing coaches, athletes, and developers building rowing-related applications. Built using clean architecture principles with a focus on maintainability and scalability.

## 🛠️ Tech Stack
- **Framework:** ASP.NET Core 8.0
- **Database:** SQL Server (Azure SQL Database)
- **ORM:** Dapper (micro-ORM for performance)
- **Architecture:** Clean Architecture (Domain-Driven Design)
- **Documentation:** Swagger/OpenAPI
- **Cloud:** Azure App Service
- **IDE:** JetBrains Rider

## 🏗️ Architecture
```
├── Rowing.API              # Presentation Layer (Controllers, Program.cs)
├── Rowing.Application      # Application Layer (DTOs, Interfaces, Services)
├── Rowing.Domain          # Domain Layer (Entities, Core Business Logic)
└── Rowing.Infrastructure  # Infrastructure Layer (Data Access, External Services)
```

## 📚 API Endpoints

### Stroke Phases
- `GET /api/strokephases` - Get all stroke phases
- `GET /api/strokephases/{id}` - Get specific phase
- `POST /api/strokephases` - Create new phase
- `PUT /api/strokephases/{id}` - Update phase
- `DELETE /api/strokephases/{id}` - Delete phase

### Technique Drills
- `GET /api/techniquedrills` - Get all drills
- `GET /api/techniquedrills/{id}` - Get specific drill
- `POST /api/techniquedrills` - Create drill
- `PUT /api/techniquedrills/{id}` - Update drill
- `DELETE /api/techniquedrills/{id}` - Delete drill

### Common Errors
- `GET /api/commonerrors` - Get all common errors
- `GET /api/commonerrors/{id}` - Get specific error
- `POST /api/commonerrors` - Create error entry
- `PUT /api/commonerrors/{id}` - Update error
- `DELETE /api/commonerrors/{id}` - Delete error

### Injury Prevention
- `GET /api/injuryprevention` - Get all injury prevention tips
- `GET /api/injuryprevention/{id}` - Get specific tip
- `POST /api/injuryprevention` - Create tip
- `PUT /api/injuryprevention/{id}` - Update tip
- `DELETE /api/injuryprevention/{id}` - Delete tip

## 💻 Local Development

### Prerequisites
- .NET 8.0 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 / JetBrains Rider / VS Code

### Setup
1. Clone the repository:
git clone https://github.com/yourusername/rowing-api.git


2. Update connection string in `appsettings.json`:
{
  "ConnectionStrings": {
    "rowing": "Server=localhost;Database=Rowing;Trusted_Connection=true;TrustServerCertificate=true"
  }
}

3. Create database and run SQL scripts:
Run the SQL scripts in `/Database/Scripts/` in numbered order:
1. `01_CreateDatabase.sql` - Creates the database
2. `02_CreateTables.sql` - Creates all tables
3. `03_SeedData.sql` - Adds sample data

4. Build and run


## 🚀 Deployment

The API is deployed on Azure App Service with Azure SQL Database.


## 📊 Database Schema

### Core Tables:
- `stroke_phases` - Four phases of rowing stroke
- `technique_drills` - Progressive technique exercises
- `common_errors` - Common rowing mistakes and corrections
- `injury_prevention` - Injury prevention strategies

## 🔑 Key Features
- Clean Architecture implementation
- Repository pattern with Dapper
- Dependency Injection
- Async/await throughout
- Comprehensive error handling
- Input validation
- Swagger documentation
- CORS enabled for cross-origin requests

## 📈 Future Enhancements
- [ ] Add authentication/authorization
- [ ] Implement caching for better performance
- [ ] Add rate limiting to prevent abuse
- [ ] Add comprehensive unit tests

## 🤝 Contributing
This is currently a portfolio project, but suggestions and feedback are welcome!

## 👤 Author
Arael Seher
- LinkedIn: https://www.linkedin.com/in/arael-seher-43a2886a/
- GitHub: https://github.com/Leara0
- Portfolio: https://araelseherportfolio.netlify.app/

## 🙏 Acknowledgments
- Rowing technique information sourced from US Rowing and British Rowing
- Built as part of portfolio for software engineering positions