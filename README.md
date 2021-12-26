# 🎄 Advent of Code (2021) 🎄

[Advent Of Code](https://adventofcode.com/) [2021](https://adventofcode.com/2021/)

---

![Haskell](https://img.shields.io/badge/Haskell-5e5086?style=for-the-badge&logo=haskell&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

## Ranking

Private Leaderboard

<!-- 20-  84 **■°°■*°°°°° -->
<!-- 18- 109 **■°°■*°°°°°°°°°°°°°■ -->
<!-- 17- 134 **■°°■*°°°°°°°°°°°°°■■ -->
<!-- 17- 144 **■■°■*°°°°°°°°°°°°°■■°° -->
<!-- 17- 155 **■*°■*°°°°°°°°°°°°°■■°° -->
15- 181 * * ■ * ° ■ * ° ° ° ° ° ° ° ° ° ° ° ° ° ■ ■ ° ° ■

Key: * Both | ■ One | ° None |

## Solutions

- [Day 1](day01/README.md)
- [Day 2](day02/README.md)
- [Day 3](day03/README.md)
- [Day 4](day04/README.md)
<!-- - [Day 5](day05/README.md) -->
- [Day 6](day06/README.md)
- [Day 7](day07/README.md)
<!-- - [Day 8](day08/README.md) -->
<!-- - [Day 9](day09/README.md) -->
<!-- - [Day 10](day10/README.md) -->
<!-- - [Day 11](day11/README.md) -->
<!-- - [Day 12](day12/README.md) -->
<!-- - [Day 13](day13/README.md) -->
<!-- - [Day 14](day14/README.md) -->
<!-- - [Day 15](day15/README.md) -->
<!-- - [Day 16](day16/README.md) -->
<!-- - [Day 17](day17/README.md) -->
<!-- - [Day 18](day18/README.md) -->
<!-- - [Day 19](day19/README.md) -->
<!-- - [Day 20](day20/README.md) -->
- [Day 21](day21/README.md)
- [Day 22](day22/README.md)
<!-- - [Day 23](day23/README.md) -->
<!-- - [Day 24](day24/README.md) -->
- [Day 25](day25/README.md)

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

Or if you have dependencies

`cabal repl`

Then run

```bash
*Main> main
```

### C#

Any C# scripts will require [dotnet-script](https://github.com/filipw/dotnet-script).

For C# solutions `dotnet script dayXX/solution.csx`
