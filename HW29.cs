using System.Collections.Generic;


class Prog
{
    void LinqTasks()
    {
        // 1
        int[] ints1 = new[] { -5, -42, -3, -20, -1, 24, 3, 46, 5, 6 };

        int[] result1 = ints1
            .Where(e => e > 9 && e < 100)
            .OrderBy(e => e)
            .ToArray();
        
        // 2
        string[] strs = new[] { "DDDD", "GGG", "OO", "RRRRRR", "PP" };
        
        string[] result2 = strs
            .OrderBy(x => x.Length)
            .ThenBy(x => x)
            .ToArray();
        
        // 3
        string[] strs2 = new[] { "Daba", "Gda", "Od", "Radwd", "Pa" };
        int K = 4;
        string[] result3 = strs2
            .Take(K)
            .Where(x => x.Length % 2 > 0 && char.IsUpper(x[0]))
            .Reverse()
            .ToArray();

        // 4
        int[] ints2 = new [] { -14, -11, 124, 14, 3, -3, 77, 177, 5, 17, -121, 10};

        int[] result4 = ints2
            .Where(x => x > 0)
            .Select(x => x % 10)
            .Distinct()
            .ToArray();

        // 5
        string[] strs3 = new[] { "Daba", "Gda", "Od", "Radwd", "Pa" };

        char[] result5 = strs3
        .Select(x => x.Length % 2 != 0 ? x[x.Length - 1] : x[0])
        .OrderByDescending(x => x)
        .ToArray();

        // 6

        int[] A = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] B = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int K1 = 5;
        int K2 = 3;

        int[] result6 = A
            .Where(x => x > K1)
            .Concat(B.Where(x => x < K2))
            .OrderBy(x => x)
            .ToArray();
    }
}