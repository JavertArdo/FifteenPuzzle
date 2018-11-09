using FifteenPuzzle.Core;
using System;

namespace FifteenPuzzle.Strategy
{
    public enum StrategyCode
    {
        Hamming,
        Manhattan
    }

    public abstract class AStar : Strategy
    {
        protected int G(Node node)
        {
            return node.Cost;
        }

        protected int H(State currentBoard, State finalBoard, StrategyCode code)
        {
            int sum = 0;

            int width = State.GetWidth();
            int height = State.GetHeight();

            int[] cb = currentBoard.GetBoard();
            int[] fb = finalBoard.GetBoard();

            for (int i = 0; i < width * height; i++)
            {
                if ((cb[i] != fb[i]) && (cb[i] != 0))
                {
                    if (code == StrategyCode.Hamming)
                    {
                        sum++;
                    }
                    else if (code == StrategyCode.Manhattan)
                    {
                        Position cbPosition = currentBoard.FindPosition(cb[i]);
                        Position fbPosition = finalBoard.FindPosition(cb[i]);

                        int cRow = cbPosition.x;
                        int cCol = cbPosition.y;
                        int fRow = fbPosition.x;
                        int fCol = fbPosition.y;

                        sum += (Math.Abs(cRow - fRow)) + (Math.Abs(cCol - fCol));
                    }
                }
            }

            return sum;
        }
    }
}
