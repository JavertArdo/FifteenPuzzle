namespace FifteenPuzzle.Utility
{
    public static class Extended
    {
        public static void SwapValues<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
