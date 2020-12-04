using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace StartLeetCode
{
    public class LeetCode1653
    {
        public int MinimumDeletion(string s)
        {
            var minDeletes = s.Length;
            var deletes = new int[s.Length];
            var aCounts = 0;
            var bCounts = 0;

            for (int i = 0; i < s.Length; i++)
            {
                deletes[i] = bCounts;
                if (s[i] == 'b')
                {
                    bCounts++;
                }
            }

            for (int i = s.Length-1; i >= 0; i--)
            {
                deletes[i] += aCounts;
                minDeletes = Math.Min(minDeletes, deletes[i]);
                if (s[i] == 'a')
                {
                    aCounts++;
                }
            }

            return minDeletes;
        }

        public int MinimunDeletion2(string s)
        {
            var leftB = new int[s.Length];
            var rightA = new int[s.Length];
            int a = 0, b = 0;
            for (int i = 0; i < s.Length; i++)
            {
                leftB[i] = b;
                if (s[i] == 'b')
                {
                    b++;
                }
            }

            for (int i = s.Length-1; i >=0; i--)
            {
                rightA[i] = a;
                if (s[i] == 'a')
                {
                    a++;
                }
            }

            var res = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                res = Math.Min(res, leftB[i]+rightA[i]);
            }

            return res;
        }

        [Test]
        public void Test001()
        {

        }
    }
}
