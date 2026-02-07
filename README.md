# Shopping List Assistant Backend API

ASP.NET Core Web API для AI-асистента по покупкам. Користувач взаємодіє з чат-ботом, який парсить команди і викликає endpoints цього API.

## 🛠️ Технології

- **ASP.NET Core 10** - Web API framework
- **Entity Framework Core** - ORM
- **SQL Server** - База даних (Docker)
- **Swagger** - API документація

## 🏗️ Архітектура

Проєкт використовує **Clean Architecture** з чіткими шарами:

- **Controllers** - HTTP endpoints
- **Services** - Бізнес-логіка
- **Repositories** - Доступ до даних
- **Models** - Entities і DTOs

### Patterns:
- Repository Pattern
- Dependency Injection
- DTO Pattern

## 📊 Database Schema
```
Store (1) ----< (N) ShoppingItem (N) >----< (N) Category
```

## 🚀 Запуск проєкту

### Prerequisites:
- .NET 10 SDK
- Docker Desktop

### Крок 1: SQL Server в Docker
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword" \
  -p 1433:1433 --name sql-server \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### Крок 2: Налаштування
Оновіть `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=ShoppingBuddyDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  }
}
```

### Крок 3: Міграції
```bash
dotnet ef database update
```

### Крок 4: Запуск
```bash
dotnet run
```

API доступний на: `http://localhost:5211`

Swagger UI: `http://localhost:5211/swagger`

## 📡 API Endpoints

| Method | Endpoint | Опис |
|--------|----------|------|
| POST | /api/items | Створити новий товар |
| GET | /api/items | Отримати всі товари (з фільтрами) |
| GET | /api/items/{id} | Отримати товар за ID |
| PUT | /api/items/{id} | Оновити товар |
| DELETE | /api/items/{id} | Видалити товар |

### Фільтри:
- `?storeName=Rossmann` - фільтр по магазину
- `?isPurchased=false` - тільки некуплені

## 💡 Приклад використання

### Створити товар:
```bash
POST /api/items
{
  "name": "Мило",
  "store": "Rossmann",
  "quantity": 2
}
```

### Позначити як куплений:
```bash
PUT /api/items/1
{
  "id": 1,
  "isPurchased": true
}
```

## 🎯 Особливості

- ✅ Автоматичне створення магазинів при першому використанні
- ✅ Nullable Store (товари можуть бути без магазину)
- ✅ Partial Update (оновлюються тільки передані поля)
- ✅ LINQ queries з Include (уникнення N+1 problem)
- ✅ RESTful API design

## 📚 Навчальний проєкт

Створено для закріплення знань:
- ASP.NET Core Web API
- Entity Framework Core
- Repository Pattern
- Clean Architecture
- Docker
