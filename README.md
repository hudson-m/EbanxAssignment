# EbanxAssignment

## Overview

The EbanxAssignment is a .NET-based project designed to demonstrate the implementation of basic bank transactions, as requested by part of the EBANX team.

## Project Structure

- **EbanxAssignment.Application**: Contains the application logic, including services and application-level interfaces.
- **EbanxAssignment.Domain**: Holds the core domain models and interfaces that define the business logic.
- **EbanxAssignment.Infrastructure**: Implements the repository patterns and other services that interact with external systems like databases.
- **EbanxAssignment.Web**: The presentation layer, which serves as the entry point for the application, containing the controllers and the web API endpoints.

## Technologies Used

- **.NET 8.0**
- **Entity Framework Core**
- **ASP.NET Core Web API**

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/hudson-m/EbanxAssignment.git
2. Navigate to the project directory:
   ```bash
   cd EbanxAssignment
3. Build the solution:
   ```bash
   dotnet build
### Running the Application

To run the application locally, navigate to the `EbanxAssignment.Web` directory and use the following command:

```bash
dotnet run
```
The API will be available at `http://localhost:80`.