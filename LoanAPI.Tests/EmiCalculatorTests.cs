using LoanApi;
using Xunit;

namespace LoanApi.Tests;

public class EmiCalculatorTests
{
    [Fact]
    public void CalculateEmi_StandardLoan_ReturnsExpectedEmi()
    {
        // Arrange: set up the inputs
        decimal amount = 500000m;
        decimal rate = 9m;
        int years = 5;

        // Act: run the code being tested
        decimal emi = EmiCalculator.CalculateEmi(amount, rate, years);

        // Assert: check the result (expected is about 10379.18)
        Assert.InRange(emi, 10000m, 10380m);
    }

    [Fact]
    public void CalculateEmi_ZeroInterest_DividesPrincipalEvenly()
    {
        decimal emi = EmiCalculator.CalculateEmi(120000m, 0m, 1);

        Assert.Equal(10000m, emi);
    }

    [Fact]
    public void CalculateEmi_ZeroPrincipal_Throws()
    {
        Assert.Throws<ArgumentException>(() => EmiCalculator.CalculateEmi(0m, 9m, 5));
    }

    [Fact]
    public void CalculateEmi_NegativeRate_Throws()
    {
        Assert.Throws<ArgumentException>(() => EmiCalculator.CalculateEmi(100000m, -1m, 5));
    }
}