# FinanceBilling Solution - Comprehensive Project Documentation

**Version:** 1.0  
**Last Updated:** June 2026  
**Technology Stack:** .NET 8, ASP.NET Core, Entity Framework Core, SQL Server, JWT Authentication

---

## TABLE OF CONTENTS

1. Executive Summary
2. Project Overview
3. Architecture
4. Technology Stack
5. Project Structure
6. Core Components
7. API Endpoints
8. Database Schema
9. Authentication & Security
10. Configuration
11. Getting Started
12. Testing
13. Deployment
14. Best Practices
15. Troubleshooting

---

## 1. EXECUTIVE SUMMARY

**FinanceBillingSolution** is a comprehensive, enterprise-grade financial billing and invoice management system built with .NET 8 and ASP.NET Core. The application enables organizations to create, manage, and track invoices, process payments, and maintain detailed audit logs of all financial transactions.

### Key Features
- JWT-based authentication and role-based authorization
- Comprehensive dashboard with financial summaries
- Invoice creation, tracking, and status management
- Payment processing with multiple payment methods
- User management with approval workflows
- Detailed audit logging for compliance
- Real-time financial analytics and reporting
- Enterprise-grade security and error handling
- Comprehensive unit testing with xUnit

---

## 2. PROJECT OVERVIEW

### Purpose
The FinanceBillingSolution addresses the critical need for organizations to efficiently manage their billing operations through a centralized platform that provides:
- Streamlined invoice creation and delivery
- Real-time payment tracking
- Financial dashboard analytics
- User role management with approval workflows
- Complete audit trails for regulatory compliance

### Target Users
- Financial managers
- Billing administrators
- Executive management
- Accounting teams
- Client relationship managers

### Business Value
- **Efficiency:** Automate invoice generation and payment tracking
- **Compliance:** Maintain detailed audit logs for regulatory requirements
- **Visibility:** Real-time dashboard for financial insights
- **Security:** Role-based access control with JWT authentication
- **Scalability:** Cloud-ready microservices architecture

---

## 3. ARCHITECTURE

### Architectural Pattern: Clean Architecture with Repository Pattern

The solution follows **Clean Architecture** principles, ensuring:
- Separation of Concerns: Each layer has distinct responsibilities
- Testability: Easy to mock dependencies for unit testing
- Maintainability: Clear structure facilitates long-term maintenance
- Flexibility: Easy to swap implementations without affecting business logic

### Layered Architecture Diagram

```
Presentation Layer (API/MVC)
    ↓
Core Business Logic Layer
    ↓
Infrastructure Layer
    ↓
Data Access Layer (EF Core)
    ↓
SQL Server Database
```

---

## 4. TECHNOLOGY STACK

### Backend Framework
- **Framework:** .NET 8 with ASP.NET Core
- **Language:** C# 12
- **ORM:** Entity Framework Core 8
- **Database:** SQL Server (SQLEXPRESS)

### Security & Authentication
- **Authentication:** JWT (JSON Web Tokens)
- **Password Hashing:** BCrypt
- **Authorization:** Role-based Access Control (RBAC)

### API Documentation
- **Swagger/OpenAPI:** NSwag for interactive API documentation
- **ReDoc:** For read-only API documentation

### Testing Framework
- **Unit Testing:** xUnit
- **Mocking:** Moq
- **Test Coverage:** Auth, Invoice, Payment, User services

### Development Tools
- **IDE:** Visual Studio / Rider
- **Version Control:** Git
- **Package Management:** NuGet

---

## 5. PROJECT STRUCTURE

### Directory Layout

```
FinanceBillingSolution/
├── FinanceBilling.Core/
│   ├── DTOs/
│   ├── Entities/
│   ├── Enums/
│   ├── Interfaces/
│   └── FinanceBilling.Core.csproj
├── FinanceBilling.Infrastructure/
│   ├── Data/
│   ├── Repositories/
│   ├── Services/
│   ├── Security/
│   ├── DependencyInjection.cs
│   └── FinanceBilling.Infrastructure.csproj
├── FinanceBilling.API/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Program.cs
│   ├── appsettings.json
│   └── FinanceBilling.API.csproj
├── FinanceBilling.MVC/
│   ├── Controllers/
│   ├── Views/
│   ├── wwwroot/
│   └── FinanceBilling.MVC.csproj
├── Tests/
│   ├── AuthServiceTests.cs
│   ├── UserServiceTests.cs
│   ├── InvoiceServiceTests.cs
│   ├── PaymentServiceTests.cs
│   └── FinanceBilling.Tests.csproj
└── FinanceBillingSolution.slnx
```

### Layer Descriptions

#### FinanceBilling.Core
Contains business logic, entities, DTOs, and service interfaces.
- **DTOs:** Data transfer objects for API communication
- **Entities:** Domain models (User, Invoice, Payment, etc.)
- **Interfaces:** Service and repository contracts
- **Enums:** Invoice status and other enumerations

#### FinanceBilling.Infrastructure
Implements repositories, services, and database context.
- **Repositories:** Data access implementations
- **Services:** Business logic implementations
- **Data:** Entity Framework Core context
- **Security:** JWT and password services

#### FinanceBilling.API
REST API endpoints and configuration.
- **Controllers:** API endpoint definitions
- **Middleware:** Custom middleware for exception handling
- **Program.cs:** Application configuration and startup

#### FinanceBilling.MVC
Web UI layer (Optional MVC interface).

#### Tests
Unit test suite with xUnit and Moq.

---

## 6. CORE COMPONENTS

### 6.1 Entities (Domain Models)

#### User Entity
```csharp
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int? RoleId { get; set; }
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
    public Role? Role { get; set; }
    public ICollection<Invoice> ClientInvoices { get; set; }
    public ICollection<Invoice> ManagedInvoices { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}
```

**Key Fields:**
- UserId: Unique user identifier
- Username: User login name
- Email: User email address
- PasswordHash: Hashed password (never stored in plain text)
- RoleId: Reference to user role
- IsApproved: Admin approval status
- IsActive: Account activation status

#### Invoice Entity
```csharp
public class Invoice
{
    public int InvoiceId { get; set; }
    public int ClientUserId { get; set; }
    public int CreatedByManagerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public InvoiceStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public User ClientUser { get; set; }
    public User CreatedByManager { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
```

**Key Fields:**
- InvoiceId: Unique invoice identifier
- ClientUserId: Client reference
- CreatedByManagerId: Manager who created the invoice
- TotalAmount: Invoice total amount
- Status: Current invoice status (Pending, PartiallyPaid, Paid, Overdue, Cancelled)
- DueDate: Payment due date

#### Payment Entity
```csharp
public class Payment
{
    public int PaymentId { get; set; }
    public int InvoiceId { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public Invoice Invoice { get; set; }
}
```

#### Role Entity
Defines user roles: Admin, Manager, Client

#### AuditLog Entity
```csharp
public class AuditLog
{
    public int AuditLogId { get; set; }
    public int UserId { get; set; }
    public string Action { get; set; }
    public string EntityType { get; set; }
    public int? EntityId { get; set; }
    public DateTime Timestamp { get; set; }
    public User User { get; set; }
}
```

### 6.2 Enumerations

#### InvoiceStatus Enum
```
Pending = 1          // Invoice created, awaiting payment
PartiallyPaid = 2    // Partial payment received
Paid = 3             // Full payment received
Overdue = 4          // Past due date without full payment
Cancelled = 5        // Invoice cancelled
```

### 6.3 Services

#### AuthService
Handles user authentication and registration.
- **RegisterAsync:** Validates and registers new users
- **LoginAsync:** Authenticates user and generates JWT token

#### UserService
Manages user accounts and approvals.
- **ApproveUser:** Approves pending user registrations
- **GetPendingUsers:** Retrieves users awaiting approval
- **GetClients:** Fetches all client users

#### InvoiceService
Manages invoice lifecycle.
- **CreateInvoice:** Creates new invoices with audit logging
- **GetAll:** Retrieves all invoices
- **GetClientInvoices:** Gets invoices for specific client

#### PaymentService
Handles payment processing.
- **AddPayment:** Records payment against invoice
- **GetAll:** Retrieves all payments
- **UpdateInvoiceStatus:** Updates invoice based on payment status

#### DashboardService
Provides analytics and reporting.
- **GetSummary:** Total invoices, revenue, pending payments
- **RecentActivity:** Last 5 transactions

#### AuditLogService
Manages audit trail.
- **LogAction:** Records user actions for compliance
- **GetLogs:** Retrieves audit logs

### 6.4 Repositories

All repositories implement the **Repository Pattern** for clean data access.

#### IUserRepository
- GetByIdAsync(id)
- GetByUsernameAsync(username)
- GetByEmailAsync(email)
- AddAsync(user)
- UpdateAsync(user)
- GetAllAsync()
- GetPendingAsync()
- DeleteAsync(id)

#### IInvoiceRepository, IPaymentRepository, IAuditLogRepository
Similar interfaces with domain-specific methods.

---

## 7. API ENDPOINTS

### 7.1 Authentication Endpoints

#### Register User
```
POST /api/auth/register
Content-Type: application/json

Request:
{
    "username": "john_doe",
    "email": "john@example.com",
    "password": "SecurePassword@123"
}

Response (200):
{
    "success": true,
    "message": "User registered successfully"
}
```

#### Login User
```
POST /api/auth/login
Content-Type: application/json

Request:
{
    "username": "john_doe",
    "password": "SecurePassword@123"
}

Response (200):
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "username": "john_doe",
    "role": "Manager"
}
```

### 7.2 Users Endpoints

#### Get Pending Users
```
GET /api/users/pending
Authorization: Bearer {token}
```

#### Approve User
```
POST /api/users/{userId}/approve
Authorization: Bearer {token}
```

#### Get All Clients
```
GET /api/users/clients
Authorization: Bearer {token}
```

### 7.3 Invoices Endpoints

#### Create Invoice
```
POST /api/invoices
Authorization: Bearer {token}

Request:
{
    "clientUserId": 3,
    "invoiceDate": "2026-06-04T10:00:00Z",
    "dueDate": "2026-07-04T10:00:00Z",
    "totalAmount": 5000.00
}
```

#### Get All Invoices
```
GET /api/invoices
Authorization: Bearer {token}
```

#### Get Invoice by ID
```
GET /api/invoices/{invoiceId}
Authorization: Bearer {token}
```

### 7.4 Payments Endpoints

#### Add Payment
```
POST /api/payments
Authorization: Bearer {token}

Request:
{
    "invoiceId": 1,
    "amountPaid": 2500.00,
    "paymentMethod": "Credit Card"
}
```

#### Get All Payments
```
GET /api/payments
Authorization: Bearer {token}
```

#### Get Invoice Payments
```
GET /api/payments/invoice/{invoiceId}
Authorization: Bearer {token}
```

### 7.5 Dashboard Endpoints

#### Get Dashboard Summary
```
GET /api/dashboard/summary
Authorization: Bearer {token}

Response:
{
    "totalInvoices": 15,
    "totalRevenue": 150000.00,
    "pendingAmount": 25000.00,
    "recentActivity": [...]
}
```

### 7.6 Audit Logs Endpoints

#### Get Audit Logs
```
GET /api/auditlogs
Authorization: Bearer {token}

Response:
[
    {
        "auditLogId": 1,
        "userId": 2,
        "username": "manager1",
        "action": "Invoice Created",
        "entityType": "Invoice",
        "entityId": 1,
        "timestamp": "2026-06-04T10:00:00Z"
    }
]
```

---

## 8. DATABASE SCHEMA

### Entity Relationships

```
Role (1) ─── (M) User
                 ├─ ClientInvoices ─── (M) Invoice
                 ├─ ManagedInvoices ─── (M) Invoice
                 └─ AuditLogs ─── (M) AuditLog

Invoice (1) ─── (M) Payment
```

### Tables Overview

| Table | Purpose | Key Fields |
|-------|---------|-----------|
| Roles | User role definitions | RoleId, RoleName |
| Users | User accounts | UserId, Username, Email, PasswordHash, RoleId |
| UserApprovals | Approval workflow | ApprovalId, UserId, Status, ApprovedBy |
| Invoices | Invoice records | InvoiceId, ClientUserId, TotalAmount, Status |
| Payments | Payment records | PaymentId, InvoiceId, AmountPaid, PaymentMethod |
| AuditLogs | Audit trail | AuditLogId, UserId, Action, EntityType |

### Connection String
```
Server=localhost\SQLEXPRESS;
Database=CapstoneFinanceBillingDb;
Trusted_Connection=True;
TrustServerCertificate=True;
Encrypt=false
```

---

## 9. AUTHENTICATION & SECURITY

### JWT (JSON Web Token) Implementation

#### Token Structure
Header.Payload.Signature

#### Token Configuration
```json
{
    "Jwt": {
        "Key": "FinanceBillingSecretKey2025@123456789",
        "Issuer": "FinanceBilling.API",
        "Audience": "FinanceBilling.Client"
    }
}
```

### Password Security
- **Algorithm:** BCrypt with salt
- **Cost Factor:** 11 (default)
- **Hashing:** One-way encryption for password storage
- **Never Stored:** Plain text passwords are never stored

### Authorization & Role-Based Access Control

#### Role Hierarchy
1. **Admin:** Full system access, user approval, dashboard access
2. **Manager:** Create invoices, process payments, view audit logs
3. **Client:** View own invoices, track payments

### Security Best Practices Implemented
1. HTTPS/TLS: All connections encrypted
2. CORS: Cross-Origin Resource Sharing configuration
3. SQL Injection Prevention: Parameterized queries via EF Core
4. XSS Protection: Input validation and sanitization
5. CSRF Protection: Token validation in requests
6. Audit Logging: All actions logged for compliance
7. Error Handling: Generic error messages (no sensitive info leakage)

---

## 10. CONFIGURATION

### appsettings.json Structure
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CapstoneFinanceBillingDb;..."
    },
    "Jwt": {
        "Key": "FinanceBillingSecretKey2025@123456789",
        "Issuer": "FinanceBilling.API",
        "Audience": "FinanceBilling.Client"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

### Dependency Injection Container Configuration

The DependencyInjection.cs file configures all services and repositories:
- User, Invoice, Payment, AuditLog repositories
- Auth, User, Invoice, Payment, Dashboard services
- Password and JWT token services

---

## 11. GETTING STARTED

### Prerequisites
- .NET 8 SDK installed
- SQL Server (SQLEXPRESS recommended)
- Visual Studio 2022 or Rider IDE
- Git for version control

### Installation Steps

#### Step 1: Clone Repository
```bash
git clone https://github.com/Uday-kumar-06/DotNet_Journey.git
cd DotNet_Journey/Capstone\ Project/FinanceBillingSolution
```

#### Step 2: Database Setup
```bash
# Create database
sqlcmd -S localhost\SQLEXPRESS -Q "CREATE DATABASE CapstoneFinanceBillingDb"

# Apply migrations
cd FinanceBilling.API
dotnet ef database update --project ../FinanceBilling.Infrastructure
```

#### Step 3: Build Solution
```bash
dotnet restore
dotnet build
```

#### Step 4: Run Application
```bash
cd FinanceBilling.API
dotnet run
# Application runs on: https://localhost:7000
```

#### Step 5: Access Swagger UI
```
https://localhost:7000/swagger
```

### First Steps with API

1. **Register a User**
```bash
curl -X POST https://localhost:7000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"username": "testuser", "email": "test@example.com", "password": "TestPass@123"}'
```

2. **Login**
```bash
curl -X POST https://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username": "testuser", "password": "TestPass@123"}'
```

---

## 12. TESTING

### Test Structure

The project includes comprehensive unit tests using **xUnit** and **Moq**:

#### Test Coverage

| Test Class | Tests | Areas |
|-----------|-------|-------|
| AuthServiceTests | 8 | Register, Login validation |
| UserServiceTests | 5 | User approval, retrieval |
| InvoiceServiceTests | 4 | Invoice creation, retrieval |
| PaymentServiceTests | 6 | Payment processing, status updates |

### Running Tests

#### Using dotnet CLI
```bash
# Run all tests
dotnet test

# Run specific test file
dotnet test Tests/AuthServiceTests.cs

# Run with verbose output
dotnet test --verbosity detailed
```

#### Using Visual Studio
1. Open Test Explorer (Test → Test Explorer)
2. Click "Run All"
3. View results in Test Explorer window

---

## 13. DEPLOYMENT

### Pre-Deployment Checklist
- All tests passing
- No compiler warnings
- Environment configurations set
- Database backups created
- Security review completed

### Production Build
```bash
# Build for production
dotnet publish -c Release -o ./publish
```

### Deployment Steps
1. Copy published files to server
2. Configure connection strings for production database
3. Update JWT secret key for production
4. Apply database migrations
5. Start application service

---

## 14. BEST PRACTICES

### Code Organization
- Follow SOLID principles
- Use dependency injection
- Implement interface segregation
- Keep classes single-responsibility

### Error Handling
- Catch specific exceptions
- Log meaningful error messages
- Return appropriate HTTP status codes
- Avoid exposing internal details

### Async/Await
- Use async for I/O operations
- Avoid blocking calls with .Result
- Properly await all async methods

### Naming Conventions
- Classes: PascalCase (UserService)
- Methods: PascalCase (GetUserAsync)
- Properties: PascalCase (Username)
- Private fields: _camelCase (_userRepository)
- Local variables: camelCase (userName)

### Database Queries
- Use Include() for related data
- Avoid N+1 query problems
- Use AsNoTracking() for read-only queries
- Implement pagination for large datasets

---

## 15. TROUBLESHOOTING

### Common Issues

#### Database Connection Error
**Solution:**
- Verify SQL Server is running
- Check connection string in appsettings.json
- Ensure database exists and user has permissions

#### JWT Token Validation Failed
**Solution:**
- Verify JWT key matches in appsettings.json
- Check token hasn't expired
- Ensure Bearer scheme in Authorization header

#### Migration Not Applied
**Solution:**
```bash
dotnet ef migrations add InitialCreate --project FinanceBilling.Infrastructure
dotnet ef database update --project FinanceBilling.Infrastructure
```

#### Port Already in Use
**Solution:**
```bash
# Find process using port 7000
lsof -i :7000
# Kill process and retry
```

#### Authentication Fails for New User
**Solution:**
- Admin user must approve new registrations first
- Use admin account to approve user
- Then attempt login with new user

### Health Check Endpoint
```
GET https://localhost:7000/api/health
```

---

## CONCLUSION

FinanceBillingSolution is a production-ready financial management system built on modern .NET technologies. It follows industry best practices for security, testing, and architecture, making it scalable and maintainable for enterprise environments.

For more information, refer to inline code comments, XML documentation, and the GitHub repository.

---

**Document Version:** 1.0  
**Last Updated:** June 4, 2026  
**Repository:** https://github.com/Uday-kumar-06/DotNet_Journey  
**Status:** Active Development