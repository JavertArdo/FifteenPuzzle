using System.IO;

namespace FifteenPuzzle.File
{
    public static class SaveFile
    {
        public static void Solution(string filepath, Strategy.Strategy strategy)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine(strategy.GetSolutionLength());

                if (strategy.GetSolutionLength() != -1)
                {
                    sw.WriteLine(strategy.GetSolution());
                }
            }
        }

        public static void ExtraData(string filepath, Strategy.Strategy strategy, double duration)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine(strategy.GetSolutionLength());
                sw.WriteLine(strategy.GetVisitedStatesCount());
                sw.WriteLine(strategy.GetProcessedStatesCount());
                sw.WriteLine(strategy.GetRecursionDepth());
                sw.WriteLine(string.Format("{0:N3}", duration));
            }
        }
    }
}
