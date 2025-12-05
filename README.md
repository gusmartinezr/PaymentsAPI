# 🚀 Payments API – Backend Challenge (.NET 8)

This project implements a clean and modular Payments API for registering and consulting utility service payments (electricity, water, telecom). It follows Clean Architecture principles, separating concerns into Application, Domain, Infrastructure, and API layers.

## 📝 Overview

The Payments API allows:
- Registering new payments
- Validating business rules (max amount, currency restrictions, etc.)
- Querying payments by customer ID

The application is designed with scalability and maintainability in mind:
- DTOs and validators for clean request handling
- Services and mapping layers for business logic
- Repository pattern for data access
- Separation of concerns through Clean Architecture

## 🧱 Architecture

The solution follows a layered architecture:

Presentation → Application → Domain → Infrastructure

### ✔ Presentation Layer (PaymentsAPI)
Controllers, routing, dependency injection, API responses, Swagger.

### ✔ Application Layer
DTOs, interfaces, validators, services, mapping.

### ✔ Domain Layer
Entities, enums, constants — pure business rules with no external dependencies.

### ✔ Infrastructure Layer
EF Core DbContext, repository implementations, migrations, persistence configurations.

## 🛠 Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- FluentValidation
- AutoMapper
- SQL Server / SQLite
- Swagger / OpenAPI
- Clean Architecture principles

## ⭐ Features

### ✔ Register a Payment
Validation rules:
- Amount must be greater than 0
- Amount cannot exceed 1500 Bs
- USD or foreign currencies are rejected
- Initial status = "pendiente"

### ✔ Consult payments by customer ID
Returns:
- Provider name
- Amount
- Status
- CreatedAt timestamp

## 📁 Project Structure

WebApplication1/
│── Application/
│ ├── DTOs/
│ ├── Interfaces/
│ ├── Services/
│ ├── Validators/
│ └── Mapping/
│
│── Domain/
│ ├── Entities/
│ ├── Enums/
│ ├── Constants/
│
│── Infrastructure/
│ ├── Persistence/
│ ├── Configurations/
│ ├── Repositories/
│ └── Migrations/
│
│── PaymentsAPI/
│ ├── Controllers/
│ ├── Program.cs
│ ├── appsettings.json
│ └── Swagger configuration

## ⚙️ Installation

Clone the repository:

git clone <your-github-repo-url>
cd WebApplication1

Restore dependencies:

dotnet restore

## 🗃️ Running Migrations

dotnet ef database update --project Infrastructure --startup-project PaymentsAPI

## ▶️ Running the API

dotnet run --project PaymentsAPI

API will run on:

http://localhost:5000
https://localhost:7000

## 📡 API Endpoints

### 1️⃣ Register a Payment  
POST /api/payments

Request Body:
{
  "customerId": "cfe8b150-2f84-4a1a-bdf4-923b20e34973",
  "serviceProvider": "SERVICIOS ELÉCTRICOS S.A.",
  "amount": 120.50
}

### 2️⃣ Get Payments by Customer  
GET /api/payments?customerId={id}

## 🧩 Validation Rules

The API enforces:
- Amount must be greater than 0
- Amount cannot exceed 1500 Bs
- No USD allowed
- All new payments start as "pendiente"
- Required fields validated through FluentValidation

## 📥 Example Response

Successful creation:
{
  "isSuccess": true,
  "displayMessage": "Payment created successfully",
  "data": {
    "paymentId": "a248ad43-1f44-4b32-b0a0-e1c725b9bb7d",
    "serviceProvider": "SERVICIOS ELÉCTRICOS S.A.",
    "amount": 120.50,
    "status": "pendiente",
    "createdAt": "2025-07-17T08:30:00Z"
  }
}

## 📘 Swagger

Swagger UI is enabled:

/swagger

## 📄 License

This project does not include a license by default.
