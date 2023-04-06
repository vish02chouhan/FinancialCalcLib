namespace FinancialCalcLib.Depreciation.Depreciation
{

    public interface IDepreciationCalculator
    {
        double CalculateAnnualDepreciation(int year);
        Task<double> CalculateAnnualDepreciationAsync(int year);

    }

}
