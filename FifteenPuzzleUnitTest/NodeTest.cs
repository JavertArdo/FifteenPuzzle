using FifteenPuzzle.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzleUnitTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Test_ToString()
        {
            State state = new State(4, 4);
            Node node = new Node(0, null, state, '0', 0);

            Assert.AreEqual("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0", node.ToString());
        }
    }
}
