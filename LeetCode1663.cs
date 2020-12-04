using System;
using System.Collections.Generic;
using System.Text;

namespace StartLeetCode
{
    public class LeetCode1663
    {
        public string GetSmallestString(int n, int k)
        {
            var count = (k - n) / 25;
            var leftover = (k - n) % 25;
            var left = new string('a', n-count-1);
            var right = new string('z', count);
            var mid = (char)(leftover-1+'a');
            return left + mid + right;
        }
    }
}
