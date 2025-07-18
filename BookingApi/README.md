# Booking API – N-Layer Architecture (.NET 8.0)

## Purpose
An API that allows users to view available homes for a specified date range.

## Technologies
- .NET 8  
- In-memory data storage  
- N-Layer Architecture  
- FluentValidation
- AutoMapper
- Async programming  
- xUnit + Moq for testing
- Serilog
- Swagger (API documentation)

## Usage
1. Clone the repository.
2. Run `dotnet restore`
3. Run `dotnet run`
4. Open Swagger UI in your browser: `https://localhost:<port>/swagger`

## Testing
To run tests: dotnet test

## Architecture
- BookingApi.API/ → Presentation Layer (Controllers).
- BookingApi.Business/ → Business Logic (Services, Interfaces).
- BookingApi.Core/ → Models and Entities.
- BookingApi.DataAccess/ → Data Access (Data, Repositories).

