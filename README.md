# Elementary Cellular Automaton (ECA) — C# & TDD

A clean, zero-dependency C# implementation of Stephen Wolfram's one-dimensional **Elementary Cellular Automaton**, built from scratch using **Test-Driven Development (TDD)** with MSTest.

## Overview

An Elementary Cellular Automaton consists of a one-dimensional grid of cells, where each cell has two possible states (`0` or `1`)[cite: 6]. At each discrete time step, every cell updates its state simultaneously based on a transition function $S_{n+1} = f(s_n^L, s_n, s_n^R)$ that takes into account the current state of the cell and its immediate left and right neighbors[cite: 2, 3, 6].

Because a neighborhood of 3 binary cells has $2^3 = 8$ possible configurations (`000` to `111`), there are $2^8 = 256$ possible Wolfram transition rules (Rule 0 to Rule 255)[cite: 9].

## Mathematical & Algorithmic Approach (No String Conversions)

Instead of converting rule numbers into binary strings, this implementation uses direct base-2 arithmetic:

1. **Rule Decomposition (`O(1)` Lookup Table):**
   In the `ElementaryAutomaton` constructor, the rule number ($0..255$) is decomposed into an 8-element integer array (`ruleTable[8]`) using repeated modulo (`rule % 2`) and integer division (`rule /= 2`).
2. **Neighborhood Indexing:**
   For any cell and its neighbors `(left, current, right)`, the 3-bit binary configuration is converted into its decimal index ($0..7$) via base-2 positional weights[cite: 9, 24]:
   ```csharp
   int number = left * 4 + current * 2 + right;
   return ruleTable[number];