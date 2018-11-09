using FifteenPuzzle.Core;
using FifteenPuzzle.File;
using FifteenPuzzle.Utility;
using FifteenPuzzle.Strategy;
using System;
using System.Diagnostics;

namespace FifteenPuzzle
{
    class Program
    {
        private static Stopwatch timer = new Stopwatch();

        static void Main(string[] args)
        {
            // Check if args exist
            if (args.Length != 5) { return; }

            // Validate program arguments
            {
                bool fss = ValidateData.CheckFSStrategy(args[0]);
                bool fso = ValidateData.CheckFSOrder(args[1]);

                if (fss)
                {
                    if (!fso) { return; }
                }

                bool ass = ValidateData.CheckAStarStrategy(args[0]);
                bool aso = ValidateData.CheckAStarOrder(args[1]);

                if (ass)
                {
                    if (!aso) { return; }
                }
            }

            // Choose strategy
            IStrategy strategy = null;

            switch (args[0])
            {
                case "bfs": strategy = new BFS();
                    break;
                case "dfs": strategy = new DFS();
                    break;
                case "astr":
                    {
                        if (args[1] == "hamm") { strategy = new Hamming(); }
                        else if (args[1] == "manh") { strategy = new Manhattan(); }
                    }
                    break;
            }

            // Load initial board
            int width = int.Parse(LoadFile.BoardSize(args[2])[1]);
            int height = int.Parse(LoadFile.BoardSize(args[2])[0]);
            State initialBoard = LoadFile.Board(args[2]);
            State finalBoard = new State(width, height);

            // Start timer
            timer.Start();

            // Do process
            strategy.Solve(initialBoard, finalBoard, args[1]);

            // Stop timer
            timer.Stop();

            Console.WriteLine("Elapsed time: " + string.Format("{0:N3}", timer.Elapsed.TotalMilliseconds));

            // Save files
            SaveFile.Solution(args[3], (Strategy.Strategy)strategy);
            SaveFile.ExtraData(args[4], (Strategy.Strategy)strategy, timer.Elapsed.TotalMilliseconds);
        }
    }
}
