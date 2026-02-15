// Console apps are great for: utilities, batch jobs, tooling, quick experiments.
//
// VB dev note:
// - C# supports "top-level statements": you don't need a Program class.
// - You can still create classes/methods as usual.

Console.WriteLine("ConsoleCSharp: Hello!");

// Example: string interpolation
var name = Environment.UserName;
Console.WriteLine($"Hello, {name}.");

// Example: a small helper method
Console.WriteLine($"2 + 3 = {Add(2, 3)}");

static int Add(int a, int b) => a + b;
