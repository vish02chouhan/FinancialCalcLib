namespace FinancialCalcLib.Depreciation.EventArgs
{
    /// <summary>  Event information to be passed to the DepreciationCalculatedEventHandler. </summary> 
    public class DepreciationCalculatedEventArgs : System.EventArgs
    {
        public int Year { get; }
        public double Depreciation { get; }

        public DepreciationCalculatedEventArgs(int year, double depreciation)
        {
            Year = year;
            Depreciation = depreciation;
        }
    }

}
