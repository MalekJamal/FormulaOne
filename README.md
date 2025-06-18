# 🏎️ FormulaOne API

A lightweight **.NET 7 Web API** built using **ASP.NET Core**, designed with clean architecture principles and ready for future extensions like **Redis**, **CQRS**, **Caching**, and more.

This demo showcases:
- ✅ CRUD operations
- ✅ Repository Pattern + Unit of Work
- ✅ SQLite with Entity Framework Core
- ✅ AutoMapper
- ✅ Swagger/OpenAPI

---

## 📦 Tech Stack

- **.NET 7** 💥
- **ASP.NET Core Web API**
- **Entity Framework Core (EF Core)** with **SQLite**
- **Repository + Unit of Work Pattern**
- **AutoMapper**
- **Swagger UI**

---

## 📁 Project Structure

FormulaOne/
├── FormulaOne.Api # Main Web API application
├── FormulaOne.DataService # Data access layer (DbContext, Repositories, UnitOfWork)
├── FormulaOne.Entities # POCOs / Domain models
├── FormulaOne.sln # Solution file
└── README.md # Project description



---

## 🚀 Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQLite](https://www.sqlite.org/index.html) *(optional — EF Core will create the DB file automatically)*
- Visual Studio / VS Code

### Run the App

1. **Clone the repository**

```bash
git clone https://github.com/your-username/formulaone-api.git
cd formulaone-api
