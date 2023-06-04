using System.Collections.Generic;

public static class ListUtils
{
    private static readonly System.Random RND = new System.Random();

    public static T Random<T>(this List<T> list)
    {
        return Random(list, RND);
    }
    public static T Random<T>(this List<T> list, System.Random rnd)
    {
        return list[rnd.Next(0, list.Count)];
    }
}