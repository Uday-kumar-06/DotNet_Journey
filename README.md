# 🚀 DotNet Journey

> A complete, hands-on learning path through the .NET ecosystem — from C# fundamentals to cloud-ready applications.

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

---

## 📖 About This Repository

This repository documents my complete learning journey through the **Microsoft .NET ecosystem**. It covers everything from the very basics of C# programming to building production-ready, cloud-deployed applications using modern .NET practices. Each folder represents a milestone in the journey — with code, notes, and mini-projects.

---

## 🗺️ Learning Roadmap
---

## 📚 Curriculum Breakdown

### ✅ Phase 1 — C# Fundamentals
> *The foundation of everything .NET*

| Topic | Description |
|-------|-------------|
| Variables & Data Types | `int`, `string`, `bool`, `double`, `decimal`, `var`, `dynamic` |
| Operators | Arithmetic, Logical, Comparison, Bitwise, Ternary |
| Control Flow | `if/else`, `switch`, `while`, `for`, `foreach`, `do-while` |
| Methods & Parameters | Value types, Reference types, `ref`, `out`, `params`, optional params |
| Arrays & Collections | `Array`, `List<T>`, `Dictionary<K,V>`, `Queue`, `Stack`, `HashSet<T>` |
| Strings | String methods, interpolation, `StringBuilder`, verbatim strings |
| Exception Handling | `try/catch/finally`, custom exceptions, `throw`, `when` filters |
| Nullable Types | `int?`, `??`, `?.`, `??=` null-coalescing operators |
| Tuples & Deconstruction | Named tuples, pattern deconstruction |
| LINQ Basics | `Where`, `Select`, `OrderBy`, `GroupBy`, `FirstOrDefault`, `Any`, `All` |

---

### ✅ Phase 2 — Object-Oriented Programming (OOP)
> *Master the pillars of C# design*

| Topic | Description |
|-------|-------------|
| Classes & Objects | Constructors, destructors, properties, fields, access modifiers |
| Encapsulation | `private`, `public`, `protected`, `internal`, auto-properties |
| Inheritance | Base/derived classes, `virtual`, `override`, `sealed`, `base` keyword |
| Polymorphism | Method overriding, method overloading, runtime vs compile-time |
| Abstraction | `abstract` classes, interfaces, `IDisposable`, `IEnumerable<T>` |
| Static Members | Static classes, static methods, singleton pattern |
| Generics | Generic classes, methods, constraints (`where T : class`) |
| Records | `record`, `record struct`, immutability, `with` expressions |
| Enums & Structs | Value types, bitwise enums, custom structs |
| Delegates & Events | `Action`, `Func`, `Predicate`, custom delegates, `event` keyword |

---

### ✅ Phase 3 — Advanced C# Concepts
> *Level up with modern C# features*

| Topic | Description |
|-------|-------------|
| Async/Await | `Task`, `Task<T>`, `async/await`, `ConfigureAwait`, `CancellationToken` |
| LINQ Advanced | Method syntax vs query syntax, deferred execution, `IQueryable` |
| Extension Methods | Adding behavior to existing types without modifying them |
| Expression Trees | `Expression<Func<T>>`, dynamic query building |
| Reflection | `Type`, `Assembly`, `MethodInfo`, inspecting metadata at runtime |
| Attributes | Built-in attributes, custom attributes, `[Obsolete]`, `[Required]` |
| Pattern Matching | `is`, `switch` expressions, positional patterns, property patterns |
| Iterators | `yield return`, custom iterators, `IEnumerable` implementations |
| Span & Memory | `Span<T>`, `Memory<T>`, stack allocation for performance |
| Nullable Reference Types | `#nullable enable`, `!` null-forgiving operator, nullable warnings |

---

### ✅ Phase 4 — .NET Core & the Runtime
> *Understanding how .NET actually works*

| Topic | Description |
|-------|-------------|
| .NET vs .NET Framework | History, differences, cross-platform support |
| SDK & CLI | `dotnet new`, `dotnet run`, `dotnet build`, `dotnet publish` |
| Project Structure | `.csproj`, `Program.cs`, `launchSettings.json`, `appsettings.json` |
| Dependency Injection | `IServiceCollection`, `AddTransient/Scoped/Singleton`, DI containers |
| Configuration System | `IConfiguration`, `appsettings.json`, environment variables, secrets |
| Logging | `ILogger<T>`, log levels, Serilog, structured logging |
| Options Pattern | `IOptions<T>`, `IOptionsSnapshot<T>`, strongly-typed config |
| Middleware Pipeline | Request pipeline, custom middleware, `Use`, `Run`, `Map` |
| Hosting | `IHostBuilder`, `IHostedService`, background services |
| NuGet Packages | Adding, managing, versioning, creating packages |

---

### ✅ Phase 5 — ASP.NET Core Web Development
> *Build modern web apps and APIs*

| Topic | Description |
|-------|-------------|
| MVC Pattern | Controllers, Views, Models, routing, `ViewResult`, `JsonResult` |
| Razor Pages | Page model, `@page`, `@model`, `PageModel`, `OnGet/OnPost` |
| Razor Syntax | `@{}`, `@Model`, `@Html`, Tag Helpers, Partial Views, Layouts |
| Routing | Attribute routing, conventional routing, route constraints, areas |
| Filters | Action filters, authorization filters, exception filters |
| Model Binding | Form data, query strings, route values, body binding |
| Data Validation | `DataAnnotations`, FluentValidation, model state |
| Static Files | `wwwroot`, `UseStaticFiles`, bundling and minification |
| Session & Cookies | `ISession`, `HttpContext.Response.Cookies`, TempData |
| SignalR | Real-time communication, Hubs, WebSockets, groups |

---

### ✅ Phase 6 — REST API Development
> *Build production-grade APIs*

| Topic | Description |
|-------|-------------|
| Web API Basics | `[ApiController]`, `[HttpGet/Post/Put/Delete]`, action results |
| HTTP Status Codes | `Ok()`, `Created()`, `BadRequest()`, `NotFound()`, `NoContent()` |
| Routing & Versioning | Route templates, API versioning (`/api/v1/`), versioning libraries |
| Request/Response | DTOs, `AutoMapper`, request validation, response shaping |
| Swagger / OpenAPI | `Swashbuckle`, `NSwag`, XML comments, Swagger UI |
| Minimal APIs | `app.MapGet/Post`, endpoint groups, route handlers (**.NET 6+**) |
| API Best Practices | HATEOAS, pagination, filtering, sorting, error responses |
| Rate Limiting | Built-in rate limiting middleware (.NET 7+) |
| Versioning Strategies | URL, header, query string versioning |
| gRPC | Protocol Buffers, `grpc-dotnet`, streaming |

---

### ✅ Phase 7 — Entity Framework Core (ORM)
> *Database access the .NET way*

| Topic | Description |
|-------|-------------|
| EF Core Setup | `DbContext`, `DbSet<T>`, connection strings, providers |
| Code First | Defining models → generating DB schema |
| Data Annotations | `[Key]`, `[Required]`, `[MaxLength]`, `[Column]`, `[Table]` |
| Fluent API | `modelBuilder`, relationships, indexes, constraints |
| Migrations | `Add-Migration`, `Update-Database`, migration history |
| Querying | LINQ to EF, `Include`, `ThenInclude`, eager/lazy/explicit loading |
| CRUD Operations | `Add`, `Update`, `Remove`, `SaveChanges`, `SaveChangesAsync` |
| Relationships | One-to-One, One-to-Many, Many-to-Many |
| Raw SQL | `FromSqlRaw`, `ExecuteSqlRaw`, stored procedures |
| Performance | `AsNoTracking`, compiled queries, batching, connection pooling |

---

### ✅ Phase 8 — Authentication & Authorization
> *Securing your applications*

| Topic | Description |
|-------|-------------|
| ASP.NET Core Identity | User management, roles, claims, `UserManager`, `SignInManager` |
| JWT Authentication | Generating, validating, refreshing JSON Web Tokens |
| OAuth 2.0 | Authorization code flow, client credentials |
| OpenID Connect | External login providers (Google, Microsoft, GitHub) |
| Cookie Authentication | `AddCookie`, `SignInAsync`, sliding expiration |
| Policy-Based Auth | Custom requirements, handlers, `[Authorize(Policy="")]` |
| Role-Based Auth | `[Authorize(Roles="Admin")]`, role seeding |
| Claims Transformation | `IClaimsTransformation`, enriching user claims |
| IdentityServer / Duende | Full OAuth/OIDC server setup |
| Secrets Management | `dotnet user-secrets`, Azure Key Vault |

---

### ✅ Phase 9 — Design Patterns & Architecture
> *Write code that scales and lasts*

| Pattern | Description |
|---------|-------------|
| Repository Pattern | Abstracting data access layer |
| Unit of Work | Grouping DB operations into a single transaction |
| CQRS | Command Query Responsibility Segregation with MediatR |
| Mediator Pattern | Decoupled request handling via `MediatR` |
| Clean Architecture | Domain, Application, Infrastructure, Presentation layers |
| Onion Architecture | Dependency inversion from core outward |
| Factory Pattern | Object creation abstraction |
| Decorator Pattern | Behavior wrapping without modifying source |
| Observer Pattern | Event-driven design |
| Domain-Driven Design (DDD) | Aggregates, value objects, domain events |

---

### ✅ Phase 10 — Testing
> *Confidence through test coverage*

| Topic | Description |
|-------|-------------|
| Unit Testing | `xUnit`, `NUnit`, `MSTest`, `[Fact]`, `[Theory]`, `[InlineData]` |
| Mocking | `Moq`, `NSubstitute`, mocking dependencies |
| Integration Testing | `WebApplicationFactory`, in-memory DB, `HttpClient` testing |
| Test Doubles | Fakes, stubs, mocks, spies |
| FluentAssertions | Readable test assertions |
| Code Coverage | Coverlet, Visual Studio coverage tools |
| BDD | SpecFlow, Gherkin syntax, Given/When/Then |
| Performance Testing | `BenchmarkDotNet`, profiling |
| Test Organization | AAA pattern (Arrange, Act, Assert), test naming conventions |
| Contract Testing | Pact .NET, consumer-driven contracts |

---

### ✅ Phase 11 — Background Jobs & Messaging
> *Async processing and event-driven systems*

| Topic | Description |
|-------|-------------|
| Hosted Services | `IHostedService`, `BackgroundService`, worker services |
| Hangfire | Fire-and-forget, recurring jobs, job queues, dashboard |
| Quartz.NET | Cron-based job scheduling |
| RabbitMQ | Message brokers, exchanges, queues, consumers with `MassTransit` |
| Azure Service Bus | Topics, subscriptions, message sessions |
| MassTransit | Abstraction over messaging infrastructure |
| Event-Driven Architecture | Domain events, integration events, eventual consistency |
| Worker Services | `.NET Generic Host`, long-running background workers |
| Channels | `System.Threading.Channels` for producer-consumer patterns |

---

### ✅ Phase 12 — Caching & Performance
> *Make it fast*

| Topic | Description |
|-------|-------------|
| In-Memory Caching | `IMemoryCache`, cache options, eviction policies |
| Distributed Caching | `IDistributedCache`, Redis with `StackExchange.Redis` |
| Response Caching | `[ResponseCache]`, `Cache-Control` headers |
| Output Caching | .NET 7+ output caching middleware |
| Redis | Strings, hashes, lists, pub/sub, TTL |
| HTTP Client Factory | `IHttpClientFactory`, named/typed clients, Polly integration |
| Polly | Retry, circuit breaker, timeout, fallback policies |
| Profiling | MiniProfiler, Application Insights, dotnet-trace |
| Benchmarking | `BenchmarkDotNet`, micro-benchmarking |

---

### ✅ Phase 13 — Containerization & Deployment
> *Ship it to production*

| Topic | Description |
|-------|-------------|
| Docker | Dockerfile, multi-stage builds, `.dockerignore` |
| Docker Compose | Multi-container apps, services, networks, volumes |
| Health Checks | `AddHealthChecks()`, `/health` endpoint, readiness/liveness |
| CI/CD | GitHub Actions, Azure DevOps pipelines |
| Azure App Service | Deploy .NET apps to Azure |
| Azure Container Apps | Serverless containers in Azure |
| Kubernetes (basics) | Pods, deployments, services, ingress |
| Environment Config | `ASPNETCORE_ENVIRONMENT`, `Development/Staging/Production` |
| Secrets in Production | Azure Key Vault, environment variable injection |
| Logging & Monitoring | Application Insights, Serilog sinks, OpenTelemetry |

---

## 🏗️ Projects Built

| # | Project | Tech Used | Description |
|---|---------|-----------|-------------|
| 1 | **Student Management System** | C#, Console | CRUD with OOP, file I/O |
| 2 | **Library API** | ASP.NET Core, EF Core, SQLite | Full REST API with Swagger |
| 3 | **Auth System** | ASP.NET Identity, JWT | Login, Register, Role-based access |
| 4 | **Task Manager App** | Clean Architecture, CQRS, MediatR | Full MVC app with Repository pattern |
| 5 | **Real-time Chat** | SignalR, Razor Pages | WebSocket-based chat rooms |
| 6 | **Ecommerce API** | Minimal APIs, EF Core, Redis | Product catalog, cart, orders |
| 7 | **Background Job Processor** | Hangfire, Worker Service, RabbitMQ | Async email/notification processing |
| 8 | **Dockerized Microservice** | Docker, GitHub Actions, Azure | Containerized + deployed API |

---
