Unit Conversion API
1. Overview

Unit Conversion API is an ASP.NET Core Web API that converts numerical values between different units of measurement.

The API currently supports three conversion categories:

Length: Meter, Kilometer, Centimeter, Millimeter, Mile, Foot, Inch
Weight/Mass: Kilogram, Gram, Milligram, Pound, Ounce, Tonne
Temperature: Celsius, Fahrenheit, Kelvin

The conversion rules are currently hardcoded. The application is designed with separate controllers, models, and services to make future enhancements easier.

2. Technologies Used
C#
ASP.NET Core Web API
.NET 10
RESTful HTTP API
Dependency Injection
Swagger / OpenAPI
xUnit for unit testing
3. Project Structure
UnitConversionApi/
├── Controllers/
│   └── ConversionsController.cs
├── Models/
│   └── ConversionRequest.cs
├── Services/
│   ├── IConversionService.cs
│   └── ConversionService.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── UnitConversionApi.csproj
├── README.md
└── UnitConversionApi.Tests/
    ├── UnitConversionApi.Tests.csproj
    └── ConversionServiceTests.cs

4. Prerequisites

Before running the application, install:

.NET 10 SDK
Visual Studio 2022 or a compatible IDE with support for the target .NET SDK
Postman or Swagger UI for testing the API

Verify your .NET installation:

dotnet --version


Ensure the installed SDK supports the project's target framework.

5. How to Run the Application
Step 1: Open the project

Open the solution in Visual Studio, or navigate to the directory containing UnitConversionApi.csproj.

Step 2: Restore dependencies
dotnet restore

Step 3: Build the project
dotnet build

Step 4: Run the API
dotnet run


The terminal will display the local URLs where the API is listening.

Open the HTTPS URL shown in the terminal and navigate to /swagger if Swagger is enabled in the application.

For example:

https://localhost:7001/swagger


The actual port may differ depending on your launch settings.

6. API Endpoint
Convert a unit

HTTP Method: POST

Endpoint:

/api/conversions/convert


Content-Type: application/json

Request parameters
Parameter	Type	Description
value	number	Value to convert
category	string	length, weight, or temperature
fromUnit	string	Unit to convert from
toUnit	string	Unit to convert to
Example 1: Meters to Kilometers

Request:

POST /api/conversions/convert
Content-Type: application/json

{
  "value": 1000,
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "kilometer"
}


Response:

{
  "originalValue": 1000,
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "kilometer",
  "convertedValue": 1
}

Example 2: Celsius to Fahrenheit

Request:

{
  "value": 100,
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit"
}


Expected converted value:

212

Example 3: Kilograms to Pounds

Request:

{
  "value": 10,
  "category": "weight",
  "fromUnit": "kilogram",
  "toUnit": "pound"
}


Expected converted value:

22.0462262185

7. Error Handling

The API returns HTTP 400 Bad Request for invalid conversion requests, including:

Unsupported conversion categories
Unsupported source or target units
Missing required category or unit names
Non-finite numeric values when supplied to the conversion service

The API returns a JSON error message explaining the problem.

8. Running Unit Tests

If the test project has been created, run all tests from the solution directory:

dotnet test


Unit tests should cover:

Length conversions
Weight conversions
Temperature conversions
Unsupported categories and units
Invalid numeric values
Conversion edge cases
9. Configuration

The appsettings.json file contains application logging and host configuration.

Conversion rules are maintained in ConversionService.cs in the current version.

10. Future Improvements

The application can be extended with:

A configurable unit registry
Database-backed unit definitions
Additional measurement categories
Centralized exception handling
Structured logging
Automated integration tests
CI/CD pipelines

Separating unit definitions from conversion logic would make it easier to manage hundreds of units in the future.

11. License

This project was developed as a unit conversion API coding assignment.