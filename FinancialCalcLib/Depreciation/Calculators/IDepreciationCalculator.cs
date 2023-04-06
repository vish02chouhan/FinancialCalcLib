namespace FinancialCalcLib.Depreciation.Calculators
{

    public interface IDepreciationCalculator
    {
        double CalculateAnnualDepreciation(int year);
        Task<double> CalculateAnnualDepreciationAsync(int year);

    }

}
