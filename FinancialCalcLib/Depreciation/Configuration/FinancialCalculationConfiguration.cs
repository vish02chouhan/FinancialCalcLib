using FinancialCalcLib.Depreciation.Calculators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalcLib.Depreciation.Configuration
{
    public class FinancialCalculationConfiguration
    {
        public string CurrencySymbol { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public Dictionary<string, double> TaxRates { get; set; }
        public IDepreciationCalculator DepreciationCalculator { get; set; }

        public FinancialCalculationConfiguration()
        {
            CurrencySymbol = "$";
            CultureInfo = CultureInfo.InvariantCulture;
            TaxRates = new Dictionary<string, double>();
            DepreciationCalculator = new StraightLineDepreciation(1000, 100, 5);
        }
    }

}
