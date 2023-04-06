using FinancialCalcLib.Depreciation.Calculators;
using FinancialCalcLib.Models;
using NUnit.Framework;

namespace FinancialCalcLib.Tests
{
    public class AssetTests
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
        public void Asset_Constructor_SetsProperties()
        {
            // Arrange
            var asset = new Asset(1, "Computer", calculator);

            // Act
            // (no action needed)

            // Assert
            Assert.That(asset.Id, Is.EqualTo(1));
            Assert.That(asset.Name, Is.EqualTo("Computer"));
            Assert.That(asset.DepreciationCalculator, Is.EqualTo(calculator));
        }


        [Test]
        public void Asset_GetAccumulatedDepreciation_CorrectValue()
        {
            // Arrange
            var asset = new Asset(1, "Computer", calculator);

            // Act
            double accumulatedDepreciation = asset.CalculateDepreciation(3);

            // Assert
            Assert.That(accumulatedDepreciation, Is.EqualTo(540.0));
        }


    }
}
