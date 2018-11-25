using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public abstract class Strategy
    {
        protected int recursionDepth = 0;

        protected int visited = 0;
        protected int processed = 0;

        protected Dictionary<string, List<Node>> discovered = new Dictionary<string, List<Node>>();

        protected List<Node> solution = new List<Node>();

        public string GetSolution()
        {
            string output = "";

            foreach (Node node in solution)
            {
                output += node.Move;
            }

            return output;
        }

        public int GetSolutionLength()
        {
            if (solution.Count == 0) { return -1; }

            return solution.Count;
        }

        public int GetRecursionDepth()
        {
            return recursionDepth;
        }

        public int GetVisitedStatesCount()
        {
            return visited;
        }

        public int GetProcessedStatesCount()
        {
            return processed;
        }

        // Checking if Node exists in list
        protected bool Contains(IEnumerable<Node> list, Node node)
        {
            foreach (Node n in list)
            {
                if (Enumerable.SequenceEqual(n.Puzzle.GetBoard(), node.Puzzle.GetBoard()))
                {
                    return true;
                }
            }

            return false;
        }

        // Finding path
        protected void FindPath(ref List<Node> list, Node node)
        {
            Node currentNode = node;

            list.Add(currentNode);

            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;

                if (currentNode.Move != '0')
                {
                    list.Add(currentNode);
                }
            }

            list.Reverse();
        }
    }
}
