using FifteenPuzzle.Utility;

namespace FifteenPuzzle.Core
{
    // Simple struct with coordinates
    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class State
    {
        // The same for the whole class instances
        protected static int width = 0;
        protected static int height = 0;

        // Keep the board in one dimension
        protected int[] board;

        // Easy access to Zero position
        protected Position zero;

        // Creates solved board
        public State(int width, int height)
        {
            State.width = width;
            State.height = height;

            board = new int[width * height];

            for (int i = 0; i < width * height - 1; i++)
            {
                board[i] = i + 1;
            }

            zero = new Position(width - 1, height - 1);
            board[zero.x * width + zero.y] = 0;
        }

        // Loads initial board
        public State(int width, int height, int[] board)
        {
            State.width = width;
            State.height = height;

            this.board = (int[])board.Clone();

            zero = new Position(0, 0);
            FindZeroPosition();
        }

        // Make clone board
        public State(State board)
        {
            this.board = (int[])board.board.Clone();
            zero = new Position(0, 0);
            FindZeroPosition();
        }

        public void MoveLeft()
        {
            // Check move
            if (!CheckMove('L')) { return; }

            // Calculate indexes
            int index1 = zero.x * width + zero.y;
            int index2 = index1 - 1;

            // Swap Zero with near value
            board.SwapValues(index1, index2);

            // Move on Y axis
            zero.x += 0;
            zero.y += -1;
        }

        public void MoveRight()
        {
            // Check move
            if (!CheckMove('R')) { return; }

            // Calculate indexes
            int index1 = zero.x * width + zero.y;
            int index2 = index1 + 1;

            // Swap Zero with near value
            board.SwapValues(index1, index2);

            // Move on Y axis
            zero.x += 0;
            zero.y += 1;
        }

        public void MoveUp()
        {
            // Check move
            if (!CheckMove('U')) { return; }

            // Calculate indexes
            int index1 = zero.x * width + zero.y;
            int index2 = index1 - width;

            // Swap Zero with near value
            board.SwapValues(index1, index2);

            // Move on X axis
            zero.x += -1;
            zero.y += 0;
        }

        public void MoveDown()
        {
            // Check move
            if (!CheckMove('D')) { return; }

            // Calculate indexes
            int index1 = zero.x * width + zero.y;
            int index2 = index1 + width;

            // Swap Zero with near value
            board.SwapValues(index1, index2);

            // Move on X axis
            zero.x += 1;
            zero.y += 0;
        }

        // Move zero on board
        public void Move(char move)
        {
            switch (move)
            {
                case 'L':
                    MoveLeft();
                    break;
                case 'R':
                    MoveRight();
                    break;
                case 'U':
                    MoveUp();
                    break;
                case 'D':
                    MoveDown();
                    break;
            }
        }

        // Checking the opposite move
        public static char OppositeMove(char move)
        {
            char output = '0';

            switch (move)
            {
                case 'L': return 'R';
                case 'R': return 'L';
                case 'U': return 'D';
                case 'D': return 'U';
            }

            return output;
        }

        // Useful in case of loading initial board
        public void FindZeroPosition()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (board[i * width + j] == 0)
                    {
                        zero.x = i;
                        zero.y = j;
                        return;
                    }
                }
            }
        }

        // Useful in heuristics
        public Position FindPosition(int value)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (board[i * width + j] == value)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            return new Position(x, y);
        }

        // Checking move by passing L, R, U or D argument
        public bool CheckMove(char move)
        {
            int x = 0;
            int y = 0;

            switch (move)
            {
                case 'L': { x = 0; y = -1; } break;
                case 'R': { x = 0; y = 1; } break;
                case 'U': { x = -1; y = 0; } break;
                case 'D': { x = 1; y = 0; } break;
                default: return false;
            }

            if ((zero.x + x) >= height || (zero.x + x) < 0)
            {
                return false;
            }

            if ((zero.y + y) >= width || (zero.y + y) < 0)
            {
                return false;
            }

            return true;
        }

        public static int GetWidth() { return width; }

        public static int GetHeight() { return height; }

        public int[] GetBoard() { return board; }

        public Position GetZeroPosition() { return zero; }
    }
}
