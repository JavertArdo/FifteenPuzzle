using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public class DFS : Strategy, IStrategy
    {
        private readonly int maxRecursionDepth = 20;

        private Stack<Node> stack = new Stack<Node>();

        public void Solve(State initialBoard, State finalBoard, string order)
        {
            bool found = false;

            // Push Initial Board to Visited States
            {
                stack.Push(new Node(0, null, initialBoard, '0', 0));
                visited++;
            }
            // Check if Initial Board is Final Board
            if (Enumerable.SequenceEqual(initialBoard.GetBoard(), finalBoard.GetBoard())) { found = true; }

            // Do until not found solution or visit available states
            while (!found && (stack.Count > 0))
            {
                // Copy always the last element
                Node currentNode = stack.Pop();
                // Update recursion depth
                if (recursionDepth < currentNode.Depth) { recursionDepth = currentNode.Depth; }
                // Push to explored list
                explored.Add(currentNode);

                // Check if current Puzzle is Final Board
                if (Enumerable.SequenceEqual(currentNode.Puzzle.GetBoard(), finalBoard.GetBoard()))
                {
                    // Find path to solution
                    FindPath(ref solution, currentNode);

                    return;
                }

                // Check wheather not achieved max recursion depth on Current Node
                if (currentNode.Depth < maxRecursionDepth)
                {
                    // Using order in finding solution - LRUD
                    for (int i = 0; i < order.Length; i++)
                    {
                        // Check if move is possible
                        if (currentNode.Puzzle.CheckMove(order[i]))
                        {
                            // Create child node
                            Node currentChild = new Node(currentNode.Depth + 1, currentNode, new State(currentNode.Puzzle), order[i], currentNode.Cost + 1);

                            // Move Zero on newly copied board
                            currentChild.Puzzle.Move(order[i]);

                            // Check if Current Child ever existed on list
                            // Slow as hell
                            // if (!Contains(stack, currentChild) && !Contains(explored, currentChild))
                            if (!Enumerable.SequenceEqual(currentChild.Puzzle.GetBoard(), currentChild.Parent.Puzzle.GetBoard()))
                            {
                                // Push to visited list
                                stack.Push(currentChild);
                                visited++;
                            }
                        }
                    }
                }
            }
        }
    }
}
