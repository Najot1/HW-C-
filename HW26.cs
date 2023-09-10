using System.Collections.Generic;


int[] ints = new[] { -5, -42, -3, -20, -1, 24, 3, 46, 5, 6 };

int[] positiveIntegers =
    (from posInt in ints
     where posInt > 0
     select posInt).ToArray();

int[] positiveIntegers2 =
    (from posInt in ints
     where posInt % 2 != 0
     select posInt).ToArray();

int[] negativeIntegers =
    (from posInt in ints
     where posInt < 0 
     where posInt % 2 == 0
     select posInt).ToArray();

int[] positiveIntegers3 =
    (from posInt in ints
     where posInt > 10
     select posInt).ToArray();

string[] strs = new[] { "Doom", "Greate", "Golf", "Reallyf" };

string[] firstStr =
    (from str in strs
    where str.StartsWith("G")
    where str.Length > 5
    select str).ToArray();

string[] lastStr =
    (from str in strs
    where str.EndsWith("f")
    where str.Length < 5
    select str).ToArray();

char[] firstStr2 = strs
    .Select(x => x[0])
    .ToArray();


int[] ints2 = new[] { 1, 2, 3, 4, 5, 6, 7 };

string[] result = ints2
    .Where(i => i % 2 != 0)
    .Select(i => i.ToString())
    .ToArray();





