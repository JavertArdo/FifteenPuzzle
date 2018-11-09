using FifteenPuzzle.Core;
using FifteenPuzzle.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class LoadFileTest
    {
        [TestMethod]
        public void Test_4x4_Board()
        {
            State board = LoadFile.Board("../../LoadFileTest_Board.txt");

            int[] check =
            {
                 2,  3,  4,  5,
                 6,  7,  8,  9,
                10, 11, 12, 13,
                14, 15,  0,  1
            };

            Assert.AreEqual(4, State.GetWidth());
            Assert.AreEqual(4, State.GetHeight());
            Assert.IsTrue(Enumerable.SequenceEqual(check, board.GetBoard()));
        }

        [TestMethod]
        public void Test_4x4_BoardSize()
        {
            string[] size = LoadFile.BoardSize("../../4x4_30_00001.txt");

            Assert.AreEqual("4", size[0]);
            Assert.AreEqual("4", size[1]);
        }
    }
}
