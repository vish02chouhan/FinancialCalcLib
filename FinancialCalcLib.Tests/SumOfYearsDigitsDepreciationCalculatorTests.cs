using FinancialCalcLib.Depreciation.Calculators;
using NUnit.Framework;

namespace FinancialCalcLib.Tests
{
    [TestFixture]
    public class SumOfYearsDigitsDepreciationCalculatorTests
    {

        [TestCase(1000, 100, 5, 1, 300)]
        public void SumOfYearsDigitsDepreciation_CalculateAnnualDepreciation(double initialCost, double residualValue, int usefulLife, int year, double expected)
        {
            var calculator = new SumOfYearsDigitsDepreciation(initialCost, residualValue, usefulLife);
            double result = calculator.CalculateAnnualDepreciation(year);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }
    }

}
