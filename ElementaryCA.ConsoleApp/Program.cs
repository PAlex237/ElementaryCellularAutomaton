using ElementaryCA.Core;
using System.Data;

const int RULE= 90;
const int WIDTH = 81;
const int GENERATIONS = 40;

ElementaryAutomaton automaton = new ElementaryAutomaton(RULE);
int[] currentGeneration = new int[WIDTH];
currentGeneration[WIDTH / 2] = 1;

for (int generation = 0; generation < GENERATIONS; generation++)
{
 for(int i=0; i<WIDTH; i++)
    {
        if(currentGeneration[i] == 1)
            Console.Write("*");
        else
            Console.Write(" ");
    }
    Console.WriteLine();
    currentGeneration = automaton.NextGeneration(currentGeneration);
}