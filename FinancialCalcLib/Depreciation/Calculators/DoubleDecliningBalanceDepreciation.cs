﻿namespace FinancialCalcLib.Depreciation.Calculators
{
    /// <summary>
    /// Double declining balance depreciation is a depreciation method that assumes that the asset loses its value 
    /// </summary>
    public class DoubleDecliningBalanceDepreciation : IDepreciationCalculator
    {
        private readonly double initialCost;
        private readonly double residualValue;
        private readonly int usefulLife;
        private readonly double depreciationRate;

        public DoubleDecliningBalanceDepreciation(double initialCost, double residualValue, int usefulLife)
        {
            this.initialCost = initialCost;
            this.residualValue = residualValue;
            this.usefulLife = usefulLife;
            depreciationRate = 2.0 / usefulLife;
        }

        public double CalculateAnnualDepreciation(int year)
        {
            if (year < 1 || year > usefulLife)
            {
                return 0;
            }
            double bookValue = initialCost - (year - 1) * CalculateAnnualDepreciation(year - 1);
            return Math.Max(0, Math.Min(bookValue - residualValue, depreciationRate * bookValue));
        }

        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.Run(() => CalculateAnnualDepreciation(year));
        }
    }

}
