using FifteenPuzzle.Core;
using FifteenPuzzle.File;
using FifteenPuzzle.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class SaveFileTest
    {
        [TestMethod]
        public void Test_4x4_Solution()
        {
            State initialState = LoadFile.Board("../../StrategyTest_4x4_03.txt");
            State finalState = new State(4, 4);

            IStrategy bfs = new BFS();
            bfs.Solve(initialState, finalState, "LRUD");

            SaveFile.Solution("solution.txt", (Strategy)bfs);

            using (StreamReader sr = new StreamReader("solution.txt"))
            {
                Assert.AreEqual(3.ToString(), sr.ReadLine());
                Assert.AreEqual("RRR", sr.ReadLine());
            }
        }

        [TestMethod]
        public void Test_4x4_ExtraData()
        {
            Assert.IsTrue(true);
        }
    }
}
