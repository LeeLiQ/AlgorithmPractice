using System;
using System.Collections.Generic;

namespace binary_tree_level_list
{
    public class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.left.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            var result = LevelOrder(root);

            if (root != null)
                foreach (var level in result)
                {
                    foreach (var val in level)
                        System.Console.Write(val + "\t");
                    System.Console.WriteLine();
                    System.Console.WriteLine("===========");
                }

            var zigResult = ZigzagLevelOrder(root);
            if (root != null)
                foreach (var level in zigResult)
                {
                    foreach (var val in level)
                        System.Console.Write(val + "\t");
                    System.Console.WriteLine();
                    System.Console.WriteLine("===========");
                }
        }

        private static List<List<int>> LevelOrder(TreeNode root)
        {
            var result = new List<List<int>>();
            if (root == null)
                return result;

            var qu = new Queue<TreeNode>();
            qu.Enqueue(root);
            while (qu.Count != 0)
            {
                var levelResult = new List<int>();
                var levelSize = qu.Count;
                for (var i = 0; i < levelSize; i++)
                {
                    var node = qu.Dequeue();
                    if (node.left != null)
                        qu.Enqueue(node.left);
                    if (node.right != null)
                        qu.Enqueue(node.right);
                    levelResult.Add(node.val);
                }
                result.Add(levelResult);
            }
            return result;
        }

        private static List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<List<int>>();
            if (root == null)
                return result;

            var stacks = new Stack<TreeNode>[2]
            {
                new Stack<TreeNode>(),
                new Stack<TreeNode>()
            };

            int current = 0, next = 1;

            var levelResult = new List<int>();

            stacks[0].Push(root);

            while (stacks[0].Count != 0 || stacks[1].Count != 0)
            {
                var node = stacks[current].Pop();
                levelResult.Add(node.val);
                if (current == 0)
                {
                    if (node.left != null)
                        PushIfNotNull(stacks[next], node.left);
                    if (node.right != null)
                        PushIfNotNull(stacks[next], node.right);
                }
                else
                {
                    if (node.right != null)
                        PushIfNotNull(stacks[next], node.right);
                    if (node.left != null)
                        PushIfNotNull(stacks[next], node.left);
                }
                if (stacks[current].Count == 0)
                {
                    next = current;
                    current = 1 - current;
                    result.Add(levelResult);
                    levelResult = new List<int>();
                }
            }

            return result;
        }

        private static void PushIfNotNull(Stack<TreeNode> st, TreeNode node)
        {
            if (node != null)
                st.Push(node);
        }
    }
}
