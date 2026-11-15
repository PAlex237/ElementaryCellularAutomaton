using ElementaryCA.Core;

namespace ElementaryCA.Tests
{
    [TestClass]
    public sealed class ElementaryAutomatonTests
    {
        [TestMethod]
        public void Rule90_ComputesCorrectly()
        {
            ElementaryAutomaton automaton = new ElementaryAutomaton(90);

            Assert.AreEqual(0, automaton.CalculateNextState(1,1,1));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 1, 0));
            Assert.AreEqual(0, automaton.CalculateNextState(1, 0, 1));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 0, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 1, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(0, 1, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 0, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(0, 0, 0));

        }
        [TestMethod]
        public void Rule110_ComputesCorrectly()
        {
            ElementaryAutomaton automaton = new ElementaryAutomaton(110);
            Assert.AreEqual(0, automaton.CalculateNextState(1, 1, 1));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 1, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 0, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(1, 0, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 1, 1));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 1, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 0, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(0, 0, 0));
        }
        [TestMethod]
        public void NextGeneration_Rule90_ComputesCorrectly()
        { 
            ElementaryAutomaton automaton = new ElementaryAutomaton(90);
            int[] gen0 = new int[] { 0, 0, 1, 0, 0 };
            int[] gen1 = automaton.NextGeneration(gen0);
            CollectionAssert.AreEqual(new int[] { 0, 1, 0, 1, 0 }, gen1);
            int[] gen2 = automaton.NextGeneration(gen1);
            CollectionAssert.AreEqual(new int[] { 1, 0, 0, 0, 1 }, gen2);
        }
    }
}
