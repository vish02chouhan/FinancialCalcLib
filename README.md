FinancialCalcLib: Technical Documentation
=========================================

Overview
--------

FinancialCalcLib is a C# library for performing various financial calculations, primarily focused on asset depreciation. It offers a flexible and extensible architecture, allowing users to employ different depreciation methods and work with custom assets.

Features
--------

*   Supports multiple depreciation methods:
    *   Straight-Line Depreciation
    *   Double Declining Balance Depreciation
    *   Sum of Years' Digits Depreciation
    *   Modified Accelerated Cost Recovery System (MACRS) Depreciation
*   Calculates depreciation schedules for individual assets or multiple assets concurrently
*   Provides extensibility to incorporate custom depreciation methods
*   Asynchronous and multithreaded support for better performance

Folder Structure
----------------


FinancialCalcLib/ 
├── Depreciation/
│   ├── Calculators/
│   │   ├── IDepreciationCalculator.cs
│   │   ├── DepreciationCalculatorBase.cs
│   │   ├── StraightLineDepreciation.cs
│   │   ├── DoubleDecliningBalanceDepreciation.cs
│   │   ├── SumOfYearsDigitsDepreciation.cs
│   │   └── MacrsDepreciation.cs
│   ├── EventArgs/
│   │   ├── DepreciationCalculatedEventArgs.cs
│   ├── Extensions/
│   │   ├── DepreciationCalculatorExtensions.cs
│   └── Delegates/
│       └── DepreciationCalculatedEventHandler.cs
├── Models/
│   └── Asset.cs
└── DepreciationScheduleItem.cs

Key Components
--------------

### Models

#### Asset

Represents an individual asset with an associated depreciation calculator. Assets have an ID, name, and depreciation calculator.

### Depreciation

#### Calculators

##### IDepreciationCalculator

The interface for implementing depreciation calculators. Contains methods for calculating annual depreciation and depreciation schedules.

##### DepreciationCalculatorBase

An abstract base class implementing the `IDepreciationCalculator` interface. This class includes common properties like asset cost, salvage value, and useful life, as well as the `DepreciationCalculated` event.

##### StraightLineDepreciation

Implements the straight-line depreciation method, derived from the `DepreciationCalculatorBase` class.

##### DoubleDecliningBalanceDepreciation

Implements the double declining balance depreciation method, derived from the `DepreciationCalculatorBase` class.

##### SumOfYearsDigitsDepreciation

Implements the sum of years' digits depreciation method, derived from the `DepreciationCalculatorBase` class.

##### MacrsDepreciation

Implements the Modified Accelerated Cost Recovery System (MACRS) depreciation method, derived from the `DepreciationCalculatorBase` class.

#### EventArgs

##### DepreciationCalculatedEventArgs

A custom event args class used with the `DepreciationCalculated` event, containing information about the calculated depreciation.

#### Extensions

##### DepreciationCalculatorExtensions

Extension methods for the `IDepreciationCalculator` interface to calculate accumulated depreciation and to support async calculations.

#### Delegates

##### DepreciationCalculatedEventHandler

A delegate for handling the `DepreciationCalculated` event, which is triggered when a depreciation calculation is completed.

### DepreciationScheduleItem

A class representing an individual item in a depreciation schedule, containing the year, annual depreciation, and accumulated depreciation.

Usage
-----

1.  **Create an `Asset` object with an associated depreciation calculator:**
    
    csharpCopy code
    
    `Asset asset = new Asset(1, "Computer", new StraightLineDepreciation(1000, 100, 5));`
    
2.  **Calculate the depreciation schedule for an asset:**
