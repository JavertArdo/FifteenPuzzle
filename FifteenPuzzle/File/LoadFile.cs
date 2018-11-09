using FifteenPuzzle.Core;
using System.Collections.Generic;
using System.IO;

namespace FifteenPuzzle.File
{
    public static class LoadFile
    {
        public static State Board(string filepath)
        {
            int width = 0;
            int height = 0;
            string line;
            bool first = false;

            List<int> board = new List<int>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!first)
                    {
                        string[] splitted = line.Split(' ');

                        width = int.Parse(splitted[1]);
                        height = int.Parse(splitted[0]);

                        first = true;
                    }
                    else
                    {
                        string[] splitted = line.Split(' ');

                        for (int i = 0; i < width; i++)
                        {
                            board.Add(int.Parse(splitted[i]));
                        }
                    }
                }
            }
            
            return new State(width, height, board.ToArray());
        }

        public static string[] BoardSize(string filepath)
        {
            filepath = filepath.Replace("../", "");
            filepath = filepath.Replace(".txt", "");

            string[] temp = filepath.Split('_');
            string[] size = temp[0].Split('x');

            return size;
        }
    }
}
