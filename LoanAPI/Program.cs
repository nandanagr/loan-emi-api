using LoanApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Loan EMI API is running");

app.MapGet("/emi", (decimal amount, decimal rate, int years) =>
{
    try
    {
        var emi = EmiCalculator.CalculateEmi(amount, rate, years);
        var totalPayment = Math.Round(emi * years * 12, 2);
        var totalInterest = Math.Round(totalPayment - amount, 2);

        return Results.Ok(new
        {
            amount,
            rate,
            years,
            monthlyEmi = emi,
            totalPayment,
            totalInterest
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();