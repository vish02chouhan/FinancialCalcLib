using FinancialCalcLib.Depreciation.Delegates;
using FinancialCalcLib.Depreciation.EventArgs;
using static FinancialCalcLib.Depreciation.Calculators.StraightLineDepreciation;

namespace FinancialCalcLib.Depreciation.Calculators
{
    public abstract class DepreciationCalculatorBase : IDepreciationCalculator
    {

        /// <summary>
        /// Calculate the annual depreciation for a given year. This method must be implemented by the derived class. 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public abstract double CalculateAnnualDepreciation(int year);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.Run(() => CalculateAnnualDepreciation(year));
        }
    }

}
