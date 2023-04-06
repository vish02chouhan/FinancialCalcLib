using FinancialCalcLib.Depreciation.Calculators;
using NUnit.Framework;

namespace FinancialCalcLib.Tests
{
    [TestFixture]
    public class DoubleDecliningBalanceDepreciationCalculatorTests
    {

        [TestCase(1000, 100, 5, 1, 400)]
        public void DoubleDecliningBalanceDepreciation_CalculateAnnualDepreciation(double initialCost, double residualValue, int usefulLife, int year, double expected)
        {
            var calculator = new DoubleDecliningBalanceDepreciation(initialCost, residualValue, usefulLife);
            double result = calculator.CalculateAnnualDepreciation(year);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

    }

}
