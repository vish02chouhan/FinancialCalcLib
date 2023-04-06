using FinancialCalcLib.Depreciation.Delegates;

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

        private readonly Func<double, double>? modifier;

        public StraightLineDepreciation(double initialCost, double residualValue, int usefulLife, Func<double, double>? modifier = null)
        {
            this.initialCost = initialCost;
            this.residualValue = residualValue;
            this.usefulLife = usefulLife;
            this.modifier = modifier;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override double CalculateAnnualDepreciation(int year)
        {

            double depreciation = (initialCost - residualValue) / usefulLife;

            double totalDepreciation = year * depreciation;
            // Apply the modifier if provided
            if (modifier != null)
            {
                totalDepreciation = modifier(totalDepreciation);
            }


            return Math.Min(totalDepreciation, initialCost);
        }

    }

}
