using FifteenPuzzle.Core;

namespace FifteenPuzzle.Strategy
{
    public interface IStrategy
    {
        void Solve(State initialBoard, State finalBoard, string order);
    }
}
