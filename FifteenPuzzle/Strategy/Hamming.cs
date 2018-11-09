using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public class Hamming : AStar, IStrategy
    {
        private SortedList<int, List<Node>> sorted = new SortedList<int, List<Node>>();

        public void Solve(State initialBoard, State finalBoard, string order)
        {
            bool found = false;

            // Make sure about order
            order = "LRUD";

            // Push Initial Board to Visited States
            {
                sorted.Add(0, new List<Node>() { new Node(0, null, initialBoard, '0', 0) });
                visited++;
            }
            // Check if Initial Board is Final Board
            if (Enumerable.SequenceEqual(initialBoard.GetBoard(), finalBoard.GetBoard())) { found = true; }

            // Do until not found solution or visit available states
            while (!found && (sorted.Count > 0))
            {
                // Copy always the first element
                Node currentNode = sorted.Values[0][0];
                // Update recursion depth
                if (recursionDepth < currentNode.Depth) { recursionDepth = currentNode.Depth; }
                // Push to explored list
                explored.Add(currentNode);
                // Remove from sorted list
                {
                    sorted.Values[0].RemoveAt(0);

                    if (sorted.Values[0].Count == 0) { sorted.RemoveAt(0); }
                }

                // Check if current Puzzle is Final Board
                if (Enumerable.SequenceEqual(currentNode.Puzzle.GetBoard(), finalBoard.GetBoard()))
                {
                    // Find path to solution
                    FindPath(ref solution, currentNode);

                    return;
                }

                // Using heuristic in finding solution - hamm
                for (int i = 0; i < order.Length; i++)
                {
                    // Check if move is possible
                    if (currentNode.Puzzle.CheckMove(order[i]))
                    {
                        // Push new puzzle to list
                        Node currentChild = new Node(currentNode.Depth + 1, currentNode, new State(currentNode.Puzzle), order[i], 0);

                        // Move Zero on newly copied board
                        currentChild.Puzzle.Move(order[i]);

                        // Count the cost
                        currentChild.Cost = H(currentChild.Puzzle, finalBoard, StrategyCode.Hamming) + currentChild.Depth;

                        // Check if Current Child ever existed
                        bool exists = false;
                        // On sorted list
                        foreach (KeyValuePair<int, List<Node>> nodes in sorted)
                        {
                            foreach (Node node in nodes.Value)
                            {
                                if (Enumerable.SequenceEqual(node.Puzzle.GetBoard(), currentChild.Puzzle.GetBoard()))
                                {
                                    exists = true;
                                }
                            }
                        }
                        // On explored list
                        if (Contains(explored, currentChild)) { exists = true; }

                        // Push child node to the sorted list
                        if (!exists)
                        {
                            if (sorted.ContainsKey(currentChild.Cost))
                            {
                                int index = sorted.IndexOfKey(currentChild.Cost);
                                sorted.Values[index].Add(currentChild);
                            }
                            else
                            {
                                int key = currentChild.Cost;
                                sorted.Add(key, new List<Node>() { currentChild });
                            }
                        }
                    }
                }
            }
        }
    }
}
