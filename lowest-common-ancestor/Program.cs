using System;
using System.Collections.Generic;

namespace lowest_common_ancestor
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);
            System.Console.WriteLine(LowestCommonAncestor(root, root.left, root.right).val);
        }

        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            var pathList = new List<List<TreeNode>>();
            var path = new List<TreeNode>();
            Helper(root, p, q, pathList, path);
            var i = 0;
            while (i < Math.Min(pathList[0].Count, pathList[1].Count) && pathList[0][i] == pathList[1][i])
                i++;

            return pathList[0][i - 1];
        }

        private static void Helper(TreeNode root, TreeNode p, TreeNode q, List<List<TreeNode>> pathList, List<TreeNode> path)
        {
            path.Add(root);

            if (root == p || root == q)
            {
                pathList.Add(new List<TreeNode>(path));
            }
            if (root.left != null)
                Helper(root.left, p, q, pathList, path);
            if (root.right != null)
                Helper(root.right, p, q, pathList, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}
