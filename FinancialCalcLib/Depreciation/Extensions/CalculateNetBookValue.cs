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
        /// <summary>
        /// Calculates the accumulated depreciation for a given year using the specified depreciation calculator.
        /// </summary>
        /// <param name="calculator">The depreciation calculator used to perform the calculation.</param>
        /// <param name="year">The year for which to calculate the accumulated depreciation.</param>
        /// <returns>The accumulated depreciation for the given year.</returns>
        public static double CalculateAccumulatedDepreciation(this IDepreciationCalculator calculator, int year)
        {
            double accumulatedDepreciation = 0;

            for (int i = 1; i <= year; i++)
            {
                accumulatedDepreciation += calculator.CalculateAnnualDepreciation(i);
            }

            return accumulatedDepreciation;
        }

        /// <summary>
        /// Calculates the book value of an asset for a given year using the specified depreciation calculator.
        /// </summary>
        /// <param name="calculator">The depreciation calculator used to perform the calculation.</param>
        /// <param name="year">The year for which to calculate the book value.</param>
        /// <param name="initialCost">The initial cost of the asset.</param>
        /// <returns>The book value of the asset for the given year.</returns>
        public static double CalculateBookValue(this IDepreciationCalculator calculator, int year, double initialCost)
        {
            double accumulatedDepreciation = calculator.CalculateAccumulatedDepreciation(year);
            double bookValue = initialCost - accumulatedDepreciation;

            return bookValue;
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
