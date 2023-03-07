namespace ListsProject2
{
    public class LinkedList
    {
        private Node _root;

        private Node _tail;
        //ПОПРОБОВАТЬ РАЗВЕРНУТЬ ЗА ОДИН ПРОХОД (две новые переменные)
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = GetNodeByIndex(index); // ????

                return current.Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = GetNodeByIndex(index); // ????

                current.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values");
            }
            
            Length = values.Length;
            
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public int Length { get; private set; } // дописать исключения

        public void Add(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public override bool Equals(object? obj)
        {
            LinkedList list = (LinkedList)obj;

            if (Length != list.Length)
            {
                return false;
            }

            Node current = _root;
            Node currentList = list._root;

            do
            {
                if (current.Value != currentList.Value)
                {
                    return false;
                }

                current = current.Next;
                currentList = currentList.Next;

            } 
            while (current.Next is not null);


            return true;
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (current.Next is not null)
                {
                    current = current.Next;
                    s += current.Value;
                }

                return s;
            }
            else
            {
                return string.Empty;
            }
        }

        private Node GetNodeByIndex(int index)
        {
            //Node current = new Node(0);
            Node node = _root;

            for (int i = 1; i <= index; i++)
            {
                node = node.Next;
            }

            return node;
        }
    }
}
