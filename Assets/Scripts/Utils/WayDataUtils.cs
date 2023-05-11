namespace Utils
{
    public static class WayDataUtils
    {
        public static void Simplify(this WayData wayData)
        {
            Line[] lines = wayData.Lines;
            int currentLineIndex = wayData.LineIndex;
            Line currentLine = lines[currentLineIndex];
            float localLength = wayData.LocalLength;
            float currentLineLength = currentLine.Length;
            if (localLength < 0)
            {
                while (localLength < 0)
                {
                    currentLineIndex--;
                    if (currentLineIndex == -1) currentLineIndex = lines.Length - 1;
                    currentLineLength = lines[currentLineIndex].Length;
                    localLength += currentLineLength;
                }
            }
            else
            {
                while (localLength > currentLineLength - .001f)
                {
                    currentLineIndex++;
                    if (currentLineIndex == lines.Length) currentLineIndex = 0;
                    localLength -= currentLineLength;
                    currentLineLength = lines[currentLineIndex].Length;
                }
            }


            wayData.LocalLength = localLength;
            wayData.LineIndex = currentLineIndex;
        }
    }
}