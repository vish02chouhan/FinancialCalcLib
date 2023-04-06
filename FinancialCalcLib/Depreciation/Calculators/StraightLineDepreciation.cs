namespace FinancialCalcLib.Depreciation.Calculators
{


    /// <summary>
    /// Straight line depreciation is the simplest form of depreciation. It assumes that the asset loses its value 
    /// at a constant rate over its useful life. 
    /// </summary>
    public class StraightLineDepreciation : DepreciationCalculatorBase
    {
        private readonly double initialCost;
        private readonly double residualValue;
        private readonly int usefulLife;

        public StraightLineDepreciation(double initialCost, double residualValue, int usefulLife)
        {
            this.initialCost = initialCost;
            this.residualValue = residualValue;
            this.usefulLife = usefulLife;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override double CalculateAnnualDepreciation(int year)
        {
            double depreciation = (initialCost - residualValue) / usefulLife;
            OnDepreciationCalculated(year, depreciation);
            return depreciation;
        }
        
    }

}
