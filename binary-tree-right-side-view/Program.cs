using System;
using System.Collections.Generic;

namespace binary_tree_right_side_view
{
    class Program
    {
        static void Main(string[] args)
        {
            // we want to see a list of nodes from the right side of the tree like what we can see in CAD
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(5);

            var result = RightView(root);

            foreach (var num in result)
                System.Console.Write(num + "\t");
            System.Console.WriteLine();
        }

        private static List<int> RightView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            Helper(root, result, 0);
            return result;
        }
        private static void Helper(TreeNode root, List<int> result, int level)
        {
            if (root == null)
                return;
            if (result.Count <= level)
                result.Add(root.val);
            else
                result[level] = root.val;
            Helper(root.left, result, level + 1);
            Helper(root.right, result, level + 1);
        }
    }
}
