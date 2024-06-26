# Trinary3

Trinary3 is a library for working with trinary (base-3) numbers in C#. It provides a set of classes and structs for representing trinary numbers and performing operations on them.

## Overview
The Trianary library will made be available as a NuGet package. For now, just include the library.

The main components are:

* The TrinaryNumber static class, containing most of the trinary numeric operations like:
	* Parsing and formatting trinary numbers
	* Performing ternary operations on trinary numbers
* The Trit enum, representing a single trit, having one of the three possible values of a trit: Negative (-1), Zero (0), and Positive (1)
* The ITrio<TItem> interface, representing a triplet of values			.
   Used in conjunction with Trit to represent a trinary number between -13 and 13.
* The T3<TItem> struct, implementing the ITrio<TItem> interface.

# Trinary3 - Formatting and Parsing Operations

Trinary3 provides a set of methods for formatting and parsing trinary numbers. These methods are part of the `TrinaryNumber` static class.

## Formatting Trinary Numbers

The `TrinaryNumber.Format` method converts a number to a trinary string. It supports various numeric types, including `long`, `int`, `short`, `sbyte`, and `BigInteger`.

Here's an example of how to format a `long` as a trinary string:

```csharp
string trinary = TrinaryNumber.Format(6L);  // Returns "1T0"
```


You can also format a number with custom trit characters by using the `TrinarySettings` class:

```csharp
var settings = new TrinarySettings 
{ 
	Positive = 'P', 
	Zero = 'Z', 
	Negative = 'N' 
};
string trinary = TrinaryNumber.Format(6L, settings);  // Returns "PZN"
```


## Parsing Trinary Numbers

The `TrinaryNumber` class provides several methods for parsing trinary numbers from strings, including `ParseToBigInteger`, `ParseToInt64`, `ParseToInt32`, `ParseToInt16`, and `ParseToSByte`. These methods return the parsed number as the corresponding numeric type.

Here's an example of how to parse a trinary string as a `long`:

```csharp
long number = TrinaryNumber.ParseToInt64("1T0");  // Returns 6
```


You can also parse a trinary string with custom trit characters by using the `TrinarySettings` class:

```csharp
var settings = new TrinarySettings 
{
	Positive = 'P', 
	Zero = 'Z', 
	Negative = 'N' 
};
long number = TrinaryNumber.ParseToInt64("PZN", settings);  // Returns 6
```

# Trinary3 - Tritwise Operations

Trinary3 provides a set of methods for performing tritwise operations on trinary numbers. These operations are part of the `TrinaryNumber` static class and are implemented as maps that transform each trit of a number independently.

## Available Operations

Any ITrio<Trit> can be used as a map in for a tritwise operation.
As there are 27 possible trit combinations, there are 27 possible maps.
Three of these maps ignore the input (TTT, 000 and 111)
Others are built in or can be created by combining the following operations:

- (TTT) *This operation ignores the input.*
- (TT0) `DecrementLinearMap`: This operation decreases the trit by one. It does not wrap around: if the input trit is `Negative`, the output is too.
- (TT1) `IsPositiveLinearMap`: This operation sets the trit to `Positive` if it has a `Positive` value, and `Negative` otherwise.
- (T0T) *`Zero` if `Zero`, otherwise `Negative`. `IsZeroLinearMap` -> `MaxZeroLinearMap`*
- (T00) `MaxZeroLinearMap`: This operation sets the trit to `Zero` if it has a `Positive` value, and otherwise leaves it unchanged.
- (T01) `IdentityLinearMap`: This operation does not change the trit.
- (T1T) `IsZeroLinearMap`: This operation sets the trit to `Positive` if it has a `Zero` value, and `Negative` otherwise.
- (T10) *Switches `Zero` and `Positive`. `NegateLinearMap` -> `CircularIncrementLinearMap`*
- (T11) *Is not `Negative`. `IsNegativeLinearMap` -> `NegateLinearMap`*

- (0TT) *`Zero` if `Negative`, otherwise `Negative`. `IsNegativeLinearMap` -> `MaxZeroLinearMap` *
- (0T0) *`Negative` if `Zero`, otherwise `Zero`. `IsZeroLinearMap` -> `CircularIncrementLinearMap`*
- (0T1) *Switches `Zero` and `Negative`. `NegateLinearMap` -> `CircularDecrementLinearMap`*
- (00T) *Negative if Positive, otherwise Zero. `IsPositiveLinearMap` -> `CircularIncrementLinearMap`*
- (000) *This operation ignores the input.*
- (001) `MinZeroLinearMap`: This operation sets the trit to `Zero` if it has a `Negative` value, and otherwise leaves it unchanged.
- (01T) `CircularIncrementLinearMap`: This operation increases the trit by one. It wraps around: if the input trit is Positive, the output is Negative.
- (010) *`Positive` if `Zero`, otherwise 'Zero'. `IsZeroLinearMap` -> `MinZeroLinearMap`*
- (011) `IncrementLinearMap`: This operation increases the trit by one. It does not wrap around: if the input trit is Positive, the output is too.

- (1TT) `IsNegativeLinearMap`: This operation sets the trit to `Positive` if it has a `Negative` value, and `Negative` otherwise.
- (1T0) `CircularDecrementLinearMap`: This operation decreases the trit by one. It wraps around: if the input trit is `Negative`, the output is `Positive`				.
- (1T1) `HasValueLinearMap`: This operation sets the trit to `Positive` if it has a non-zero value, and `Negative` otherwise.
- (10T) `NegateLinearMap`: This operation `Negates` the trit: it is set to `Negative` if `Positive`, `Positive` if `Negative`, and `Zero` if `Zero`.
- (100) *`Positive` if `Negative`, otherwise `zero`. `IsNegativeLinearMap` -> `MinZeroLinearMap`*
- (101) *`Zero` if `Zero`, otherwise `Positive`. `IsZeroLinearMap` -> `CircularDecrementLinearMap`*
- (11T) *Is not `Positive`. `IsPositiveLinearMap` -> `NegateLinearMap`*
- (110) *`Zero` if `Positive`, otherwise `Positive`. `IsPositiveLinearMap` -> `CircularDecrementLinearMap`*
- (111) *This operation ignores the input.*

## Performing Operations

To perform a tritwise operation on a number, you can use the `TritwiseMap` method. This method takes a number and a map, and applies the map to each trit of the number.

Here's an example of how to negate a trinary number:

```csharp
long number = 6;  // ¹⁰6 = ³1T0  (9 - 3 + 0)
long negated = TrinaryNumber.TritwiseMap(number, TrinaryNumber.NegateLinearMap);  // Returns -6, which is T10 in trinary
```

You can also specify a minimum number of trits for the result. If the result has fewer trits than this minimum, it is padded with zeros before performing the operations.
This is important because many operations change zero trits to negative or positive trits. In that case, the ultimate result is dependent on the number of trits processed.

```csharp
/// ³01T0 = ¹⁰6 (0 + 9 - 3 + 0)
long number = 6;
/// IsPositive sets every trit that's Positive to Positive
/// and every trit that's not Positive to Negative
/// ³01T0 becomes ³T1TT, which equals ¹⁰-22 (-27 + 9 - 3 - 1)
long isPositive = TrinaryNumber.TritwiseMap(number, TrinaryNumber.IsPositiveLinearMap, 4); 
```


## More Examples

For more examples of how to use the formatting and parsing operations in Trinary3, please refer to the unit tests included with the library.


## A trio of items: `T3<TItem> : ITrio<TItem>`

Many things come in three, represented by an instance of the `T3<TItem>` struct. This struct represents a trinary number as a trio of values, with `Negative` being the most significant trit, `Zero` being the second most significant trit, and `Positive` being the least significant trit.

Here's an example of how to create a `T3<int>`:

```csharp
var trit = new T3<string>("Red", "Yellow", "Blue");
console.WriteLine(trit.Negative); // Output: "Red"
console.WriteLine(trit.Zero); // Output: "Yellow"
console.WriteLine(trit.Positive); // Output: "Blue"
```

You can also create a `T3<TItem>` from an array of `TItem`:

```csharp
var values = new int[] { "Red", "Yellow", "Blue" }
var trit = new T3<string>(values);
console.WriteLine(trit.Negative); // Output: "Red"
console.WriteLine(trit.Zero); // Output: "Yellow"
console.WriteLine(trit.Positive); // Output: "Blue"
```

Or you can implicitly convert an array of `TItem` to a `T3<TItem>`:

```csharp
var values = new int[] { "Red", "Yellow", "Blue" }
T3<string> trit = values;
console.WriteLine(trit.Negative); // Output: "Red"
console.WriteLine(trit.Zero); // Output: "Yellow"
console.WriteLine(trit.Positive); // Output: "Blue"
```

Note that if you provide fewer than three values, the remaining trits will be set to the default value of `TItem`. 
As "Negative" is considered the most significant trit, the default value of `TItem` is used for the missing trits.

```csharp
var values = new int[] { "Red", "Yellow" }
var trit = new T3<string>(values);
Console.WriteLine(trit.Negative); // Output: nothing (default value of string)
Console.WriteLine(trit.Zero); // Output: "Red"
Console.WriteLine(trit.Positive); // Output: "Yellow"
```

## Accessing Trits

You can access the trits of a `T3<TItem>` using the `Negative`, `Zero`, and `Positive` fields or with a Trit indexer:

Note: The ITrio<TItem> interface provides **properties** Negative, Zero, and Positive to access the trits.
However, for performance reasons, the T3<TItem> struct also exposes these values as **fields**.

```csharp
var t3 = new T3<string>("Red", "Yellow", "Blue");
string red = (ITrio<Trit>)t3.Negative; // using tye property defined in the interface
string yellow = t3.Zero; // field access
string blue = t3[Trit.Positive]; // indexer access
```

