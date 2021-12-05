# Day 1

- [Puzzle](PUZZLE.md)

Output from [input.txt](day01/input.txt).

**Part 1**

> 1446

**Part 2**

> 1486

---

## Setup

`cabal init`

<!-- `cabal install HUnit` -->
<!-- `cabal install split` -->

## Tests

`mkdir test`

`cd test`

`touch tests.hs`

Update [day01.cabal](day01/day01.cabal) with the *Test-Suite* section.

## Run Tests

`cabal test`

## Run App

`cabal build`

`ghci`

Prelude> `:load app/Main.hs`

Or

`ghci app/Main.hs`

Then run

```bash
*Main> main
```

---

## C#

`cd day01`

`dotnet script solution.csx`

Or

`dotnet script day01/solution.csx`
