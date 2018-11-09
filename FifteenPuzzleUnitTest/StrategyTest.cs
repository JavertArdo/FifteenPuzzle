using FifteenPuzzle.Core;
using FifteenPuzzle.File;
using FifteenPuzzle.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void Test_4x4_BFS()
        {
            State initialState = LoadFile.Board("../../StrategyTest_4x4_03.txt");
            State finalState = new State(4, 4);

            IStrategy bfs = new BFS();
            bfs.Solve(initialState, finalState, "LURD");

            Assert.AreEqual("RRR", ((Strategy)bfs).GetSolution());
            Assert.AreEqual(3, ((Strategy)bfs).GetRecursionDepth());
        }

        [TestMethod]
        public void Test_4x4_DFS()
        {
            Assert.Inconclusive("Not working");

            State initialState = LoadFile.Board("../../StrategyTest_4x4_03.txt");
            State finalState = new State(4, 4);

            IStrategy dfs = new DFS();
            dfs.Solve(initialState, finalState, "RDUL");

            Assert.AreEqual("RRR", ((Strategy)dfs).GetSolution());
        }

        [TestMethod]
        public void Test_4x4_AStar_Hamming()
        {
            State initialState = LoadFile.Board("../../StrategyTest_4x4_03.txt");
            State finalState = new State(4, 4);

            IStrategy hamming = new Hamming();
            hamming.Solve(initialState, finalState, "hamm");

            Assert.AreEqual("RRR", ((Strategy)hamming).GetSolution());
        }

        [TestMethod]
        public void Test_4x4_AStar_Manhattan()
        {
            State initialState = LoadFile.Board("../../StrategyTest_4x4_03.txt");
            State finalState = new State(4, 4);

            IStrategy manhattan = new Manhattan();
            manhattan.Solve(initialState, finalState, "manh");

            Assert.AreEqual("RRR", ((Strategy)manhattan).GetSolution());
        }
    }
}
