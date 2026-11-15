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
    }
}
