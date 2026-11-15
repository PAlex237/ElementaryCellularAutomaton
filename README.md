# Elementary Cellular Automaton (ECA) — C# & TDD

A clean, zero-dependency C# implementation of Stephen Wolfram's one-dimensional **Elementary Cellular Automaton**, built from scratch using **Test-Driven Development (TDD)** with MSTest.

## Overview

An Elementary Cellular Automaton consists of a one-dimensional grid of cells, where each cell has two possible states (`0` or `1`)[cite: 6]. At each discrete time step, every cell updates its state simultaneously based on a transition function $S_{n+1} = f(s_n^L, s_n, s_n^R)$ that takes into account the current state of the cell and its immediate left and right neighbors[cite: 2, 3, 6].

Because a neighborhood of 3 binary cells has $2^3 = 8$ possible configurations (`000` to `111`), there are $2^8 = 256$ possible Wolfram transition rules (Rule 0 to Rule 255)[cite: 9].

## Mathematical & Algorithmic Approach (No String Conversions)

Instead of converting rule numbers into binary strings, this implementation uses direct base-2 arithmetic:

1. **Rule Decomposition (`O(1)` Lookup Table):**
   In the `ElementaryAutomaton` constructor, the rule number (`0..255`) is decomposed into an 8-element integer array (`ruleTable[8]`) using repeated modulo (`rule % 2`) and integer division (`rule /= 2`)[cite: 24].
2. **Neighborhood Indexing:**
   For any cell and its neighbors `(left, current, right)`, the 3-bit binary configuration is converted into its decimal index (`0..7`) via base-2 positional weights[cite: 9, 24]:
   ```csharp
   int number = left * 4 + current * 2 + right;
   return ruleTable[number];
   ```
3. **Boundary Condition (Edges):**
   The grid uses a **Fixed-Zero Boundary** strategy: cells outside the left (`i == 0`) and right (`i == Length - 1`) boundaries are permanently treated as state `0`[cite: 6].
4. **Synchronous State Updates:**
   Each call to `NextGeneration(int[] currentGeneration)` allocates a new state array to ensure all cells transition simultaneously from generation $n$ to $n+1$ without mutating the current state in-place[cite: 3].

## Solution Architecture

The solution is structured into three decoupled projects:

* **`ElementaryCA.Core`** — Class Library containing the core domain logic (`ElementaryAutomaton.cs`)[cite: 24].
* **`ElementaryCA.Tests`** — MSTest unit test suite covering all 8 neighborhood transitions for Rule 90 and Rule 110, as well as multi-generation 1D array evolution[cite: 23, 24].
* **`ElementaryCA.ConsoleApp`** — Console runner that visualizes the evolution of any rule over time, starting from a single active cell in the center of the first generation[cite: 7].

## Supported Wolfram Classifications

By changing the `RULE` constant in `Program.cs`, the automaton demonstrates all 4 primary Wolfram complexity classes[cite: 5, 10]:

* **Class 1 (Uniformity):** `Rule 222` — evolves into a homogeneous state[cite: 5, 10].
* **Class 2 (Repetition):** `Rule 190` — evolves into periodic oscillating structures[cite: 5, 10].
* **Class 3 (Random / Chaotic):** `Rule 30` — produces aperiodic, seemingly random patterns[cite: 5, 10].
* **Class 4 (Complexity):** `Rule 110` — forms complex localized structures (proven Turing-complete)[cite: 5, 10, 16].
* **Fractal Geometry:** `Rule 90` (*Hat Rule* / XOR) — generates the **Sierpiński Triangle** (`1` if and only if exactly one neighbor is `1`)[cite: 7, 8, 9].

### Example Console Output (Rule 90 — Sierpiński Triangle)

```text
               #               
              # #              
             #   #             
            # # # #            
           #       #           
          # #     # #          
         #   #   #   #         
        # # # # # # # #        
```

## Getting Started

### Prerequisites
* .NET SDK (8.0 / 10.0)
* Visual Studio 2022+ (optional, for Test Explorer)

### Run Unit Tests
```bash
dotnet test
```

### Run the Console Visualization
```bash
dotnet run --project ElementaryCA.ConsoleApp
```