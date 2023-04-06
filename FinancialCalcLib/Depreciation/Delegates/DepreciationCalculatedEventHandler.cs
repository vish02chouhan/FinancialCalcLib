using FinancialCalcLib.Depreciation.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalcLib.Depreciation.Delegates
{
    /// <summary>  Delegate for the DepreciationCalculated event. </summary>
    public delegate void DepreciationCalculatedEventHandler(object sender, DepreciationCalculatedEventArgs e);
}
