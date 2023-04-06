using BenchmarkDotNet.Attributes;
using FinancialCalcLib.Depreciation.Calculators;

namespace FinancialCalcLib.Benchmarks
{
    public class DepreciationCalculatorsBenchmark
    {
        private readonly IDepreciationCalculator straightLineCalculator;
        private readonly IDepreciationCalculator doubleDecliningBalanceCalculator;
        private readonly IDepreciationCalculator sumOfYearsDigitsCalculator;

        public DepreciationCalculatorsBenchmark()
        {
            double initialCost = 1000;
            double residualValue = 100;
            int usefulLife = 5;

            straightLineCalculator = new StraightLineDepreciation(initialCost, residualValue, usefulLife);
            doubleDecliningBalanceCalculator = new DoubleDecliningBalanceDepreciation(initialCost, residualValue, usefulLife);
            sumOfYearsDigitsCalculator = new SumOfYearsDigitsDepreciation(initialCost, residualValue, usefulLife);
        }

        [Benchmark]
        public double StraightLineDepreciationBenchmark() => straightLineCalculator.CalculateAnnualDepreciation(3);

        [Benchmark]
        public double DoubleDecliningBalanceDepreciationBenchmark() => doubleDecliningBalanceCalculator.CalculateAnnualDepreciation(3);

        [Benchmark]
        public double SumOfYearsDigitsDepreciationBenchmark() => sumOfYearsDigitsCalculator.CalculateAnnualDepreciation(3);
    }
}
