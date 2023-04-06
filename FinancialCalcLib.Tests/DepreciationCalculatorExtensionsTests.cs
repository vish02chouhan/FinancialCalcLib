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
        public void CalculateAccumulatedDepreciation_ValidYear_ReturnsAccumulatedDepreciation()
        {
            double result = calculator.CalculateAccumulatedDepreciation(3);
            Assert.That(result, Is.EqualTo(540));
        }

        [Test]
        public void CalculateBookValue_ValidYear_ReturnsBookValue()
        {
            double result = calculator.CalculateBookValue(3, 1000);
            Assert.That(result, Is.EqualTo(460));
        }

        [Test]
        public void CalculateRemainingUsefulLife_ValidCurrentYear_ReturnsRemainingUsefulLife()
        {
            int result = DepreciationCalculatorExtensions.CalculateRemainingUsefulLife(3, 5);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CalculateTotalDepreciationExpense_ValidUsefulLife_ReturnsTotalDepreciationExpense()
        {
            double result = calculator.CalculateTotalDepreciationExpense(5);
            Assert.That(result, Is.EqualTo(900));
        }

        [Test]
        public void CalculateDepreciationSchedule_ValidUsefulLife_ReturnsDepreciationSchedule()
        {
            List<DepreciationCalculatorExtensions.DepreciationScheduleItem> result = calculator.CalculateDepreciationSchedule(5);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Year, Is.EqualTo(1));
            Assert.That(result[0].AnnualDepreciation, Is.EqualTo(180));
            Assert.That(result[0].AccumulatedDepreciation, Is.EqualTo(180));

            Assert.That(result[4].Year, Is.EqualTo(5));
            Assert.That(result[4].AnnualDepreciation, Is.EqualTo(180));
            Assert.That(result[4].AccumulatedDepreciation, Is.EqualTo(900));
        }
    }
}
