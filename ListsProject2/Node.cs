namespace ListsProject2
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public int Value { get; set; }

        public Node Next { get; set; }

    }
}
