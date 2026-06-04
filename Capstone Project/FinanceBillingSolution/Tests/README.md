# FinanceBilling.Tests

xUnit test suite for the FinanceBilling Capstone Project.

## Structure

| File | Tests for |
|---|---|
| `AuthServiceTests.cs` | Register (duplicate username/email, happy path) · Login (user not found, not approved, wrong password, success, LastLoginAt update) |
| `InvoiceServiceTests.cs` | CreateInvoice (correct fields, audit log) · GetAll · GetClientInvoices |
| `PaymentServiceTests.cs` | AddPayment (invoice not found, fully paid → Paid, partial → Pending, past due → Overdue, audit log) · GetAll · GetInvoicePayments |
| `UserServiceTests.cs` | GetPendingUsers · ApproveUser (not found, fields set, audit log) · GetClients |

## Setup

1. Copy this folder into `Capstone Project/FinanceBillingSolution/` alongside the other projects.
2. The `FinanceBilling.Tests.csproj` already references the three sibling projects (`API`, `Core`, `Infrastructure`).
3. Moq is added as a NuGet dependency — no extra install needed.

## Run

```bash
dotnet test
```

Or inside Visual Studio / Rider, use the Test Explorer.

## Notes

- All tests use **Moq** to mock repositories and services — no database required.
- The `PaymentMethod` property in `CreatePaymentDto` is a `string`; if you later change it to the `PaymentMethod` enum, update the `AddPaymentAsync` test setup accordingly.
