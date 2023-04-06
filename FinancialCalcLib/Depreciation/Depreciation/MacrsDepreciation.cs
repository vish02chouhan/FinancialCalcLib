namespace FinancialCalcLib.Depreciation.Depreciation
{
    // This implementation of MACRS assumes that the depreciation rates are provided externally.
    public class MacrsDepreciation : IDepreciationCalculator
    {
        private readonly double initialCost;
        private readonly Dictionary<int, double> depreciationRates;

        public MacrsDepreciation(double initialCost, Dictionary<int, double> depreciationRates)
        {
            this.initialCost = initialCost;
            this.depreciationRates = depreciationRates;
        }

        public double CalculateAnnualDepreciation(int year)
        {
            if (depreciationRates.ContainsKey(year) == true)
            {
                return initialCost * depreciationRates[year];
            }

            return 0;
        }
        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.FromResult(CalculateAnnualDepreciation(year));
        }


    }
}
