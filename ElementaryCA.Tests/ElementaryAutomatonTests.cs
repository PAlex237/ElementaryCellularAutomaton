using ElementaryCA.Core;

namespace ElementaryCA.Tests
{
    [TestClass]
    public sealed class ElementaryAutomatonTests
    {
        [TestMethod]
        public void Rule90_ComputesCorrectly()
        {
            ElementaryAutomaton automaton = new ElementaryAutomaton();

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
            ElementaryAutomaton automaton = new ElementaryAutomaton();
            Assert.AreEqual(0, automaton.CalculateNextState(1, 1, 1));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 1, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(1, 0, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(1, 0, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 1, 1));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 1, 0));
            Assert.AreEqual(1, automaton.CalculateNextState(0, 0, 1));
            Assert.AreEqual(0, automaton.CalculateNextState(0, 0, 0));
        }
    }
}
