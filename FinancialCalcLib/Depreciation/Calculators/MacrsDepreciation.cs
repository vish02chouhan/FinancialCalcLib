namespace FinancialCalcLib.Depreciation.Calculators
{
    // This implementation of MACRS assumes that the depreciation rates are provided externally.
    /// <summary>
    /// MACRS depreciation is a method of depreciation that is used to calculate the depreciation of an asset
    /// </summary>
    public class MacrsDepreciation : IDepreciationCalculator
    {
        private readonly double initialCost;
        private readonly Dictionary<int, double> depreciationRates;

        public MacrsDepreciation(double initialCost, Dictionary<int, double> depreciationRates)
        {
            this.initialCost = initialCost;
            this.depreciationRates = depreciationRates;
        }

        /// <summary>
        ///  Calculates the annual depreciation for a given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public double CalculateAnnualDepreciation(int year)
        {
            if (depreciationRates.ContainsKey(year) == true)
            {
                return initialCost * depreciationRates[year];
            }

            return 0;
        }
        
        /// <summary>
        ///  
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.FromResult(CalculateAnnualDepreciation(year));
        }


    }
}
