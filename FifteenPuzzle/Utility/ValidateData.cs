namespace FifteenPuzzle.Utility
{
    public static class ValidateData
    {
        public static bool CheckFSStrategy(string data)
        {
            switch (data)
            {
                case "bfs": return true;
                case "dfs": return true;
            }

            return false;
        }

        public static bool CheckAStarStrategy(string data)
        {
            switch (data)
            {
                case "astr": return true;
            }

            return false;
        }

        public static bool CheckFSOrder(string data)
        {
            switch (data)
            {
                case "RDUL": return true;
                case "RDLU": return true;
                case "DRUL": return true;
                case "DRLU": return true;
                case "LUDR": return true;
                case "LURD": return true;
                case "ULDR": return true;
                case "ULRD": return true;
            }

            return false;
        }

        public static bool CheckAStarOrder(string data)
        {
            switch (data)
            {
                case "hamm": return true;
                case "manh": return true;
            }

            return false;
        }
    }
}
