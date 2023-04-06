using FinancialCalcLib.Depreciation.Calculators;
using FinancialCalcLib.Depreciation.Extensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FinancialCalcLib.Tests
{
    public class DepreciationCalculatorExtensionsTests
    {
        private IDepreciationCalculator calculator;

        [SetUp]
        public void Setup()
        {
            double initialCost = 1000;
            double residualValue = 100;
            int usefulLife = 5;
            calculator = new StraightLineDepreciation(initialCost, residualValue, usefulLife);
        }

        [Test]
        public void CalculateRemainingUsefulLife_ValidCurrentYear_ReturnsRemainingUsefulLife()
        {
            int result = DepreciationCalculatorExtensions.CalculateRemainingUsefulLife(3, 5);
            Assert.That(result, Is.EqualTo(2));
        }



    }
}
