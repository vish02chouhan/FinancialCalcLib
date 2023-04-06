using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialCalcLib.Depreciation.Depreciation;

namespace FinancialCalcLib
{
    /// <summary>
    /// Sum of Years Digits Depreciation Calculator
    /// </summary>

    public class SumOfYearsDigitsDepreciation : IDepreciationCalculator
    {
        private double initialCost;
        private double residualValue;
        private int usefulLife;
        private int sumOfYearsDigits;

        public SumOfYearsDigitsDepreciation(double initialCost, double residualValue, int usefulLife)
        {
            this.initialCost = initialCost;
            this.residualValue = residualValue;
            this.usefulLife = usefulLife;
            this.sumOfYearsDigits = (usefulLife * (usefulLife + 1)) / 2;
        }

        /// <summary>
        /// Calculate the annual depreciation for a given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public double CalculateAnnualDepreciation(int year)
        {
            int remainingLife = usefulLife - year + 1;
            return (initialCost - residualValue) * remainingLife / sumOfYearsDigits;
        }

        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.Run(() => CalculateAnnualDepreciation(year));
        }
    }

}
