using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StartLeetCode
{
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            char[] charS = s.ToCharArray();
            char[] charT = t.ToCharArray();

            return String.Concat(charT.OrderBy(c => c))
                == String.Concat(charS.OrderBy(c => c));
        }

        [Test]
        public void Test01()
        {
            bool Test(string s, string t) => IsAnagram(s,t);

            Assert.That(Test("cab", "abc"), Is.EqualTo(true));
          
        }
    }
}
