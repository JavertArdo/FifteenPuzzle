using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle.Strategy
{
    public class BFS : Strategy, IStrategy
    {
        private Queue<Node> queue = new Queue<Node>();

        public void Solve(State initialState, State finalState, string order)
        {
            bool found = false;

            // Push Initial Board to Queue
            {
                queue.Enqueue(new Node(0, null, initialState, '0', 0));
                visited++;
            }
            // Check if Initial State is Final State
            if (Enumerable.SequenceEqual(initialState.GetBoard(), finalState.GetBoard())) { found = true; }

            // Do until not found solution or visit available states
            while (!found && (queue.Count > 0))
            {
                // Copy always the first element
                Node currentNode = queue.Dequeue();
                // Update recursion depth
                if (recursionDepth < currentNode.Depth) { recursionDepth = currentNode.Depth; }
                // Push to explored list
                explored.Add(currentNode);

                // Check if current Puzzle is Final Board
                if (Enumerable.SequenceEqual(currentNode.Puzzle.GetBoard(), finalState.GetBoard()))
                {
                    // Find path to solution
                    FindPath(ref solution, currentNode);

                    return;
                }

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
                        // Not necessarily
                        // if (!Contains(queue, currentChild) && !Contains(explored, currentChild))
                        if (!Enumerable.SequenceEqual(currentChild.Puzzle.GetBoard(), currentChild.Parent.Puzzle.GetBoard()))
                        {
                            // Push to visited list
                            queue.Enqueue(currentChild);
                            visited++;
                        }
                    }
                }
            }
        }
    }
}
