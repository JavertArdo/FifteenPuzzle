using FifteenPuzzle.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class StateTest : State
    {
        public StateTest() : base(4, 4) { }

        [TestMethod]
        public void Test_4x4_State()
        {
            /*
             * INIT BOARD 4x4
             */
            Assert.AreEqual(4, width);
            Assert.AreEqual(4, height);

            int[] check1 =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11, 12,
                13, 14, 15,  0
            };

            Assert.IsTrue(Enumerable.SequenceEqual(check1, board));
            Assert.AreEqual(3, zero.y);
            Assert.AreEqual(3, zero.x);

            /*
             * MAKE CLONE BOARD
             */
            State clone1 = new State(this);
            clone1.MoveLeft();

            int[] check2 =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11, 12,
                13, 14,  0, 15
            };

            Assert.AreEqual(4, width);
            Assert.AreEqual(4, height);
            Assert.IsTrue(Enumerable.SequenceEqual(check1, board));
            Assert.IsTrue(Enumerable.SequenceEqual(check2, clone1.GetBoard()));
            Assert.AreEqual(3, zero.y);
            Assert.AreEqual(3, zero.x);
            Assert.AreEqual(2, clone1.GetZeroPosition().y);
            Assert.AreEqual(3, clone1.GetZeroPosition().x);

            /*
             * MAKE CLONE BOARD
             */
            State clone2 = new State(4, 4, board);
            clone2.MoveUp();

            int[] check3 =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11,  0,
                13, 14, 15, 12
            };

            Assert.AreEqual(4, width);
            Assert.AreEqual(4, height);
            Assert.IsTrue(Enumerable.SequenceEqual(check1, board));
            Assert.IsTrue(Enumerable.SequenceEqual(check3, clone2.GetBoard()));
            Assert.AreEqual(3, zero.y);
            Assert.AreEqual(3, zero.x);
            Assert.AreEqual(3, clone2.GetZeroPosition().y);
            Assert.AreEqual(2, clone2.GetZeroPosition().x);
        }

        [TestMethod]
        public void Test_4x4_MoveLeft()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10,  0, 12,
                13, 14, 15, 11
            };
            this.board = board;

            zero.x = 2;
            zero.y = 2;

            MoveLeft();

            int[] check =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9,  0, 10, 12,
                13, 14, 15, 11
            };

            Assert.IsTrue(Enumerable.SequenceEqual(check, this.board));
            Assert.AreEqual(2, zero.x);
            Assert.AreEqual(1, zero.y);
        }

        [TestMethod]
        public void Test_4x4_MoveRight()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10,  0, 12,
                13, 14, 15, 11
            };
            this.board = board;

            zero.x = 2;
            zero.y = 2;

            MoveRight();

            int[] check =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 12,  0,
                13, 14, 15, 11
            };

            Assert.IsTrue(Enumerable.SequenceEqual(check, this.board));
            Assert.AreEqual(2, zero.x);
            Assert.AreEqual(3, zero.y);
        }

        [TestMethod]
        public void Test_4x4_MoveUp()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10,  0, 12,
                13, 14, 15, 11
            };
            this.board = board;

            zero.x = 2;
            zero.y = 2;

            MoveUp();

            int[] check =
            {
                 1,  2,  3,  4,
                 5,  6,  0,  8,
                 9, 10,  7, 12,
                13, 14, 15, 11
            };

            Assert.IsTrue(Enumerable.SequenceEqual(check, this.board));
            Assert.AreEqual(1, zero.x);
            Assert.AreEqual(2, zero.y);
        }

        [TestMethod]
        public void Test_4x4_MoveDown()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10,  0, 12,
                13, 14, 15, 11
            };
            this.board = board;

            zero.x = 2;
            zero.y = 2;

            MoveDown();

            int[] check =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  0, 11
            };

            Assert.IsTrue(Enumerable.SequenceEqual(check, this.board));
            Assert.AreEqual(3, zero.x);
            Assert.AreEqual(2, zero.y);
        }

        [TestMethod]
        public void Test_4x4_FindZeroPosition()
        {
            int[] board =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  0, 11
            };
            this.board = board;

            FindZeroPosition();

            Assert.AreEqual(3, zero.x);
            Assert.AreEqual(2, zero.y);
        }

        [TestMethod]
        public void Test_4x4_FindPosition()
        {
            int[] board1 =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  0, 11
            };
            board = board1;

            Position position1 = FindPosition(9);

            Assert.AreEqual(2, position1.x);
            Assert.AreEqual(0, position1.y);

            int[] board2 =
            {
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  0, 11
            };
            board = board2;

            Position position2 = FindPosition(12);

            Assert.AreEqual(2, position2.x);
            Assert.AreEqual(3, position2.y);
        }

        [TestMethod]
        public void Test_4x4_MoveIllegal()
        {
            int[] board1 =
            {
                 0,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  1, 11
            };
            board = board1;
            FindZeroPosition();

            MoveLeft();

            Assert.IsTrue(Enumerable.SequenceEqual(board1, board));

            MoveUp();

            Assert.IsTrue(Enumerable.SequenceEqual(board1, board));

            int[] board2 =
            {
                11,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 15, 12,
                13, 14,  1,  0
            };
            board = board2;
            FindZeroPosition();

            MoveRight();

            Assert.IsTrue(Enumerable.SequenceEqual(board2, board));

            MoveDown();

            Assert.IsTrue(Enumerable.SequenceEqual(board2, board));
        }

        [TestMethod]
        public void Test_4x4_ToString()
        {
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0", ToString());
        }
    }
}
