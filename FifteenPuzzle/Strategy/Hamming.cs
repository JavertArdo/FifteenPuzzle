using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public class Hamming : AStar, IStrategy
    {
        private SortedList<int, List<Node>> sorted = new SortedList<int, List<Node>>();

        public void Solve(State initialState, State finalState, string order)
        {
            bool found = false;

            // Make sure about order
            order = "LRUD";

            // Initial Node
            Node initialNode = new Node(0, null, initialState, '0', 0);
            // Push Initial Board to Visited States
            sorted.Add(0, new List<Node>() { initialNode });
            
            // Check if Initial Board is Final Board
            if (Enumerable.SequenceEqual(initialState.GetBoard(), finalState.GetBoard())) { found = true; }

            // Push initial Board to discovered list
            discovered.Add(initialNode.Puzzle.ToString(), new List<Node>() { initialNode });

            // Do until not found solution or visit available states
            while (!found && (sorted.Count > 0))
            {
                // Copy always the first element
                Node currentNode = sorted.Values[0][0];
                // Update recursion depth
                if (recursionDepth < currentNode.Depth) { recursionDepth = currentNode.Depth; }
                
                // Add one to visited
                visited++;

                // Check if current Puzzle is Final Board
                if (Enumerable.SequenceEqual(currentNode.Puzzle.GetBoard(), finalState.GetBoard()))
                {
                    // Find path to solution
                    FindPath(ref solution, currentNode);

                    return;
                }
                
                // Add one to processed
                processed++;
                // Remove from sorted list
                {
                    sorted.Values[0].RemoveAt(0);

                    if (sorted.Values[0].Count == 0) { sorted.RemoveAt(0); }
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
                        currentChild.Cost = H(currentChild.Puzzle, finalState, StrategyCode.Hamming) + currentChild.Depth;

                        // Make string from puzzle
                        string puzzle = currentChild.Puzzle.ToString();

                        // Push child node to the sorted list
                        if (!discovered.ContainsKey(puzzle))
                        {
                            // Push to sorted list
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
                            // Push to hashtable
                            discovered.Add(puzzle, new List<Node>() { currentChild });
                        }
                    }
                }
            }
        }
    }
}
