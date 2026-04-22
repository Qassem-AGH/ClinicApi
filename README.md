# 🏥 Clinic API

A REST API for managing a clinic — built with ASP.NET Core and Clean Architecture.

## Tech Stack

- **ASP.NET Core 10** — Web API
- **Clean Architecture** — 4 separate layers
- **CQRS + MediatR** — commands and queries are separated
- **Entity Framework Core** — SQL Server database
- **AutoMapper** — maps entities to DTOs
- **FluentValidation** — request validation via pipeline
- **JWT + RBAC** — authentication with Admin and User roles
- **Swagger UI** — test all endpoints in the browser

## Project Structure

```
ClinicApi/
├── ClinicApi.API/           → Controllers, Program.cs
├── ClinicApi.Application/   → Commands, Queries, Handlers, DTOs
├── ClinicApi.Domain/        → Entities, Interfaces, Enums
└── ClinicApi.Infrastructure/→ DbContext, Repositories, Migrations
```

Dependencies always point inward → Domain knows nothing about the other layers.

## Models

| Entity | Description |
|---|---|
| Doctor | Has a name, specialty and phone number |
| Patient | Has a name, email, phone and date of birth |
| Appointment | Links a Doctor and a Patient with a date and status |
| AppUser | Used for login — has a role of Admin or User |

## How to Run

**1. Clone the repo**
```bash
git clone https://github.com/Qassem-AGH/ClinicApi.git
cd ClinicApi
```

**2. Update the connection string in `ClinicApi.API/appsettings.json`**
```json
"ConnectionStrings": {
  "Default": "Server=YOUR_SERVER;Database=ClinicApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

**3. Run the API — database is created automatically**
```bash
cd ClinicApi.API
dotnet run
```

**4. Open Swagger**
```
http://localhost:5272/swagger
```

## API Endpoints

### Auth (Public)
| Method | Route | Description |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and get a JWT token |

### Doctors
| Method | Route | Role |
|---|---|---|
| GET | `/api/doctors` | User, Admin |
| POST | `/api/doctors` | Admin only |
| PUT | `/api/doctors/{id}` | Admin only |
| DELETE | `/api/doctors/{id}` | Admin only |

### Patients
| Method | Route | Role |
|---|---|---|
| GET | `/api/patients` | Admin only |
| POST | `/api/patients` | User, Admin |
| PUT | `/api/patients/{id}` | Admin only |
| DELETE | `/api/patients/{id}` | Admin only |

### Appointments
| Method | Route | Role |
|---|---|---|
| GET | `/api/appointments` | User, Admin |
| POST | `/api/appointments` | User, Admin |
| DELETE | `/api/appointments/{id}` | Admin only |

## Testing in Swagger

1. Register an Admin user via `POST /api/auth/register`
2. Login via `POST /api/auth/login` and copy the token
3. Click **Authorize** at the top of the Swagger page
4. Enter `Bearer YOUR_TOKEN_HERE` and click Authorize
5. All endpoints are now unlocked

## Roles

| Role | Access |
|---|---|
| **Admin** | Full access to everything |
| **User** | Can read doctors, create patients, book appointments |