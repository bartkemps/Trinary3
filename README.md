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

You can access the trits of a `T3<TItem>` using the `Negative`, `Zero`, and `Positive` fields:

```csharp
string negative = t3.Negative;
string zero = t3.Zero; 
string positive = t3.Positive;
```

Note: The ITrio<TItem> interface provides **properties** Negative, Zero, and Positive to access the trits.
However, for performance reasons, the T3<TItem> struct also exposes these values as **fields**.