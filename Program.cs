using System;
using System.Linq;

class Program
{
    static void Main()
    {   
        // All number copied from triangle in problem.
        int[] TriangleNums = {75, 95, 64, 17, 47, 82, 18, 35, 87, 10, 20,
                              04, 82, 47, 65, 19, 01, 23, 75, 03, 34, 88,
                              02, 77, 73, 07, 63, 67, 99, 65, 04, 28, 06,
                              16, 70, 92, 41, 41, 26, 56, 83, 40, 80, 70,
                              33, 41, 48, 72, 33, 47, 32, 37, 16, 94, 29,
                              53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,
                              70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17,
                              57, 91, 71, 52, 38, 17, 14, 91, 43, 58, 50,
                              27, 29, 48, 63, 66, 04, 68, 89, 53, 67, 30,
                              73, 16, 69, 87, 40, 31, 04, 62, 98, 27, 23,
                              09, 70, 98, 73, 93, 38, 53, 60, 04, 23};

        // Utilized jagged array to store the numbers in a "triangle" format.
        int[][] triangle = new int[15][];
        int index = 0;
        // Loop that goes through TriangleNums array and fills it into the jagged array (triangle).
        for (int row = 0; row < 15; row++)
        {
            triangle[row] = new int[row+1];
            // Loops through each row and fills it with one extra column each time
            // and takes necessary from TriangleNums
            for (int col = 0; col <= row; col++)
            {
                triangle[row][col] = TriangleNums[index];
                index++;
            }
        }
        // "int rows" looks at the amount of rows within triangle
        int rows = triangle.Length;
        // Had to do some research to find how to find max path sum (https://www.geeksforgeeks.org/dsa/maximum-path-sum-triangle/)
        // Found the best way would be to start from second to last row and add max of the two numbers below
        for (int i = rows - 2; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {
                // Math.Max is doing a majority of the heavy lifting here, through comparing the two numbers below and finding the max of the two.
                // It then adds to the sum to triangle[i][j].
                triangle[i][j] += Math.Max(triangle[i+1][j], triangle[i+1][j+1]);
            }
        }
        Console.WriteLine(triangle[0][0]);
    }
}
// I will admit, I did have a rather difficult time trying to find the best solution to this problem. I first started by looking at what the actual best path was
// through physical means. I had found that the best path totaled 1074. I thought the best way would be from going from the top down but then found out that the actual best
// way to go through the problem was from the bottom up through my research. 