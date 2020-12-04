using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace StartLeetCode
{
    public class Dfs
    {



        private static int n, m, p, q, min = 999999;
        static int[][] a = new int[6][]; //battier
        static int[][] book = new int[6][]; //passed paths
        static List<string> ways = new List<string>();
        static void dfs(int x, int y, int step)
        {
            int[][] next = new int[][]
            {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {0, -1},
                new int[] {-1,0},
            };

            int tx, ty;

            if (x==p && y == q)
            {
                if (step < min)
                {
                    min = step;
                }

                foreach (var item in ways)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("reach the end, steps {0}", step);
                return;
            }

            for (int i = 0; i < next.Length; i++)
            {
                tx = x + next[i][0];
                ty = y + next[i][1];

                if (tx < 1 || tx > n || ty < 1 || ty > m)
                {
                    continue;
                }

                if (a[tx][ty] == 0 && book[tx][ty] == 0)
                {
                    book[tx][ty] = 1;
                    ways.Add(string.Format("{0}, {1}", tx, ty));
                    var index = ways.Count - 1;
                    dfs(tx, ty, step+1);
                    book[tx][ty] = 0;
                    ways.RemoveAt(index);
                }
            }
            return;
        }

        

        

    }
}
