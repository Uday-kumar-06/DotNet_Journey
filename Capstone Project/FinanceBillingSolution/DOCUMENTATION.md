# FinanceBilling Solution - Comprehensive Project Documentation

**Version:** 2.0  
**Last Updated:** June 2026  
**Technology Stack:** .NET 8, ASP.NET Core, Entity Framework Core, SQL Server, JWT Authentication

---

## TABLE OF CONTENTS

1. Executive Summary
2. Project Overview
3. Architecture
4. Technology Stack
5. Project Structure
6. Core Components & Implementation
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

**FinanceBillingSolution** is an enterprise-grade financial billing and invoice management system built with .NET 8 and ASP.NET Core. The application enables organizations to create, manage, and track invoices, process payments, and maintain audit logs with JWT-based authentication and role-based authorization.

### Key Features
- **JWT-based Authentication** with role-based authorization (Admin, Manager, Client)
- **User Management** with approval workflows for new registrations
- **Invoice Management** with status tracking (Pending, PartiallyPaid, Paid, Overdue, Cancelled)
- **Payment Processing** with automatic invoice status updates
- **Comprehensive Audit Logging** for compliance and accountability
- **Clean Architecture** with Repository Pattern implementation
- **Entity Framework Core** with database migrations
- **Unit Testing** with xUnit framework
- **Secure Password Hashing** using BCrypt

---

## 2. PROJECT OVERVIEW

### Purpose
The FinanceBillingSolution addresses the critical need for organizations to efficiently manage their billing operations through a centralized platform that provides:
- Streamlined invoice creation and delivery with manager-based workflows
- Real-time payment tracking with automatic status updates
- User role management with administrative approval workflows
- Complete audit trails for regulatory compliance and transparency
- Multi-layered security with JWT authentication and password hashing

### Target Users
- **Admin:** System administrators managing user approvals and system oversight
- **Manager:** Financial managers creating and managing invoices
- **Client:** End users viewing their invoices and payment history

### Business Value
- **Efficiency:** Automate invoice generation and payment tracking
- **Compliance:** Maintain detailed audit logs for all system activities
- **Security:** Role-based access control with JWT authentication and BCrypt password hashing
- **Scalability:** Clean Architecture enables easy feature additions and maintenance
- **Transparency:** Real-time audit logs and financial tracking

---

## 3. ARCHITECTURE

### Architectural Pattern: Clean Architecture with Repository Pattern

The solution follows **Clean Architecture** principles with clear layer separation:

```
Presentation Layer (API Controllers)
    ↓
Business Logic Layer (Services)
    ↓
Infrastructure Layer (Repositories, DbContext)
    ↓
Data Access Layer (Entity Framework Core)
    ↓
SQL Server Database
```

### Design Patterns Used
- **Repository Pattern:** Abstracts data access logic
- **Dependency Injection:** Built-in .NET DI container
- **Entity Configuration:** Fluent API for EF Core mappings
- **Service Layer:** Centralizes business logic
- **DTO Pattern:** Decouples API contracts from domain models

---

## 4. TECHNOLOGY STACK

### Backend Framework
- **Framework:** .NET 8 with ASP.NET Core
- **Language:** C# 12
- **ORM:** Entity Framework Core 8
- **Database:** SQL Server (SQLEXPRESS)

### Security & Authentication
- **Authentication:** JWT (JSON Web Tokens)
- **Password Hashing:** BCrypt with salt
- **Authorization:** Role-based Access Control (RBAC)

### API & Documentation
- **API:** ASP.NET Core REST API
- **Documentation:** Swagger/OpenAPI

### Testing Framework
- **Unit Testing:** xUnit
- **Mocking:** Moq

### Development Tools
- **IDE:** Visual Studio / Rider
- **Version Control:** Git
- **Package Management:** NuGet
- **Database:** SQL Server

---

## 5. PROJECT STRUCTURE

```
FinanceBillingSolution/
├── FinanceBilling.Core/
│   ├── DTOs/
│   │   ├── Auth/
│   │   ├── Invoice/
│   │   ├── Payment/
│   │   └── User/
│   ├── Entities/
│   │   ├── User.cs
│   │   ├── Invoice.cs
│   │   ├── Payment.cs
│   │   ├── Role.cs
│   │   ├── AuditLog.cs
│   │   └── UserApproval.cs
│   ├── Enums/
│   │   └── InvoiceStatus.cs
│   ├── Interfaces/
│   │   ├── Repositories/
│   │   └── Services/
│   └── FinanceBilling.Core.csproj
│
├── FinanceBilling.Infrastructure/
│   ├── Data/
│   │   └── FinanceBillingDbContext.cs
│   ├── Configurations/
│   │   ├── UserConfiguration.cs
│   │   ├── InvoiceConfiguration.cs
│   │   ├── PaymentConfiguration.cs
│   │   └── UserApprovalConfiguration.cs
│   ├── Repositories/
│   │   ├── UserRepository.cs
│   │   ├── InvoiceRepository.cs
│   │   ├── PaymentRepository.cs
│   │   └── AuditLogRepository.cs
│   ├── Services/
│   │   ├── AuthService.cs
│   │   ├── UserService.cs
│   │   ├── InvoiceService.cs
│   │   ├── PaymentService.cs
│   │   └── AuditLogService.cs
│   ├── Security/
│   │   ├── PasswordService.cs
│   │   └── JwtTokenService.cs
│   ├── Migrations/
│   ├── DependencyInjection.cs
│   └── FinanceBilling.Infrastructure.csproj
│
├── FinanceBilling.API/
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── UsersController.cs
│   │   ├── InvoicesController.cs
│   │   ├── PaymentsController.cs
│   │   └── AuditLogsController.cs
│   ├── Middleware/
│   ├── Program.cs
│   ├── appsettings.json
│   └── FinanceBilling.API.csproj
│
├── FinanceBilling.MVC/ (Optional)
│   ├── Controllers/
│   ├── Views/
│   ├── wwwroot/
│   └── FinanceBilling.MVC.csproj
│
├── Tests/
│   ├── AuthServiceTests.cs
│   ├── UserServiceTests.cs
│   ├── InvoiceServiceTests.cs
│   ├── PaymentServiceTests.cs
│   └── FinanceBilling.Tests.csproj
│
└── FinanceBillingSolution.slnx
```

---

## 6. CORE COMPONENTS & IMPLEMENTATION

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

**Database Configuration (UserConfiguration.cs):**
- **Username:** Max 100 chars, unique index, required
- **Email:** Max 150 chars, unique index, required
- **PasswordHash:** Max 500 chars, required
- **RoleId:** Foreign key to Role table (Restrict delete)
- **Indexes:** Unique constraints on Username and Email

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

**Database Configuration (InvoiceConfiguration.cs):**
- **TotalAmount:** Decimal(18, 2) precision
- **ClientUserId:** Foreign key with Restrict delete behavior
- **CreatedByManagerId:** Foreign key with Restrict delete behavior
- **Relationships:** 
  - One-to-Many with User (ClientInvoices)
  - One-to-Many with User (ManagedInvoices)
  - One-to-Many with Payment

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

**Database Configuration (PaymentConfiguration.cs):**
- **AmountPaid:** Decimal(18, 2) precision
- **PaymentMethod:** Max 50 chars, required
- **Relationships:** Many-to-One with Invoice

#### AuditLog Entity
```csharp
public class AuditLog
{
    public int AuditLogId { get; set; }
    public int UserId { get; set; }
    public string Action { get; set; }
    public string EntityName { get; set; }
    public int? EntityId { get; set; }
    public string? Details { get; set; }
    public DateTime ChangedAt { get; set; }
    public User User { get; set; }
}
```

**Audit Tracking Examples:**
- "User Approved" - When admin approves new user
- "Invoice Created" - When manager creates invoice
- "Payment Recorded" - When payment is added

#### UserApproval Entity
```csharp
public class UserApproval
{
    public int ApprovalId { get; set; }
    public int UserId { get; set; }
    public int ApprovedByUserId { get; set; }
    public int AssignedRoleId { get; set; }
    public DateTime ApprovedAt { get; set; }
    public string? Remarks { get; set; }
    public User User { get; set; }
    public User ApprovedByUser { get; set; }
    public Role AssignedRole { get; set; }
}
```

### 6.2 Enumerations

#### InvoiceStatus Enum
```csharp
public enum InvoiceStatus
{
    Pending = 1,           // Invoice created, awaiting payment
    PartiallyPaid = 2,     // Partial payment received
    Paid = 3,              // Full payment received
    Overdue = 4,           // Past due date without full payment
    Cancelled = 5          // Invoice cancelled
}
```

### 6.3 Services Implementation

#### AuthService
Handles user authentication and registration with password hashing and JWT token generation.

**Methods:**
```csharp
public async Task RegisterAsync(RegisterRequestDto dto)
{
    // 1. Validate username doesn't exist
    // 2. Validate email doesn't exist
    // 3. Hash password using BCrypt
    // 4. Create user with IsApproved = false
    // 5. Save to database
}

public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
{
    // 1. Find user by username
    // 2. Check if approved
    // 3. Verify password using BCrypt
    // 4. Generate JWT token
    // 5. Update LastLoginAt
    // 6. Return token and user info
}
```

**Implementation (FinanceBilling.Infrastructure/Services/AuthService.cs):**
- Uses BCrypt for password verification
- Checks user approval status before login
- Generates JWT token with user ID, username, and role
- Updates LastLoginAt timestamp
- Throws exceptions for validation failures

#### UserService
Manages user accounts and approvals.

```csharp
public async Task<IEnumerable<UserDto>> GetPendingUsersAsync()
{
    // Returns users with IsApproved = false
}

public async Task ApproveUserAsync(int adminUserId, ApproveUserDto dto)
{
    // 1. Find user by UserId
    // 2. Assign RoleId
    // 3. Set IsApproved = true
    // 4. Log audit entry
    // 5. Save changes
}

public async Task<IEnumerable<ClientLookupDto>> GetClientsAsync()
{
    // Returns approved users with Client role
}
```

#### InvoiceService
Manages invoice creation and retrieval.

```csharp
public async Task CreateInvoiceAsync(int managerId, CreateInvoiceDto dto)
{
    // 1. Create invoice with Pending status
    // 2. Set timestamps and manager ID
    // 3. Save to database
    // 4. Log audit entry with amount
}

public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
{
    // Returns all invoices with client details
}

public async Task<IEnumerable<InvoiceDto>> GetClientInvoicesAsync(int clientId)
{
    // Returns invoices for specific client
}
```

#### PaymentService
Handles payment processing and invoice status updates.

```csharp
public async Task AddPaymentAsync(int userId, CreatePaymentDto dto)
{
    // 1. Create payment record
    // 2. Log audit entry
    // 3. Calculate total paid for invoice
    // 4. Update invoice status:
    //    - Paid if total = invoice amount
    //    - Overdue if past due date
    //    - Pending otherwise
    // 5. Save changes
}

public async Task<IEnumerable<PaymentDto>> GetInvoicePaymentsAsync(int invoiceId)
{
    // Returns all payments for specific invoice
}

public async Task<IEnumerable<PaymentDto>> GetAllAsync()
{
    // Returns all payments in system
}
```

**Status Update Logic:**
```csharp
var totalPaid = payments.Sum(x => x.AmountPaid);

if (totalPaid >= invoice.TotalAmount)
{
    invoice.Status = InvoiceStatus.Paid;
}
else if (invoice.DueDate < DateTime.UtcNow)
{
    invoice.Status = InvoiceStatus.Overdue;
}
else
{
    invoice.Status = InvoiceStatus.Pending;
}
```

#### AuditLogService
Manages audit trail retrieval.

```csharp
public async Task<IEnumerable<AuditLogDto>> GetAllAsync()
{
    // Returns all audit logs ordered by timestamp descending
    // Includes username from related User entity
}
```

### 6.4 Repositories

All repositories implement the **Repository Pattern** for clean data access separation.

#### UserRepository
```csharp
public async Task<User?> GetByIdAsync(int userId)
public async Task<User?> GetByUsernameAsync(string username)
public async Task<User?> GetByEmailAsync(string email)
public async Task<IEnumerable<User>> GetPendingUsersAsync()
public async Task<IEnumerable<User>> GetApprovedClientsAsync()
public async Task AddAsync(User user)
public async Task UpdateAsync(User user)
```

#### InvoiceRepository
```csharp
public async Task<Invoice?> GetByIdAsync(int invoiceId)
public async Task<IEnumerable<Invoice>> GetAllAsync()
public async Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId)
public async Task AddAsync(Invoice invoice)
public async Task UpdateAsync(Invoice invoice)
```

#### PaymentRepository
```csharp
public async Task<Payment?> GetByIdAsync(int paymentId)
public async Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId)
public async Task<IEnumerable<Payment>> GetAllAsync()
public async Task AddAsync(Payment payment)
```

#### AuditLogRepository
```csharp
public async Task AddAsync(AuditLog auditLog)
public async Task<IEnumerable<AuditLog>> GetAllAsync()
```

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

Response (200 OK):
"Registration submitted. Awaiting approval."

Implementation:
- Validates username and email uniqueness
- Hashes password with BCrypt
- Creates user with IsApproved = false
- User must await admin approval
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

Response (200 OK):
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "username": "john_doe",
    "role": "Manager"
}

Response (401 Unauthorized):
When credentials invalid or user not approved

Implementation:
- Verifies password using BCrypt
- Checks IsApproved status
- Generates JWT token with user claims
- Updates LastLoginAt timestamp
```

### 7.2 Users Endpoints

#### Get Pending Users
```
GET /api/users/pending
Authorization: Bearer {token}
Role Required: Admin

Response (200 OK):
[
    {
        "userId": 5,
        "username": "pending_user",
        "email": "pending@example.com",
        "isApproved": false
    }
]
```

#### Approve User
```
POST /api/users/approve
Authorization: Bearer {token}
Role Required: Admin

Request:
{
    "userId": 5,
    "roleId": 3
}

Implementation:
- Sets user.RoleId = provided roleId
- Sets user.IsApproved = true
- Creates UserApproval record
- Logs audit entry
```

#### Get All Clients
```
GET /api/users/clients
Authorization: Bearer {token}

Response (200 OK):
[
    {
        "userId": 3,
        "username": "client1",
        "email": "client1@example.com"
    }
]

Returns: Approved users with Client role
```

### 7.3 Invoices Endpoints

#### Create Invoice
```
POST /api/invoices
Authorization: Bearer {token}
Role Required: Manager

Request:
{
    "clientUserId": 3,
    "dueDate": "2026-07-04T10:00:00Z",
    "totalAmount": 5000.00
}

Implementation:
- Sets CreatedByManagerId = current user ID
- Sets InvoiceDate = DateTime.UtcNow
- Sets Status = InvoiceStatus.Pending
- Logs audit entry with amount
- Returns created invoice
```

#### Get All Invoices
```
GET /api/invoices
Authorization: Bearer {token}

Response (200 OK):
[
    {
        "invoiceId": 1,
        "clientUserId": 3,
        "clientName": "client1",
        "totalAmount": 5000.00,
        "status": "Pending",
        "invoiceDate": "2026-06-04T10:00:00Z",
        "dueDate": "2026-07-04T10:00:00Z"
    }
]
```

#### Get Invoice by Client
```
GET /api/invoices/client/{clientId}
Authorization: Bearer {token}

Returns: Invoices for specific client
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

Implementation:
- Creates Payment record
- Sets PaymentDate = DateTime.UtcNow
- Calculates total paid vs invoice amount
- Updates invoice status automatically:
  * Paid if total = invoice.TotalAmount
  * Overdue if past DueDate
  * Pending otherwise
- Logs audit entry
```

#### Get All Payments
```
GET /api/payments
Authorization: Bearer {token}

Response (200 OK):
[
    {
        "paymentId": 1,
        "invoiceId": 1,
        "amountPaid": 2500.00,
        "paymentDate": "2026-06-04T11:30:00Z"
    }
]
```

#### Get Invoice Payments
```
GET /api/payments/invoice/{invoiceId}
Authorization: Bearer {token}

Returns: All payments for specific invoice
```

### 7.5 Audit Logs Endpoints

#### Get All Audit Logs
```
GET /api/auditlogs
Authorization: Bearer {token}
Role Required: Admin

Response (200 OK):
[
    {
        "auditLogId": 1,
        "userId": 1,
        "username": "admin",
        "action": "User Approved",
        "entityName": "User",
        "entityId": 5,
        "details": "Assigned RoleId 3",
        "changedAt": "2026-06-04T10:00:00Z"
    },
    {
        "auditLogId": 2,
        "userId": 2,
        "username": "manager1",
        "action": "Invoice Created",
        "entityName": "Invoice",
        "entityId": 1,
        "details": "Amount: 5000.00",
        "changedAt": "2026-06-04T10:15:00Z"
    }
]
```

---

## 8. DATABASE SCHEMA

### FinanceBillingDbContext Configuration

```csharp
public class FinanceBillingDbContext : DbContext
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserApproval> UserApprovals => Set<UserApproval>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FinanceBillingDbContext).Assembly);
    }
}
```

### Entity Relationships

```
Role (1) ──────────── (M) User
                          ├─ ClientInvoices ────── (M) Invoice
                          ├─ ManagedInvoices ────── (M) Invoice
                          └─ AuditLogs ─────────── (M) AuditLog

                       Invoice (1) ────── (M) Payment

UserApproval
    ├─ User (FK)
    ├─ ApprovedByUser (FK)
    └─ AssignedRole (FK)
```

### Tables Overview

| Table | Purpose | Key Fields |
|-------|---------|-----------|
| **Roles** | User role definitions | RoleId (PK), RoleName (nvarchar(50)) |
| **Users** | User accounts | UserId (PK), Username (unique), Email (unique), PasswordHash, RoleId (FK), IsApproved, IsActive, CreatedAt, LastLoginAt |
| **UserApprovals** | Approval workflow | ApprovalId (PK), UserId (FK), ApprovedByUserId (FK), AssignedRoleId (FK), ApprovedAt, Remarks |
| **Invoices** | Invoice records | InvoiceId (PK), ClientUserId (FK), CreatedByManagerId (FK), InvoiceDate, DueDate, TotalAmount (decimal 18,2), Status (int), CreatedAt |
| **Payments** | Payment records | PaymentId (PK), InvoiceId (FK), AmountPaid (decimal 18,2), PaymentMethod (nvarchar(50)), PaymentDate |
| **AuditLogs** | Audit trail | AuditLogId (PK), UserId (FK), Action (nvarchar(100)), EntityName (nvarchar(100)), EntityId, Details, ChangedAt |

### Connection String
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CapstoneFinanceBillingDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false"
    }
}
```

### Default Seed Data

**Admin User (Created in UserConfiguration):**
```
UserId: 1
Username: admin
Email: admin@financebilling.com
PasswordHash: $2a$11$Qee9OEZPJufoclI.3.Bjc.RehRX3mE/5HdnOmOIdEakPl9Amr/Tvq
RoleId: 1
IsApproved: true
IsActive: true
CreatedAt: 2025-01-01 00:00:00 UTC
```

---

## 9. AUTHENTICATION & SECURITY

### JWT Implementation

#### Token Structure
Header.Payload.Signature

#### JWT Configuration
```json
{
    "Jwt": {
        "Key": "FinanceBillingSecretKey2025@123456789",
        "Issuer": "FinanceBilling.API",
        "Audience": "FinanceBilling.Client",
        "ExpirationMinutes": 60
    }
}
```

#### Token Claims
```csharp
{
    "sub": "1",                    // UserId
    "unique_name": "username",     // Username
    "role": "Manager",             // User Role
    "iss": "FinanceBilling.API",   // Issuer
    "aud": "FinanceBilling.Client" // Audience
}
```

### Password Security

#### BCrypt Implementation
- **Algorithm:** BCrypt with salt
- **Cost Factor:** 11 (configurable)
- **Hashing:** One-way encryption
- **Storage:** Plain text passwords never stored

**PasswordService Methods:**
```csharp
public string HashPassword(string password)
{
    // Uses BCrypt.Net-Next library
    // Generates salt and hashes with cost factor 11
}

public bool VerifyPassword(string password, string hash)
{
    // Compares input password against stored hash
    // Returns true if match, false otherwise
}
```

### Authorization & Role-Based Access Control

#### Role Hierarchy
1. **Admin** (RoleId: 1)
   - Manage users
   - Approve new registrations
   - View all audit logs
   - Full system access

2. **Manager** (RoleId: 2)
   - Create and manage invoices
   - Process payments
   - View audit logs
   - View financial reports

3. **Client** (RoleId: 3)
   - View own invoices
   - View payment history
   - Limited system access

#### Authorization Attributes
```csharp
[Authorize]                      // Requires valid JWT token
[Authorize(Roles = "Admin")]     // Requires Admin role
[Authorize(Roles = "Manager")]   // Requires Manager role
```

### Security Best Practices Implemented

1. **HTTPS/TLS:** All connections encrypted in production
2. **JWT Validation:** Token signature and expiration verified
3. **Password Hashing:** BCrypt with salt for all passwords
4. **SQL Injection Prevention:** Entity Framework Core parameterized queries
5. **XSS Protection:** Input validation and output encoding
6. **CSRF Protection:** Token-based validation
7. **Audit Logging:** All user actions logged with timestamps
8. **Error Handling:** Generic error messages (no sensitive info leakage)
9. **Unique Constraints:** Username and Email have database unique indexes
10. **Access Control:** Role-based authorization on all protected endpoints

---

## 10. CONFIGURATION

### appsettings.json Structure
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CapstoneFinanceBillingDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false"
    },
    "Jwt": {
        "Key": "FinanceBillingSecretKey2025@123456789",
        "Issuer": "FinanceBilling.API",
        "Audience": "FinanceBilling.Client",
        "ExpirationMinutes": 60
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

### Dependency Injection Configuration

**DependencyInjection.cs:**
```csharp
public static IServiceCollection AddInfrastructure(
    this IServiceCollection services)
{
    // Register Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    services.AddScoped<IPaymentRepository, PaymentRepository>();
    services.AddScoped<IAuditLogRepository, AuditLogRepository>();

    // Register Security Services
    services.AddScoped<IPasswordService, PasswordService>();
    services.AddScoped<IJwtTokenService, JwtTokenService>();

    // Register Business Logic Services
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IInvoiceService, InvoiceService>();
    services.AddScoped<IPaymentService, PaymentService>();

    return services;
}
```

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
cd "DotNet_Journey/Capstone Project/FinanceBillingSolution"
```

#### Step 2: Database Setup
```bash
# Create database
sqlcmd -S localhost\SQLEXPRESS -Q "CREATE DATABASE CapstoneFinanceBillingDb"

# Apply migrations
cd FinanceBilling.API
dotnet ef database update --project ../FinanceBilling.Infrastructure
```

#### Step 3: Restore and Build
```bash
dotnet restore
dotnet build
```

#### Step 4: Run Application
```bash
cd FinanceBilling.API
dotnet run
# Application runs on: https://localhost:7000
# Swagger UI: https://localhost:7000/swagger
```

### First Steps with API

#### 1. Register as New User
```bash
curl -X POST https://localhost:7000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "testuser",
    "email": "test@example.com",
    "password": "TestPass@123"
  }'

Response: "Registration submitted. Awaiting approval."
```

#### 2. Login as Admin (Existing)
```bash
curl -X POST https://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "admin",
    "password": "Admin@123"
  }'

Response:
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "username": "admin",
    "role": "Admin"
}
```

#### 3. Approve Pending User
```bash
curl -X POST https://localhost:7000/api/users/approve \
  -H "Authorization: Bearer {ADMIN_TOKEN}" \
  -H "Content-Type: application/json" \
  -d '{
    "userId": 5,
    "roleId": 3
  }'
```

#### 4. Login as Approved User
```bash
curl -X POST https://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "testuser",
    "password": "TestPass@123"
  }'
```

---

## 12. TESTING

### Test Structure

Unit tests are implemented using **xUnit** and **Moq** framework.

#### Test Classes

| Test Class | Test Methods | Coverage |
|-----------|--------------|----------|
| AuthServiceTests | 8 | Register, Login, Password validation |
| UserServiceTests | 5 | User approval, retrieval, client lookup |
| InvoiceServiceTests | 4 | Invoice creation, retrieval, client invoices |
| PaymentServiceTests | 6 | Payment creation, status updates, retrieval |

### Running Tests

#### Using dotnet CLI
```bash
# Run all tests
dotnet test

# Run specific test file
dotnet test Tests/AuthServiceTests.cs

# Run with verbose output
dotnet test --verbosity detailed

# Run with coverage
dotnet test /p:CollectCoverage=true
```

#### Using Visual Studio
1. Open Test Explorer (Test → Test Explorer)
2. Build solution first
3. Click "Run All" button
4. View results in Test Explorer window

### Mock Configuration
Tests use Moq for mocking repository dependencies:
```csharp
var mockUserRepository = new Mock<IUserRepository>();
mockUserRepository
    .Setup(x => x.GetByUsernameAsync("username"))
    .ReturnsAsync(user);

var authService = new AuthService(
    mockUserRepository.Object,
    passwordService,
    jwtTokenService);
```

---

## 13. DEPLOYMENT

### Pre-Deployment Checklist
- [ ] All unit tests passing
- [ ] No compiler warnings
- [ ] Code review completed
- [ ] Database migrations tested
- [ ] Security audit completed
- [ ] JWT secret key changed for production
- [ ] Connection string updated for production DB
- [ ] Error handling verified
- [ ] Logging configured appropriately

### Production Build
```bash
# Build for production
dotnet publish -c Release -o ./publish

# Output location: ./publish folder
```

### Deployment Steps
1. Copy published files to server
2. Update connection string for production database
3. Update JWT configuration for production environment
4. Apply database migrations to production DB
5. Configure HTTPS/SSL certificates
6. Start application service
7. Monitor logs for errors

### Environment Variables
```bash
ConnectionStrings__DefaultConnection=Server=prod-server;Database=FinanceBilling;...
Jwt__Key=ProductionSecretKey...
Jwt__ExpirationMinutes=120
```

---

## 14. BEST PRACTICES

### Code Organization
- Follow SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)
- Use dependency injection for testability
- Implement interface segregation
- Keep classes single-responsibility
- Use repository pattern for data access

### Error Handling
- Catch specific exceptions, not generic Exception
- Log meaningful error messages with context
- Return appropriate HTTP status codes
- Avoid exposing internal implementation details
- Provide user-friendly error messages

### Async/Await
- Use async for all I/O operations
- Avoid blocking calls with .Result or .Wait()
- Properly await all async methods
- Use ConfigureAwait(false) in library code

### Naming Conventions
- **Classes:** PascalCase (UserService, AuthController)
- **Methods:** PascalCase (GetByIdAsync, RegisterAsync)
- **Properties:** PascalCase (Username, InvoiceDate)
- **Private fields:** _camelCase (_userRepository, _passwordService)
- **Parameters:** camelCase (userId, createInvoiceDto)
- **Constants:** UPPER_CASE (CONNECTION_TIMEOUT)

### Database Access
- Use Include() for related data to avoid N+1 queries
- Implement pagination for large result sets
- Use AsNoTracking() for read-only queries
- Validate foreign keys exist before creating relationships
- Use transactions for multi-step operations

### Entity Framework Core
- Configure entities using Fluent API
- Use migrations for schema changes
- Enable lazy loading judiciously
- Use compiled queries for frequently used queries
- Configure column constraints properly

---

## 15. TROUBLESHOOTING

### Common Issues & Solutions

#### Database Connection Error
**Error:** Connection string invalid or database unreachable

**Solutions:**
1. Verify SQL Server is running
2. Check connection string in appsettings.json
3. Ensure database exists: `CapstoneFinanceBillingDb`
4. Verify user has permissions to create/access database
5. Check firewall allows SQL Server connection

#### JWT Token Validation Failed
**Error:** 401 Unauthorized on protected endpoints

**Solutions:**
1. Verify JWT key matches in appsettings.json
2. Check token hasn't expired
3. Ensure Bearer scheme in Authorization header: `Authorization: Bearer {token}`
4. Verify token is properly formatted (Header.Payload.Signature)
5. Check token claims match expected values

#### Migration Not Applied
**Error:** Tables not found in database

**Solutions:**
```bash
# List existing migrations
dotnet ef migrations list

# Create new migration if needed
dotnet ef migrations add MigrationName --project FinanceBilling.Infrastructure

# Apply pending migrations
dotnet ef database update --project FinanceBilling.Infrastructure

# View migration status
dotnet ef database update --project FinanceBilling.Infrastructure -- verbose
```

#### Port Already in Use
**Error:** Unable to start application, port 7000 in use

**Solutions:**
```bash
# Linux/Mac: Find process using port
lsof -i :7000

# Windows: Find process using port
netstat -ano | findstr :7000

# Kill process (Linux/Mac)
kill -9 <PID>

# Kill process (Windows)
taskkill /PID <PID> /F

# Or run on different port
dotnet run --urls https://localhost:7001
```

#### User Not Approved
**Error:** "Account pending approval" when trying to login

**Solutions:**
1. Use admin account to approve user first
2. Call: `POST /api/users/approve` with proper RoleId
3. Then attempt login with new user
4. Check database: `SELECT * FROM Users WHERE Username = 'username'`
5. Verify IsApproved = 1 in database

#### Password Verification Failed
**Error:** Login fails with correct password

**Solutions:**
1. Verify password hashing with BCrypt
2. Check PasswordHash field not corrupted in database
3. Ensure VerifyPassword method working correctly
4. Verify password meets requirements
5. Clear browser cache and retry

#### Entity Validation Errors
**Error:** DbUpdateException on save

**Solutions:**
1. Check all required fields are populated
2. Verify foreign key relationships are valid
3. Check string length constraints
4. Verify decimal precision for amounts
5. Check unique constraints (Username, Email)

#### Missing or Invalid Configuration
**Error:** Configuration section not found

**Solutions:**
1. Verify appsettings.json exists in API project
2. Check JSON syntax is valid
3. Verify all required sections present (ConnectionStrings, Jwt)
4. Check environment-specific config (appsettings.Production.json)
5. Verify User Secrets configured if using Secret Manager

### Debug Checklist
- [ ] Check application logs for errors
- [ ] Verify database connectivity
- [ ] Confirm JWT token validity
- [ ] Check user roles and permissions
- [ ] Review database schema
- [ ] Validate input data
- [ ] Check SQL queries in logs
- [ ] Verify configuration values
- [ ] Test with Swagger UI
- [ ] Use debugger to step through code

---

## CONCLUSION

FinanceBillingSolution is a production-ready financial management system built on modern .NET 8 technologies. It follows industry best practices for security, testing, and architecture, making it scalable, maintainable, and secure.

### Key Achievements
- ✅ Clean Architecture with clear separation of concerns
- ✅ Repository Pattern for flexible data access
- ✅ JWT-based authentication with BCrypt password hashing
- ✅ Role-based authorization with three-tier role structure
- ✅ Comprehensive audit logging for compliance
- ✅ Entity Framework Core with migrations
- ✅ Unit testing with xUnit and Moq
- ✅ RESTful API with Swagger documentation
- ✅ Automatic invoice status updates based on payment logic
- ✅ User approval workflow for registration

### Future Enhancements
- Implement email notifications for invoice creation and payment reminders
- Add dashboard analytics with charts and graphs
- Implement payment gateway integration (Stripe, PayPal)
- Add invoice PDF export functionality
- Implement multi-tenancy support
- Add advanced reporting and filtering
- Implement real-time notifications using SignalR
- Add invoice templates customization
- Implement recurring invoices
- Add API rate limiting and throttling

### Support & Documentation
For more information, refer to:
- Inline code comments throughout the project
- XML documentation on public methods
- GitHub repository: https://github.com/Uday-kumar-06/DotNet_Journey
- Test files for usage examples

---

**Document Version:** 2.0  
**Last Updated:** June 4, 2026  
**Repository:** https://github.com/Uday-kumar-06/DotNet_Journey  
**Status:** Active Development  
**Language Composition:** C# (69.9%), HTML (21.7%), CSS (4.6%), TypeScript (1.4%), JavaScript (1.3%), T-SQL (1.1%)
