namespace kth_node_from_tail
{
    public class Node
    {
        public int data { get; set; }

        public Node Next { get; set; }

        public Node(int num)
        {
            this.data = num;
            this.Next = null;
        }
    }
}