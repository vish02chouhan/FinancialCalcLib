using FinancialCalcLib.Depreciation.Calculators;
using FinancialCalcLib.Models;
using NUnit.Framework;

namespace FinancialCalcLib.Tests
{
    public class StraightLineDepreciationTests
    {
        [Test]
        public void CalculateAnnualDepreciation_ReturnsCorrectValue()
        {
            // Arrange
            var calculator = new StraightLineDepreciation(1000, 100, 5);

            // Act
            var annualDepreciation = calculator.CalculateAnnualDepreciation(1);

            // Assert
            Assert.AreEqual(180, annualDepreciation);
        }

        // Add more tests for other methods and edge cases
    }

    public class AssetTests
    {
        [Test]
        public void Asset_Constructor_SetsProperties()
        {
            // Arrange
            var calculator = new StraightLineDepreciation(1000, 100, 5);
            var asset = new Asset(1, "Computer", calculator);

            // Act
            // (no action needed)

            // Assert
            Assert.AreEqual(1, asset.AssetId);
            Assert.AreEqual("Computer", asset.AssetName);
            Assert.AreEqual(calculator, asset.DepreciationCalculator);
        }

        // Add more tests for other methods and edge cases
    }

    // Create more test classes for other components
}
