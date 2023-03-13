using System;

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

        // 23. Создать три конструктора
        // пустой конструктор
        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        // конструктор на основе одного элемента
        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        // конструктор на основе имеющегося массива
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

        // пользовательская длина списка - В ЧЕМ СМЫСЛ добавления условий?
        public int Length { get; private set; } // дописать исключения

        // МЕТОДЫ
        // 1. Добавление значения в конец
        public void Add(int value)
        {
            if (Length != 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root;
            }
        }

        // 24. Добавление массива в конец
        public void Add(int[] values)
        {
            ThrowNullReferenceExceptionIfValuesArrayIsNull(values);

            if (values.Length != 0)
            {
                if (Length != 0)
                {
                    _tail.Next = new Node(values[0]);
                    _tail = _tail.Next;
                    AddValuesArrayFromFirstElement(values);
                }
                else
                {
                    _root = new Node(values[0]);
                    _tail = _root;
                    AddValuesArrayFromFirstElement(values);
                }
            }

            Length += values.Length;
        }

        // 2-3. Добавление значения по индексу (в начале - по индексу 0)
        public void InsertAt(int index, int value)
        {
            if (Length != 0)
            {
                ThrowIndexOutOfRangeExceptionIfIndexOutOfLength(index);
                Node newNode = new Node(value);
                Length++;

                if (index > 0)
                {
                    Node previous = GetNodeByIndex(index - 1);
                    newNode.Next = previous.Next;
                    previous.Next = newNode;
                }
                else
                {
                    newNode.Next = _root;
                    _root = newNode;
                }                             
            }
            else
            {
                Length = 1;
                ThrowIndexOutOfRangeExceptionIfIndexOutOfLength(index);
                _root = new Node(value);
                _tail = _root;
            }
        }

        // 25-26. Добавление массива по индексу (в начало - по индексу 0)
        public void InsertAt(int index, int[] values)
        {
            if (Length != 0)
            {
                ThrowIndexOutOfRangeExceptionIfIndexOutOfLength(index);
                ThrowNullReferenceExceptionIfValuesArrayIsNull(values);
                InsertValuesArrayToNotEmptyListAtIndex(index, values);
            }
            else
            {
                if (index != 0)
                {
                    throw new IndexOutOfRangeException("index");
                }

                ThrowNullReferenceExceptionIfValuesArrayIsNull(values);
                Add(values);             
            }
        }

        // 4. Удаление из конца одного элемента
        public bool Remove()
        {
            if (Length == 0)
            {
                return false;
            }

            if (Length > 1)
            {
                _tail = GetNodeByIndex(Length - 2);
                _tail.Next = null;
            }
            else
            {                
                _root = null;
                _tail = null;
            }

            Length--;

            return true;
        }

        // 7. Удаление из конца N элементов
        public bool Remove(int number)
        {
            if (number < 0 || number > Length)
            {
                return false;
            }

            if (Length == 0)
            {
                return false;
            }

            if (number == Length - 1)
            {
                _tail = _root;
            }
            else if (number != Length)
            {
                _tail = GetNodeByIndex(Length - number - 1);
                _tail.Next = null;
            }
            else
            {
                _root = null;
                _tail = null;
            }

            Length -= number;

            return true;
        }

        // 5-6. Удаление одного элемента по индексу (в начале - по индексу 0)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            if (index > 0 && index != Length - 1)
            {
                Node previous = GetNodeByIndex(index - 1);
                previous.Next = GetNodeByIndex(index + 1);
                Length--;
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else
            {
                _root = GetNodeByIndex(index + 1);
                Length--;
            }

            return true;
        }

        // 8-9. Удаление N элементов по индексу (в начале - по индексу 0)
        public bool RemoveAt(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            if (number > Length - index)
            {
                return false;
            }

            if (index + number < Length)
            {
                if (index > 0)
                {
                    Node prevoius = GetNodeByIndex(index - 1);
                    prevoius.Next = GetNodeByIndex(index + number);
                }
                else
                {
                    _root = GetNodeByIndex(index + number);
                }
            }
            else
            {
                if (index > 0)
                {
                    _tail = GetNodeByIndex(index - 1);
                    _tail.Next = null;
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }
            Length -= number;

            return true;
        }

        // 12. Первый индекс по значению
        public int GetIndexByValue(int value)
        {
            int index = -1;
            Node node = _root;

            for (int i = 0; i < Length; i++)
            {
                if (node.Value == value)
                {
                    index = i;
                    break;
                }

                node = node.Next;
            }

            return index;
        }

        // 14. Реверс
        public void Reverse_РАЗОБРАТЬ()
        {
            Node previous = null;
            Node current = _root;
            Node next;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _root = previous;
            _tail = current;
        }

        public void Reverse()
        {
            if (Length != 0)
            {
                _tail = _root;
                Node tmp = _tail.Next;

                while (_tail.Next != null)
                {
                    _tail.Next = tmp.Next;
                    tmp.Next = _root;
                    _root = tmp;
                    tmp = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        // 15. Поиск значения максимального элемента
        public int FindMaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int maxValue = node.Value;

            while (node.Next != null) 
            {
                node = node.Next;

                if (node.Value > maxValue)
                {
                    maxValue = node.Value;
                }
            }
            
            return maxValue;
        }

        // 16. Поиск значения минимального элемента
        public int FindMinValue()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int minValue = node.Value;

            while (node.Next != null)
            {
                node = node.Next;

                if (node.Value < minValue)
                {
                    minValue = node.Value;
                }
            }

            return minValue;
        }

        // 17. Поиск индекса максимального элемента
        public int FindMaxValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            Node node = _root;
            int maxValue = node.Value;
            int maxIndex = 0;
            int index = 0;

            while (node.Next != null)
            {
                node = node.Next;
                index++;

                if (node.Value > maxValue)
                {
                    maxValue = node.Value;
                    maxIndex = index;
                }
            }

            return maxIndex;
        }

        // 18. Поиск индекса минимального элемента
        public int FindMinValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            Node node = _root;
            int minValue = node.Value;
            int minIndex = 0;
            int index = 0;

            while (node.Next != null)
            {
                node = node.Next;
                index++;

                if (node.Value < minValue)
                {
                    minValue = node.Value;
                    minIndex = index;
                }
            }

            return minIndex;
        }

        // 19. Сортировка по возрастанию 
        // по возрастанию пузырьком
        public void UpSortBubble()
        {
            int tmpValue;

            for (int i = 0; i < Length; i++)
            {
                Node currentNode = _root;

                while (currentNode.Next != null)
                {
                    if (currentNode.Value > currentNode.Next.Value)
                    {
                        tmpValue = currentNode.Value;
                        currentNode.Value = currentNode.Next.Value;
                        currentNode.Next.Value = tmpValue;
                    }

                    currentNode = currentNode.Next;
                }
            }
        }

        // по возрастанию вставками
        public void UpSortInsertions()
        {
            if (Length == 0)
            {
                _root = null;
            }
            else if (Length == 1)
            {
                _tail = _root;
            }
            else
            {
                Node previous = _root;
                Node current = _root.Next;

                for (int i = 1; i < Length; i++)
                {
                    Node currentSorted = _root;

                    if (current.Value < currentSorted.Value)
                    {
                        previous.Next = current.Next;
                        current.Next = currentSorted;
                        _root = current;
                        current = previous.Next;
                        continue;
                    }

                    if (current.Value >= previous.Value)
                    {
                        current = current.Next;
                        previous = previous.Next;
                        continue;
                    }
                
                    while (currentSorted.Next != current) //
                    {
                        if (current.Value < currentSorted.Next.Value)
                        {
                            previous.Next = current.Next;
                            current.Next = currentSorted.Next;
                            currentSorted.Next = current;
                            current = previous.Next;
                            break;
                        }

                        currentSorted = currentSorted.Next;
                    }

                    current = previous.Next;
                }
            }
        }

        // 20. Сортировка по убыванию
        // по убыванию вставками
        public void DownSortInsertions()
        {
            if (Length == 0)
            {
                _root = null;
            }
            else if (Length == 1)
            {
                _tail = _root;
            }
            else
            {
                Node previous = _root;
                Node current = _root.Next;

                for (int i = 1; i < Length; i++)
                {
                    Node currentSorted = _root;

                    if (current.Value > currentSorted.Value)
                    {
                        previous.Next = current.Next;
                        current.Next = currentSorted;
                        _root = current;
                        current = previous.Next;
                        continue;
                    }

                    if (current.Value <= previous.Value)
                    {
                        current = current.Next;
                        previous = previous.Next;
                        continue;
                    }

                    while (currentSorted.Next != current) 
                    {
                        if (current.Value > currentSorted.Next.Value)
                        {
                            previous.Next = current.Next;
                            current.Next = currentSorted.Next;
                            currentSorted.Next = current;
                            break;
                        }

                        currentSorted = currentSorted.Next;
                    }

                    current = previous.Next;
                }
            }
        }

        // 21. Удаление по значению первого
        public int RemoveFirstWithValue(int value)
        {
            int index = 0;

            if (Length == 0)
            {
                return -1;
            }
            else if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                    //return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                Node previous = _root;
                Node current = previous.Next;

                if (previous.Value == value)
                {
                    _root = current;
                    //return 0;
                }
                else
                {
                    index = 1;

                    while (current != null)
                    {
                        if (current.Value == value)
                        {
                            if (index != Length - 1)
                            {
                                previous.Next = current.Next;
                            }
                            else
                            {
                                _tail = previous;
                            }

                            Length--;
                            return index;
                        }

                        previous = current;
                        current = current.Next;
                        index++;
                    }

                    return -1;
                }
            }

            Length--;
            
            return index;
        }

        // 22. Удаление по значению всех 
        // красиво, но вообще не эффективно
        public int RemoveAllWithValue_tmp(int value)
        {
            int count = 0;
            Node current = _root;

            while (current != null)
            {
                if (current.Value == value)
                {
                    count++;
                }

                current = current.Next;
            }

            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RemoveFirstWithValue(value);
                }
            }
            else
            {
                return 0;
            }

            return count;
        }

        // вроде получше
        public int RemoveAllWithValue(int value)
        {
            if (Length == 0)
            {
                return 0;
            }
            
            int count = 0;

            if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;

                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                // удаление всех первых значащих элементов
                Node tmp = _root;

                while (tmp.Value == value)
                {   
                    count++;

                    if (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                    }
                    else
                    {
                        _root = null;
                        _tail = null;
                        Length = 0;

                        return count;
                    }
                }

                // удаление значащих элементов от первого не равного value до последнего
                _root = tmp;
                Node previous = _root;
                Node current = _root.Next;

                while (current != null)
                {
                    if (current.Value == value)
                    {
                        count++;
                        previous.Next = current.Next;
                        current = current.Next;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            }

            if (count != 0)
            {
                Length -= count;
                _tail = GetNodeByIndex(Length - 1);

                return count;
            }
            else
            {
                return -1;
            }
        }

        // Перегрузка стандартных методов
        public override bool Equals(object? obj)
        {
            LinkedList list = (LinkedList)obj;

            if (Length != list.Length)
            {
                return false;
            }

            if (Length == 0)
            {
                return true;
            }

            Node current = _root;
            Node currentList = list._root;

            if (Length != 1)
            {
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
            }
            else
            {
                if (current.Value != currentList.Value)
                {
                    return false;
                }
            }

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
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return string.Empty;
            }
        }

        // Приватные
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

        private void AddValuesArrayFromFirstElement(int[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                _tail.Next = new Node(values[i]);
                _tail = _tail.Next;
            }
        }

        private Node InsertValuesArrayFromFirstElement(Node tmp, int[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                tmp.Next = new Node(values[i]);
                tmp = tmp.Next;
            }

            return tmp;
        }

        private void InsertValuesArrayToNotEmptyListAtIndex(int index, int[] values)
        {
            if (index > 0)
            {
                Node tmp = new Node(values[0]);
                Node previous = GetNodeByIndex(index - 1);
                Node previousNext = previous.Next;
                previous.Next = tmp;
                tmp = InsertValuesArrayFromFirstElement(tmp, values);
                tmp.Next = previousNext;
            }
            else
            {
                Node previousNext = _root;
                Node tmp = new Node(values[0]);
                _root = tmp;
                tmp = InsertValuesArrayFromFirstElement(tmp, values);
                tmp.Next = previousNext;
            }

            Length += values.Length;
        }

        private void ThrowIndexOutOfRangeExceptionIfIndexOutOfLength(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index");
            }
        }

        private void ThrowNullReferenceExceptionIfValuesArrayIsNull(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }
        }
    }
}
