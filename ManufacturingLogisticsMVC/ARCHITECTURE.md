# ManufacturingLogisticsMVC — Architecture Guide

## Project Structure

```
ManufacturingLogisticsMVC/
│
├── Program.cs                               ← Entry point | DI | EF | Serilog
├── appsettings.json                         ← Connection string + Serilog config
├── ManufacturingLogisticsMVC.csproj         ← NuGet packages
│
├── Models/
│   ├── ApplicationDbContext.cs              ← EF Core DbContext
│   ├── StoreProfile.cs                      ← Store_Profiles table entity
│   ├── StoreManager.cs                      ← Store_Managers table entity
│   └── StoreProfileDTOs.cs                  ← Request & Response DTOs
│
├── Repository/
│   ├── IStoreProfiles.cs                    ← Interface (contract)
│   └── StoreProfiles.cs                     ← EF Core implementation
│
├── Bo/
│   └── StoreProfilesBO.cs                   ← Input validations + business rules
│
├── Facade/
│   └── StoreProfilesFacade.cs               ← Bridges Controller ↔ BO
│
└── Controllers/
    ├── StoreProfilesController.cs           ← Web API endpoints + Serilog logging
    └── Exceptions/
        ├── StoreManagementException.cs      ← General business exception
        └── StoreNotFoundException.cs        ← 404 specific exception
```

---

## Layer Responsibilities

| Layer | Namespace Pattern | Responsibility |
|-------|------------------|----------------|
| **Program.cs** | — | Wires DI, EF, Serilog, middleware |
| **Controller** | `ManufacturingLogisticsMVC.Controllers.StoreManagement` | API endpoints, Serilog logging, exception handling |
| **Facade** | `ManufacturingLogisticsMVC.Facade.StoreManagement` | Simplifies Controller ↔ BO calls, maps entities to DTOs |
| **BO** | `ManufacturingLogisticsMVC.Bo.StoreManagement` | Input validation (null, whitespace, positive values) |
| **Repository** | `ManufacturingLogisticsMVC.Repository.StoreManagement` | Pure EF Core data access |
| **Models** | `ManufacturingLogisticsMVC.Models.StoreManagement` | Entities + DTOs |

---

## API Endpoints

| # | Method | Route | Description |
|---|--------|-------|-------------|
| 1 | `POST` | `/api/StoreProfiles/Insert` | Insert a new store |
| 2 | `GET` | `/api/StoreProfiles/FindById/{id}` | Find store by ID |
| 3 | `GET` | `/api/StoreProfiles/Filter` | Filter stores (joined with manager) |
| 4 | `PUT` | `/api/StoreProfiles/Update` | Update an existing store |
| 5 | `DELETE` | `/api/StoreProfiles/Delete/{id}` | Delete a store |

---

## Return Types Used

| Situation | Return Type |
|-----------|-------------|
| Insert (single object) | `ActionResult<StoreProfileResponse>` |
| Find by ID (single object) | `ActionResult<StoreProfileResponse>` |
| Filter (collection) | `ActionResult<IEnumerable<StoreProfileWithManagerResponse>>` |
| Update (single object) | `ActionResult<StoreProfileResponse>` |
| Delete (no body) | `IActionResult` |

---

## Serilog — What Gets Logged (Controller only)

| Event | Log Level | Info Captured |
|-------|-----------|---------------|
| Request received | `Information` | All input fields |
| Insert success | `Information` | StoreId, StoreCode, StoreName, CreatedDateTime |
| Update success | `Information` | StoreId, StoreCode, StoreName, UpdatedDateTime, UpdatedByUserIdFk |
| Delete success | `Information` | StoreId, DeletedAt timestamp |
| Filter results | `Information` | Filter criteria + TotalRecords returned |
| Record not found | `Warning` | StoreId |
| Validation error | `Error` | Parameter name + message |
| Unexpected error | `Error` | Full exception + context |
| App crash | `Fatal` | Full exception |

Logs are written to:
- **Console** — during development
- **Logs/ManufacturingLogistics-{Date}.log** — rolling daily file (retained 30 days)

---

## Dependency Injection Registration (Program.cs)

```
IStoreProfiles        → StoreProfiles        (Scoped)
StoreProfilesBO       → StoreProfilesBO      (Scoped)
StoreProfilesFacade   → StoreProfilesFacade  (Scoped)
ApplicationDbContext  → EF SQL Server        (Scoped)
```

---

## Validation Rules (BO Layer)

| Field | Rule |
|-------|------|
| StoreCode | Required, not null/whitespace |
| StoreName | Required, not null/whitespace |
| StoreIdPK (update/delete) | Must be > 0 |
| StoreManagerIdFk | If provided, must be > 0 |
| AddressIdFk | If provided, must be > 0 |
| StoreStatusIdFk | If provided, must be > 0 |
| CreatedByUserIdFk | If provided, must be > 0 |
| UpdatedByUserIdFk | If provided, must be > 0 |

---

## Getting Started

1. Update `appsettings.json` → replace `YOUR_SERVER` with your SQL Server instance name.
2. Open Package Manager Console and run:
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
3. Run the project — Swagger UI is available at `https://localhost:{port}/swagger`
