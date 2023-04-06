using BenchmarkDotNet.Running;
using FinancialCalcLib.Benchmarks;

namespace FinancialCalcLibBenchmarkRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DepreciationCalculatorsBenchmark>();
        }
    }
}
