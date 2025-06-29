# 🏎️ FormulaOne API

A lightweight and modular **.NET 7 Web API** built with **ASP.NET Core**, leveraging **Clean Architecture**, **CQRS**, and **MediatR** to ensure a scalable and maintainable solution.

This demo project demonstrates modern best practices for building APIs, focusing on separation of concerns and extensibility.

---

## ✨ Features

- ✅ CRUD operations for core domain entities
- ✅ Clean Architecture with Domain, Application, and Infrastructure layers
- ✅ CQRS pattern using **MediatR**
- ✅ Repository Pattern + Unit of Work
- ✅ SQLite using **Entity Framework Core**
- ✅ Object Mapping with **AutoMapper**
- ✅ API documentation with **Swagger (OpenAPI)**

---

## 📦 Tech Stack

- **.NET 7** 💥
- **ASP.NET Core Web API**
- **Entity Framework Core** (with **SQLite** provider)
- **MediatR** for in-process messaging and command/query separation
- **CQRS** (Command Query Responsibility Segregation)
- **Repository + Unit of Work Pattern**
- **AutoMapper**
- **Swagger UI**

---

## 🧱 Architecture Overview

- **API Layer**: Entry point (controllers), delegates requests to MediatR.
- **Application Layer**: Contains CQRS handlers (Commands & Queries) and business logic.
- **Data Access Layer**: Implements repositories, unit of work, and EF Core context.
- **Domain Layer**: Defines core entities and value objects.

---

## 📁 Project Structure

#### FormulaOne/
├── FormulaOne.Api # Main Web API application
├── FormulaOne.Application # CQRS Commands, Queries, and Handlers (MediatR)
├── FormulaOne.DataService # Data access layer (DbContext, Repositories, UnitOfWork)
├── FormulaOne.Entities # Domain models (POCOs)
├── FormulaOne.sln # Solution file
└── README.md # Project description


---

## 🚀 Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQLite](https://www.sqlite.org/index.html) *(optional — EF Core will create the `.db` file automatically)*
- Visual Studio 2022 or Visual Studio Code

---

### 🛠️ Run the App

1. **Clone the repository**
```bash
git clone https://github.com/your-username/formulaone-api.git
cd formulaone-api
