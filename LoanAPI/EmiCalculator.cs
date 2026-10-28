namespace LoanApi;

public static class EmiCalculator
{
    public static decimal CalculateEmi(decimal principal, decimal annualRatePercent, int years)
    {
        if (principal <= 0)
            throw new ArgumentException("Loan amount must be greater than zero.");
        if (annualRatePercent < 0)
            throw new ArgumentException("Interest rate cannot be negative.");
        if (years <= 0)
            throw new ArgumentException("Years must be greater than zero.");

        int months = years * 12;

        // With 0% interest the formula divides by zero, so handle it separately
        if (annualRatePercent == 0)
            return Math.Round(principal / months, 2);

        double monthlyRate = (double)annualRatePercent / 12 / 100;
        double factor = Math.Pow(1 + monthlyRate, months);
        double emi = (double)principal * monthlyRate * factor / (factor - 1);

        return Math.Round((decimal)emi, 2);
    }
}