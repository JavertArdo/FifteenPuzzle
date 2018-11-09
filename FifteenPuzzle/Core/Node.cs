namespace FifteenPuzzle.Core
{
    public class Node
    {
        public int Depth { get; protected set; }

        public Node Parent { get; protected set; }

        public State Puzzle { get; protected set; }

        public char Move { get; protected set; }

        public int Cost { get; set; }

        public Node(int Depth, Node Parent, State Puzzle, char Move, int Cost)
        {
            this.Depth = Depth;
            this.Parent = Parent;
            this.Puzzle = Puzzle;
            this.Move = Move;
            this.Cost = Cost;
        }
    }
}
