# Day 1

- [Puzzle](PUZZLE.md)

## Setup

`cabal init`

<!-- `cabal install HUnit` -->

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

Output from [input.txt](day01/input.txt).

> 1446
