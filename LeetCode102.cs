using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StartLeetCode.Helpers;

namespace StartLeetCode
{
    public class LeetCode102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            IList<TreeNode> prev = new[] {root};
            var results = new List<IList<TreeNode>>(){};

            while (prev.Count > 0)
            {
                results.Add(prev);
                prev = new List<TreeNode>();

                foreach (var node in results.Last())
                {
                    if (node.left != null) prev.Add(node.left);
                    if (node.right != null) prev.Add(node.right);
                }
            }

            return results.Select(t => t.Select(n => n.val).ToArray() as IList<int>).ToArray();
        }

        public IList<IList<int>> LevelOrder1(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int countCurrentLevel = 1;
            int countNextLevel = 0;
            int countVisited_LevelWise = 0;

            IList<int> tmpListLevel = new List<int>();

            while (queue.Count !=0)
            {
                TreeNode node = queue.Peek();
                queue.Dequeue();

                if (node.left !=null)
                {
                    queue.Enqueue(node.left);
                    countNextLevel++;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    countNextLevel++;
                }

                countVisited_LevelWise++;
                tmpListLevel.Add(node.val);

                bool prepareForNextLevel = countVisited_LevelWise == countCurrentLevel;

                if (prepareForNextLevel)
                {
                    countCurrentLevel = countNextLevel;
                    countNextLevel = 0;
                    countVisited_LevelWise = 0;

                    List<int> l = new List<int>();
                    l.AddRange(tmpListLevel);
                    result.Add(l);
                    tmpListLevel.Clear();
                }
            }

            return result;
        }

        [Test]
        public void Test()
        {
            //string Test(string s) => LevelOrder(s.ToTree()).ToJson2();
            //Assert.That(Test("[3,9,20,null,null,15,7]"), Is.EqualTo(
//                @"[
//    [3],
//    [9, 20],
//    [15, 7]
//]"));
        }
    }
}
