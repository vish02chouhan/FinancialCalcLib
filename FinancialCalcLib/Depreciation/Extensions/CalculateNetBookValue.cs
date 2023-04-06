using FinancialCalcLib.Depreciation.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalcLib.Depreciation.Extensions
{
    public static class DepreciationCalculatorExtensions
    {
        public static double CalculateAccumulatedDepreciation(this IDepreciationCalculator calculator, int years)
        {
            double accumulatedDepreciation = 0;

            for (int year = 1; year <= years; year++)
            {
                accumulatedDepreciation += calculator.CalculateAnnualDepreciation(year);
            }

            return accumulatedDepreciation;
        }

        public static double CalculateNetBookValue(this IDepreciationCalculator calculator, double initialCost, int year)
        {
            double accumulatedDepreciation = calculator.CalculateAccumulatedDepreciation(year);
            return initialCost - accumulatedDepreciation;
        }

        public static int CalculateRemainingUsefulLife(int currentYear, int totalUsefulLife)
        {
            return Math.Max(0, totalUsefulLife - currentYear);
        }

        public static double CalculateTotalDepreciationExpense(this IDepreciationCalculator calculator, int usefulLife)
        {
            return calculator.CalculateAccumulatedDepreciation(usefulLife);
        }

        public static List<DepreciationScheduleItem> CalculateDepreciationSchedule(this IDepreciationCalculator calculator, int usefulLife)
        {
            var schedule = new List<DepreciationScheduleItem>();

            for (int year = 1; year <= usefulLife; year++)
            {
                double annualDepreciation = calculator.CalculateAnnualDepreciation(year);
                double accumulatedDepreciation = calculator.CalculateAccumulatedDepreciation(year);
                schedule.Add(new DepreciationScheduleItem(year, annualDepreciation, accumulatedDepreciation));
            }

            return schedule;
        }

        public class DepreciationScheduleItem
        {
            public int Year { get; }
            public double AnnualDepreciation { get; }
            public double AccumulatedDepreciation { get; }

            public DepreciationScheduleItem(int year, double annualDepreciation, double accumulatedDepreciation)
            {
                Year = year;
                AnnualDepreciation = annualDepreciation;
                AccumulatedDepreciation = accumulatedDepreciation;
            }
        }



    }
}
