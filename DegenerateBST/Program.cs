using System;

namespace DegenerateBST
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int data)
        {
            this.val = data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static TreeNode DegenerateBST(TreeNode root)
        {
            var node = root;
            TreeNode parent = null, newRoot = null;
            while (node != null)
            {
                while (node.left != null)
                {
                    rotateNode(node);
                    if (parent != null)
                        parent.right = node;
                }
                if (newRoot == null)
                    newRoot = node;
                parent = node;
                node = node.right;
            }
            return newRoot;
        }
        private static TreeNode rotateNode(TreeNode node)
        {
            var left = node.left;
            node.left = left.right;
            left.right = node;
            node = left;
            return node;
        }
    }
}
