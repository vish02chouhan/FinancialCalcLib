using FinancialCalcLib.Depreciation.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalcLib.Models
{
    using System;
    using FinancialCalcLib.Depreciation.Calculators;
    using FinancialCalcLib.Depreciation.Configuration;

    public class Asset
    {
        public int Id { get; }
        public string Name { get; }
        public IDepreciationCalculator DepreciationCalculator { get; }
        public FinancialCalculationConfiguration? Configuration { get; }

        public Asset(int id, string name, IDepreciationCalculator depreciationCalculator, FinancialCalculationConfiguration configuration)
        {
            Id = id;
            Name = name;
            DepreciationCalculator = depreciationCalculator;
            Configuration = configuration;
        }

        /// <summary>
        /// Constructor for Asset class with DepreciationCalculator parameter of type IDepreciationCalculator interface type.
        ///  This allows for the use of any class that implements the IDepreciationCalculator interface.
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="assetName"></param>
        /// <param name="depreciationCalculator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Asset(int assetId, string assetName, IDepreciationCalculator depreciationCalculator)
        {
            Id = assetId;
            Name = assetName;
            DepreciationCalculator = depreciationCalculator ?? throw new ArgumentNullException(nameof(depreciationCalculator));
        }

        public double CalculateDepreciation(int year)
        {
            return DepreciationCalculator.CalculateAnnualDepreciation(year);
        }

        public string FormatCurrency(double value)
        {

            ArgumentNullException.ThrowIfNull(Configuration, nameof(Configuration));
            return $"{Configuration.CurrencySymbol}{value.ToString("N", Configuration.CultureInfo)}";
        }

        public void PrintDepreciation(int year)
        {
            double depreciation = CalculateDepreciation(year);
            string formattedDepreciation = FormatCurrency(depreciation);
            Console.WriteLine($"Depreciation for year {year}: {formattedDepreciation}");
        }
    }

}
