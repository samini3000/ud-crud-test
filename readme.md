# UD CRUD Test - Project Specification

## Project Objective

Develop a production-ready Customer Relationship Management (CRM) system implementing Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS), and Clean Architecture principles. This document outlines the technical specifications, architectural patterns, and implementation requirements.

## System Requirements

The system must provide:

1. Complete Customer management functionality (CRUD operations)
2. Strict enforcement of business rules for data integrity
3. Event-driven architecture for system extensibility
4. Soft-deletion mechanism for data retention
5. Clean separation of concerns across architectural layers
6. RESTful API endpoints for all customer operations
7. Appropriate error handling and validation

## Technical Requirements

### Technology Stack

- **Backend**:
  - .NET 9.0
  - Entity Framework Core 9.0
  - Dapper for queries
  - SQL Server (or PostgreSQL with minimal changes)
  - MediatR for CQRS implementation
  - FluentValidation for validation
  - Serilog for logging
  - xUnit, Moq, and FluentAssertions for testing (for integration or end-to-end tests use TestContainers on docker)

- **Development Tools**:
  - Visual Studio or JetBrains Rider
  - Deployment using Docker for containerization or .NET ASPIRE
  - Git for version control

## Architecture Specification

The solution must strictly adhere to a clean, onion architecture with the following layers:

### 1. Core Layer

#### 1.1 Domain Layer

Implement the domain layer with the following components:

- **Aggregate Roots**:
  - Create a `Customer` aggregate root that inherits from a generic `AggregateRoot<TId>` base class
  - Implement soft-delete capability via `ISoftDelete` interface
  - Encapsulate all domain logic and state changes in the aggregate

- **Value Objects**:
  - Create strongly-typed, immutable value objects for all customer properties:
    - `FirstName`: String with appropriate validation
    - `LastName`: String with appropriate validation
    - `DateOfBirth`: Date type with age validation
    - `PhoneNumber`: Complex type with country code and number parts
    - `Email`: String with email format validation
    - `BankAccountNumber`: String with appropriate format validation
  - Implement `ValueObject` base class with equality comparison based on property values

- **Domain Events**:
  - Implement the following domain events:
    - `CustomerCreatedDomainEvent`
    - `CustomerUpdatedDomainEvent`
    - `CustomerDeletedDomainEvent`
    - `CustomerRestoredDomainEvent`
  - Events must capture all relevant state changes

- **Business Rules**:
  - Implement validation rules as separate classes adhering to `IBusinessRule` interface:
    - `CustomerEmailMustBeUniqueRule`: Ensures email uniqueness
    - `CustomerPersonalInfoMustBeUniqueRule`: Ensures no duplicate customers with same name and birth date
  - Rules must be checked during both creation and updates

- **Domain Services**:
  - Implement `ICustomerUniquenessCheckerService` for validating customer uniqueness constraints
  - Domain services must be abstracted through interfaces

#### 1.2 Application Layer

Implement the application layer with these components:

- **Commands**:
  - `CreateCustomerCommand`: Creates a new customer
  - `UpdateCustomerCommand`: Updates an existing customer
  - `DeleteCustomerCommand`: Soft-deletes a customer
  - `RestoreCustomerCommand`: Restores a soft-deleted customer
  - All commands must include appropriate validation

- **Command Handlers**:
  - Implement handlers for each command
  - Handlers must orchestrate domain operations and persistence

- **Queries**:
  - `GetCustomerByIdQuery`: Gets customer by ID
  - `GetCustomersListQuery`: Gets paginated list of customers
  - `GetCustomerByEmailQuery`: Gets customer by email

- **Query Handlers**:
  - Implement handlers for each query
  - Return appropriate DTO models, not domain entities

- **DTOs**:
  - Create data transfer objects for all API responses
  - DTOs must not expose domain implementation details

- **Behaviors**:
  - Implement cross-cutting concerns as MediatR behaviors:
    - `ValidationBehavior`: For FluentValidation integration
    - `LoggingBehavior`: For command/query execution logging

### 2. Infrastructure Layer

Implement the infrastructure layer with these components:

- **Persistence**:
  - Entity Framework Core DbContext
  - Repository implementations
  - Entity configurations and mappings
  - Migration scripts

- **Processing**:
  - Domain event dispatching
  - Background jobs (if needed)

- **Resilience**:
  - Retry policies for external service calls
  - Circuit breaker patterns

- **Serialization**:
  - JSON serialization configuration

### 3. Presentation Layer

Implement the presentation layer with these components:

- **API Controllers**:
  - RESTful endpoints for all customer operations
  - Proper status codes and error responses
  - API documentation via Swagger

## Implementation Requirements

### Customer Aggregate Implementation

The `Customer` aggregate must:

1. Be implemented as a rich domain model with encapsulated business logic
2. Have private setters for all properties to enforce invariants
3. Use factory methods for creation with full validation
4. Implement the following public methods:
   - `Create`: Static factory method that validates and creates a new customer
   - `ChangeAttribute`: Updates customer properties with full validation
   - `Delete`: Implements soft-deletion
   - `Restore`: Reverts soft-deletion

Example signature for the `Create` method:

```csharp
public static Customer Create(
    FirstName firstName,
    LastName lastName,
    DateOfBirth dateOfBirth,
    PhoneNumber phoneNumber,
    Email email,
    BankAccountNumber bankAccountNumber,
    ICustomerUniquenessCheckerService customerUniquenessCheckerService
);
```

### Domain Events Implementation

Domain events must:

1. Inherit from a common `DomainEventBase` class
2. Be raised during appropriate state changes in the aggregate
3. Contain all relevant information about the state change
4. Be handled by separate event handlers in the application layer

### Business Rules Implementation

Business rules must:

1. Be implemented as separate classes implementing `IBusinessRule` interface
2. Have an `IsBroken()` method that returns a boolean
3. Provide a meaningful error message when broken
4. Be checked during domain operations using a `CheckRule` method

### CQRS Implementation

CQRS implementation must:

1. Strictly separate commands (write operations) from queries (read operations)
2. Use MediatR as the mediator pattern implementation
3. Implement commands as request objects with validators
4. Implement queries as request objects with handlers
5. Return Result objects from command handlers
6. Return DTOs from query handlers

### Validation Implementation

Validation must be implemented at multiple levels:

1. Domain-level validation through business rules
2. Application-level validation through FluentValidation
3. API-level validation through ModelState validation
4. Infrastructure-level validation through database constraints

## Testing Requirements

Implement comprehensive test suite including:

1. **Unit Tests**:
   - Domain logic testing
   - Command and query handler testing
   - Validation testing

2. **Integration Tests**:
   - Repository testing
   - API controller testing

3. **End-to-End Tests**:
   - Complete API flow testing

## Deliverables

1. Complete .NET solution with all components described above
2. Database initialization and migration scripts
3. Docker containerization
4. Comprehensive test suite
5. API documentation with Swagger
6. Deployment instructions
7. Code documentation

## Acceptance Criteria

The solution will be accepted when:

1. All CRUD operations for customers function correctly
2. All business rules are properly enforced
3. All tests pass with >90% code coverage
4. The solution follows the specified architecture
5. The API is properly documented
6. The solution can be deployed using the provided instructions

## Implementation Timeline

- **Day 1**: Core domain models and business rules
- **Day 2**: Application layer and CQRS implementation
- **Day 3**: Infrastructure layer implementation
- **Day 4**: API and presentation layer
- **Day 5**: Testing
- **Day 6**: Deployment
- **Day 7**: Refactoring and documentation

## Architecture Reference Diagram

The solution should adhere to this architectural structure:

```
src/
├── Core/
│   ├── Domain/
│   │   ├── Aggregates/
│   │   │   └── Customer/
│   │   │       ├── Entities/
│   │   │       ├── ValueObjects/
│   │   │       ├── Events/
│   │   │       ├── Rules/
│   │   │       ├── Services/
│   │   │       └── Specifications/
│   │   ├── SeedWork/
│   │   │   ├── Primitives/
│   │   │   ├── Events/
│   │   │   └── Specification/
│   │   └── SharedKernel/
│   └── Application/
│       ├── Features/
│       │   └── Customer/
│       │       ├── Commands/
│       │       ├── Queries/
│       │       └── Models/
│       └── Behaviors/
├── Infrastructure/
│   └── Persistence/
│       ├── Context/
│       ├── Repositories/
│       └── EntityConfiguration/
└── Presentation/
    └── API/
        ├── Controllers/
        └── Filters/
```

## Contribution Guidelines

This project follows strict contribution guidelines to maintain code quality and consistency. See [CONTRIBUTION.md](CONTRIBUTION.md) for full details.

### Development Workflow

1. Create an Issue
2. Create a Branch
3. Make Changes & Commit
4. Create Pull Request
5. Address Reviews
6. Merge & Release

### Branch Naming Convention

All branches should follow this format:
```
<type>([optional-scope])/descriptive-name
```

Example branch names:
- `feat/user-auth`
- `fix/login-error`
- `docs/api-guide`
- `refactor/auth-flow`

### Commit & PR Convention

We follow [Conventional Commits](https://www.conventionalcommits.org/) with the following format:
```
type(scope): <emoji> <description>
```

#### Commit Types with Examples

- **feat**: `feat: 🚀 implement user authentication`
- **fix**: `fix: 🐛 resolve login timeout issue`
- **docs**: `docs: 📄 update API documentation`
- **refactor**: `refactor: ♻️ simplify authentication flow`
- **test**: `test: 🧪 add integration tests`
- **chore**: `chore: 🧰 clean unused code`
- **style**: `style: 🎨 format JavaScript files`
- **perf**: `perf: ⚡️ optimize database queries`
- **build**: `build: 🏗️ update webpack configuration`
- **ci**: `ci: 👷 setup GitHub Actions`
- **revert**: `revert: ⏪️ revert user authentication`

### Version Impact

- **Major** (1.x.x): Breaking changes (with `breaking-changes` label or `!` notation)
- **Minor** (x.1.x): New features (`feat` type)
- **Patch** (x.x.1): Bug fixes and other changes

### Code Standards

- Keep commits atomic and focused
- Follow existing code style
- Add tests for new features
- Update documentation
- Use `dotnet format` and `dotnet csharpier .` before committing

## Project Submission Instructions

As a developer implementing this project, follow these steps to submit your work:

### Initial Setup

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <repository-name>
   ```

2. Create a new branch for your implementation:
   ```bash
   git checkout -b feat/customer-management-implementation
   ```

### Development Process

1. Implement the project following all the requirements specified in this document.

2. Make regular commits following the commit convention documented in the Contribution Guidelines:
   ```bash
   git add .
   git commit -m "feat: 🚀 implement customer aggregate"
   ```

3. Push your changes to the remote repository:
   ```bash
   git push origin feat/customer-management-implementation
   ```

### Submission

1. Once implementation is complete, create a pull request to the main branch:
   - Go to the repository on GitHub
   - Click "Pull requests" > "New pull request"
   - Set base branch to `main` and compare branch to your `feat/customer-management-implementation`
   - Click "Create pull request"

2. In the pull request description:
   - Provide a summary of the implemented features
   - Mention any design decisions or trade-offs made
   - List any pending items or known issues

3. Add `pouryanoufallah96` as a reviewer for your pull request

4. Be prepared to address any feedback or requested changes from the reviewer

### Review Process

1. The reviewer will assess your implementation against the requirements and acceptance criteria.
2. You may need to make additional changes based on feedback.
3. Once approved, your implementation will be merged into the main branch.
