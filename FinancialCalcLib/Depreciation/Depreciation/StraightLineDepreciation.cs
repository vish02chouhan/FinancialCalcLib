namespace FinancialCalcLib.Depreciation.Depreciation
{
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

        public override double CalculateAnnualDepreciation(int year)
        {
            double depreciation = (initialCost - residualValue) / usefulLife;
            OnDepreciationCalculated(year, depreciation);
            return depreciation;
        }
        
    }

}
