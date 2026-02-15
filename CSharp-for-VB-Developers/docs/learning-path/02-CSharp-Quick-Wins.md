# 02 - C# Quick Wins

## Goal

Build confidence with high-value C# syntax and patterns that immediately replace common VB-era coding habits.

## Steps

1. Run the console sample:
   ```bash
   dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj
   ```
2. Identify examples of:
   - String interpolation
   - `var` with clear types
   - Nullable reference awareness
   - LINQ basics
3. Compare with equivalent VB mental model (e.g., loops, conditionals, helper methods).
4. Optional: review WinForms C# project for event syntax contrast.

## Verify

- Learner can explain at least 5 C# constructs used in the sample.
- Learner can map each construct back to old VB-style patterns.
- Console app runs without modification errors.

## Common VB6 pitfalls

- Overusing mutable globals instead of scoped variables.
- Ignoring nullability warnings.
- Rewriting C# in “VB style” instead of embracing expression-based patterns.

## Stretch goals

- Add one small console feature using `record` or `switch` expression.
- Refactor one imperative loop into a LINQ query and discuss readability tradeoffs.
