using System;
using System.Collections.Generic;
using System.Text;

namespace StartLeetCode
{
    public class LeetCode934
    {
        private readonly (int, int)[] _directions = {(0, 1), (0, -1), (1, 0), (-1, 0)};

        private class Unions 
        {
            private readonly int[] _parents;
            private readonly int[] _ranks;

            public Unions(int n)
            {
                _parents = new int[n];
                _ranks = new int[n];
                for (int i = 0; i < n; i++)
                {
                    _parents[i] = i;
                }
            }
        }

        //public int Find(int x)
        //{
        //    if (x != _parents[x])
        //    {
        //        x = Find(_parents[x]);
        //    }

        //    return _parents[x];
        //}
        //public int ShortestBridge(int[][] A)
        //{

        //} 
    }
}
