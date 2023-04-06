using FinancialCalcLib.Depreciation.Calculators;
using FinancialCalcLib.Models;

namespace FinancialCalcLib.Tests
{
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
            Assert.That(asset.Id, Is.EqualTo(1));
            Assert.That(asset.Name, Is.EqualTo("Computer"));
            Assert.That(asset.DepreciationCalculator, Is.EqualTo(calculator));
        }

        // Add more tests for other methods and edge cases
    }

    // Create more test classes for other components
}
