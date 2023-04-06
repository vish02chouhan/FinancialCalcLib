using FinancialCalcLib.Depreciation.Delegates;
using FinancialCalcLib.Depreciation.EventArgs;

namespace FinancialCalcLib.Depreciation.Depreciation
{
    public abstract class DepreciationCalculatorBase : IDepreciationCalculator
    {
        public event DepreciationCalculatedEventHandler DepreciationCalculated = delegate { };

        public abstract double CalculateAnnualDepreciation(int year);

        protected virtual void OnDepreciationCalculated(int year, double depreciation)
        {
            DepreciationCalculated?.Invoke(this, new DepreciationCalculatedEventArgs(year, depreciation));
        }

        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.Run(() => CalculateAnnualDepreciation(year));
        }

    }

}
