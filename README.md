# Loan EMI Calculator API

![CI](https://github.com/nandanagr/loan-emi-api/actions/workflows/ci.yml/badge.svg)

A small ASP.NET Core Web API that calculates the monthly EMI for a loan.
Built to practise Docker and CI/CD with GitHub Actions.

## Endpoint

```
GET /emi?amount=500000&rate=9&years=5
```

Example response:

```json
{
  "amount": 500000,
  "rate": 9,
  "years": 5,
  "monthlyEmi": 10379.18,
  "totalPayment": 622750.8,
  "totalInterest": 122750.8
}
```

Invalid input (for example amount=0) returns HTTP 400 with an error message.

## Run locally

```bash
cd LoanAPI
dotnet run
```

## Run with Docker

```bash
docker build -t loanapi ./LoanAPI
docker run -d -p 8080:8080 --name loanapi loanapi
```

Then open `http://localhost:8080/emi?amount=500000&rate=9&years=5`.

## Run the tests

```bash
dotnet test
```

## CI pipeline

On every push to `main`, GitHub Actions:

1. Builds the project
2. Runs the unit tests (xUnit)
3. Builds the Docker image and publishes it to GitHub Container Registry (only if tests pass)

## Tech

C#, ASP.NET Core, xUnit, Docker, GitHub Actions