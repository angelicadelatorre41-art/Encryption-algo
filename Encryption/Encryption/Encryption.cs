using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
         s = s.Replace(" ", ""); 
    int length = s.Length;
    double sqrtLen = Math.Sqrt(length);
    int rows = (int)Math.Floor(sqrtLen);
    int cols = (int)Math.Ceiling(sqrtLen);

    if (rows * cols < length)
        rows++;

    char[,] grid = new char[rows, cols];
    int index = 0;

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (index < length)
                grid[r, c] = s[index++];
            else
                grid[r, c] = '\0'; 
        }
    }

    List<string> result = new List<string>();

    for (int c = 0; c < cols; c++)
    {
        StringBuilder sb = new StringBuilder();
        for (int r = 0; r < rows; r++)
        {
            if (grid[r, c] != '\0')
                sb.Append(grid[r, c]);
        }
        result.Add(sb.ToString());
    }

    return string.Join(" ", result);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
