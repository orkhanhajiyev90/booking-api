# Booking API

## Purpose
An API that allows users to view available homes for a specified date range.

## Technologies
- .NET 8.0  
- In-memory data storage  
- Clean Architecture  
- Async programming  
- Swagger (API documentation)

## Usage
1. Clone the repository.
2. Run `dotnet restore`
3. Run `dotnet run`
4. Open Swagger UI in your browser: `https://localhost:<port>/swagger`

## Testing
To run tests: dotnet test

## Architecture
- Controller: Request routing.
- Service: Business logic (filtering).
- Models: Domain models.
- Data: In-memory storage.
