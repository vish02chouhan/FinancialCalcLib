using FinancialCalcLib.Depreciation.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalcLib.Models
{
    public class Asset
    {
        private string? _assetName;

        public int AssetId { get; }
        public string AssetName
        {
            get => _assetName ?? string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Asset name cannot be null or whitespace.");
                }
                _assetName = value;
            }
        }
        public IDepreciationCalculator DepreciationCalculator { get; }

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
            AssetId = assetId;
            AssetName = assetName ?? throw new ArgumentNullException(nameof(assetName));
            DepreciationCalculator = depreciationCalculator ?? throw new ArgumentNullException(nameof(depreciationCalculator));
        }
    }

}
