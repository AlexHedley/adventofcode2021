# 🎄 Advent of Code (2021) 🎄

[Advent Of Code](https://adventofcode.com/) [2021](https://adventofcode.com/2021/)

---

![Haskell](https://img.shields.io/badge/Haskell-5e5086?style=for-the-badge&logo=haskell&logoColor=white)

## Solutions

- [Day 1](day01/README.md)

<!-- [![For: Advent Of Code](https://img.shields.io/badge/for-advent_of_code-green.svg)](https://adventofcode.com/) -->
<!-- [![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey.svg)](https://opensource.org/licenses/MIT)  -->

<!-- https://github.com/marketplace/actions/aoc-badges -->
<!-- ![](https://img.shields.io/badge/day%20📅-6-blue) -->
<!-- ![](https://img.shields.io/badge/stars%20⭐-12-yellow) -->
<!-- ![](https://img.shields.io/badge/days%20completed-6-red) -->

This repo contains my solutions to the [Advent of Code 2021](https://adventofcode.com/2021) using primarily [Haskell](https://www.haskell.org).

The code will likely be bad. :p

## Setup

See [WIKI](https://github.com/AlexHedley/adventofcode2021/wiki) for setup instructions for [Haskell](https://www.haskell.org).

## Running Solutions/Tests

Any tests I write will likely just be asserts in each solution file.

How to run the solution file for each day depends on the language.

### Haskell

`cabal build`

`ghci`

Prelude> `:load app/Main.hs`

or

`ghci app/Main.hs`

Then run

```bash
*Main> main
```

### C#

Any C# scripts will require [dotnet-script](https://github.com/filipw/dotnet-script).

For C# solutions `dotnet script dayXX/solution.csx`
