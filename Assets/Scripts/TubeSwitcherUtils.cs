using System;
using System.Collections.Generic;

public static class TubeSwitcherUtils
{
    public static List<int> GetOpenWays(this TubeSwitcher tubeSwitcher)
    {
        List<int> openWays = new List<int>();
        int switcherPosition = tubeSwitcher.Position;
        switch (switcherPosition)
        {
            case 0: openWays.AddRange(new[] {0, 1});
                break;
            case 1: openWays.AddRange(new[] {1});
                break;
            case 2: openWays.AddRange(new[] {0});
                break;
            default:
                throw new NotImplementedException();
        }

        return openWays;
    }
}