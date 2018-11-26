using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public class DFS : Strategy, IStrategy
    {
        private readonly int maxRecursionDepth = 20;

        private Stack<Node> stack = new Stack<Node>();

        public void Solve(State initialState, State finalState, string order)
        {
            bool found = false;

            // Initial Node
            Node initialNode = new Node(0, null, initialState, '0', 0);
            // Push Initial Board to Stack
            stack.Push(initialNode);

            // Add one to visited
            visited++;

            // Check if Initial State is Final State
            if (Enumerable.SequenceEqual(initialState.GetBoard(), finalState.GetBoard())) { found = true; }

            // Push initial Board to discovered list
            discovered.Add(initialNode.Puzzle.ToString(), new List<Node>() { initialNode });

            // Do until not found solution or visit available states
            while (!found && (stack.Count > 0))
            {
                // Copy always the last element
                Node currentNode = stack.Pop();

                // Check wheather not achieved max recursion depth on Current Node
                if (currentNode.Depth < maxRecursionDepth)
                {
                    // Add one to processed
                    processed++;

                    // Using order in finding solution - LRUD
                    for (int i = order.Length - 1; i >= 0; i--)
                    {
                        // Check if move is possible
                        if (currentNode.Puzzle.CheckMove(order[i]))
                        {
                            // Create child node
                            Node currentChild = new Node(currentNode.Depth + 1, currentNode, new State(currentNode.Puzzle), order[i], currentNode.Cost + 1);

                            // Move Zero on newly copied board
                            currentChild.Puzzle.Move(order[i]);

                            // Make string from puzzle
                            string puzzle = currentChild.Puzzle.ToString();

                            // Check if Current Child ever existed on list
                            if (!discovered.ContainsKey(puzzle))
                            {
                                // Update recursion depth
                                if (recursionDepth < currentChild.Depth) { recursionDepth = currentChild.Depth; }

                                // Add one to visited
                                visited++;

                                // Check if current Puzzle is Final Board
                                if (Enumerable.SequenceEqual(currentChild.Puzzle.GetBoard(), finalState.GetBoard()))
                                {
                                    // Find path to solution
                                    FindPath(ref solution, currentChild);

                                    return;
                                }

                                // Push to list
                                stack.Push(currentChild);
                                // Push to hashtable
                                discovered.Add(puzzle, new List<Node>() { currentChild });
                            }
                            else
                            {
                                // Check if hash is other than initial state
                                if (puzzle != initialState.ToString())
                                {
                                    // TODO: If achieved board by other move or has other depth
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
