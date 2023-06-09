﻿using FinancialCalcLib.Depreciation.Calculators;

namespace FinancialCalcLib
{
    /// <summary>
    /// Sum of the Year's Digits (SYD) depreciation is an accelerated depreciation method that allocates a 
    /// larger portion of the asset's cost to the earlier years of its useful life, and a smaller portion to
    /// the later years.This method assumes that an asset's value depreciates more quickly in the earlier 
    /// years of its useful life.
    /// </summary>
    public class SumOfYearsDigitsDepreciation : IDepreciationCalculator
    {

        private readonly double initialCost;
        private readonly double residualValue;
        private readonly int usefulLife;
        private readonly int sumOfYearsDigits;
        
        /// <summary>
        /// Initializes a new instance of the SumOfYearsDigitsDepreciation class with the specified
        /// initial cost, residual value, and useful life.
        /// </summary>
        /// <param name="initialCost">The initial cost of the asset.</param>
        /// <param name="residualValue">The estimated residual value of the asset at the end of its useful life.</param>
        /// <param name="usefulLife">The estimated useful life of the asset in years.</param>
        public SumOfYearsDigitsDepreciation(double initialCost, double residualValue, int usefulLife)
        {
            this.initialCost = initialCost;
            this.residualValue = residualValue;
            this.usefulLife = usefulLife;
            this.sumOfYearsDigits = (usefulLife * (usefulLife + 1)) / 2;
        }

        /// <summary>
        /// Calculates the annual depreciation for the given year using the Sum-of-Years'-Digits method.
        /// </summary>
        /// <param name="year">The year for which to calculate the depreciation, starting from 1.</param>
        /// <returns>The annual depreciation amount for the specified year.</returns>
        public double CalculateAnnualDepreciation(int year)
        {
            int remainingLife = usefulLife - year + 1;
            return (initialCost - residualValue) * remainingLife / sumOfYearsDigits;
        }

        /// <summary>
        /// Calculates the annual depreciation for the given year using the Sum-of-Years'-Digits method asynchronously.
        /// </summary>
        /// <param name="year">The year for which to calculate the depreciation, starting from 1.</param>
        /// <returns>A task representing the asynchronous operation, with the annual depreciation amount for the specified year as the result.</returns>
        public Task<double> CalculateAnnualDepreciationAsync(int year)
        {
            return Task.Run(() => CalculateAnnualDepreciation(year));
        }
    }
}