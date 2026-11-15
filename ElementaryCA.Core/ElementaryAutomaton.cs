namespace ElementaryCA.Core
{
    public class ElementaryAutomaton
    {
        public ElementaryAutomaton()
        {
        }
        public int CalculateNextState(int left, int current, int right)
        {
            int number = left * 4 + current * 2 + right;
            switch (number)
            { case 0: return 0;
                case 1: return 1;
                case 2: return 0;
                case 3: return 1;
                case 4: return 1;
                case 5: return 0;
                case 6: return 1;
                case 7: return 0;
                default: return 0;
            }

        }   
    }
}
