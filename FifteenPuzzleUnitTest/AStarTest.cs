using FifteenPuzzle.Core;
using FifteenPuzzle.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class AStarTest : AStar
    {
        [TestMethod]
        public void Test_4x4_G()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9,  0, 10, 12,
                13, 14, 15, 11
            };
            State state = new State(4, 4, board);
            Node node = new Node(5, null, state, '0', 5);

            Assert.AreEqual(5, G(node));
        }

        [TestMethod]
        public void Test_4x4_H_Hamming()
        {
            int[] current =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9,  0, 10, 12,
                13, 14, 15, 11
            };
            int[] final =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11, 12,
                13, 14, 15,  0
            };

            State currentState = new State(4, 4, current);
            State finalState = new State(4, 4, final);

            Assert.AreEqual(2, H(currentState, finalState, StrategyCode.Hamming));
        }

        [TestMethod]
        public void Test_4x4_H_Manhattan()
        {
            int[] current =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9,  0, 10, 12,
                13, 14, 15, 11
            };
            int[] final =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11, 12,
                13, 14, 15,  0
            };

            State currentState = new State(4, 4, current);
            State finalState = new State(4, 4, final);

            Assert.AreEqual(3, H(currentState, finalState, StrategyCode.Manhattan));
        }
    }
}
