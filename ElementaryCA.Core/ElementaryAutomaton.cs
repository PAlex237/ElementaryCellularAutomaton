namespace ElementaryCA.Core
{
    public class ElementaryAutomaton
    {
        int[] ruleTable = new int[8];

        public ElementaryAutomaton(int rule)
        {
            for (int i = 0; i < 8; i++)
            { ruleTable[i] = rule % 2;
            rule /= 2;
            }
        }
        public int CalculateNextState(int left, int current, int right)
        {
            int number = left * 4 + current * 2 + right;
            return ruleTable[number];

        }
        public int[] NextGeneration(int[] currentGeneration)
        {
            int[] nextGeneration= new int[currentGeneration.Length];
            int left, right,current;
            for (int i = 0; i < currentGeneration.Length; i++)
            {
                if (i == 0)
                    left = 0;
                else
                   left = currentGeneration[i - 1];
                current = currentGeneration[i];
                if (i == currentGeneration.Length - 1)
                    right = 0;
                else
                    right = currentGeneration[i + 1];

                nextGeneration[i] = CalculateNextState(left, current, right);
            }

            return nextGeneration;
        }

    }
}
