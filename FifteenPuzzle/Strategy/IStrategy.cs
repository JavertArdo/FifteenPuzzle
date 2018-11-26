using FifteenPuzzle.Core;

namespace FifteenPuzzle.Strategy
{
    public interface IStrategy
    {
        void Solve(State initialState, State finalState, string order);
    }
}
