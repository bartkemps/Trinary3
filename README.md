# Trinary3

Trinary3 is a library for working with trinary (base-3) numbers in C#. It provides a set of classes and structs for representing trinary numbers and performing operations on them.

## Getting Started

To use Trinary3, you first need to create an instance of the `T3<TItem>` struct. This struct represents a trinary number as a trio of values, with `Negative` being the most significant trit, `Zero` being the second most significant trit, and `Positive` being the least significant trit.

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

## Performing Operations

Trinary3 provides a set of map classes for performing operations on trinary numbers. Each map class implements the `ITrio<Trit>` interface and overrides the indexer property to perform a specific operation.