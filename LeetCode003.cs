using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StartLeetCode
{
    public class LeetCode003
    {
        public int LengthOfLongestSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int i = 0;
            int j = 1;
            int len = 1;
            while (i + len <= s.Length && j < s.Length)
            {
                int m = s.IndexOf(s[j], i, j - i);
                if (m >= 0)
                {
                    if (j-i >= len)
                    {
                        len = j - i;
                    }

                    i = m + 1;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            if (j - i > len) len = j - i;
            return len;
        }

        public int LengthOfLongestSubstringUseMap (string s)
        {
            var i = 0;
            var j = 1;
            var len = 1;
            var map = new Dictionary<char, int>();
            map[s[0]] = 0;

            while (i + len <= s.Length && j < s.Length)
            {
                var ch = s[j];
                if (map.TryGetValue(ch, out var m))
                {
                    if (j-i >len)
                    {
                        len = j - i;
                    }

                    for (int k = i; k <= m; k++)
                    {
                        map.Remove(s[k]);
                    }

                    i = m + 1;
                    map.Add(ch, j);
                    j++;
                }
                else
                {
                    map[ch] = j;
                    j++;
                }
            }

            if (j-i > len)
            {
                len = j - i;
            }

            return len;
        }

        [Test]
        public void Test01()
        {
            int Test(string s) => LengthOfLongestSubstrings(s);

            Assert.That(Test("abcabcbb"), Is.EqualTo(3));
            Assert.That(Test("abcd"), Is.EqualTo(4));
            Assert.That(Test("aaaa"), Is.EqualTo(1));
            Assert.That(Test("pwwkew"), Is.EqualTo(3));
        }

        [Test]
        public void TestPerformance()
        {
            var s = "abcdabcdabcdabcdabcdabcdabcdabcdabcd";
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000_000; i++)
            {
                LengthOfLongestSubstrings(s);
            }

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
