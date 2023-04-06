using FinancialCalcLib.Depreciation.Calculators;
using NUnit.Framework;

namespace FinancialCalcLib.Tests
{
    [TestFixture]
    public class StraightLineDepreciationCalculatorTests
    {
        [TestCase(1000, 100, 5, 1, 180)]
        [TestCase(1000, 100, 5, 2, 180)]
        [TestCase(1000, 100, 5, 5, 180)]
        public void StraightLineDepreciation_CalculateAnnualDepreciation(double initialCost, double residualValue, int usefulLife, int year, double expected)
        {
            var calculator = new StraightLineDepreciation(initialCost, residualValue, usefulLife);
            double result = calculator.CalculateAnnualDepreciation(year);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

    }

}
