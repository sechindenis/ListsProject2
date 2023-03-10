using System.Security.Cryptography.X509Certificates;

namespace ListsProject2
{
    public class ArrayList
    {
        private int[] _array;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                _array[index] = value;
            }
        }
        
        // 23. Создать три конструктора
        // пустой конструктор
        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        // конструктор на основе одного элемента
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[2];
            _array[0] = value;
        }

        // конструктор на основе имеющегося массива
        public ArrayList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            Length = values.Length;
            _array = values;
            UpSize();
        }

        // пользовательская длина списка
        public int Length { get; private set; }

        // МЕТОДЫ
        // 1. Добавление значения в конец
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            
            _array[Length] = value;
            Length++;
        }

        // 24. Добавление массива в конец
        public void Add(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }
            
            int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

            if (_array.Length < requiredLength)
            {
                ChangeLength(requiredLength);
            }

            InsertArrayAtIndex(Length, values);
            Length += values.Length;
        }

        // 2-3. Добавление значения по индексу (в начало - по индексу 0)
        public void InsertAt(int index, int value)
        {
            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                if (Length == _array.Length)
                {
                    UpSize();
                }

                MoveRightFromIndexByNumber(index, 1);
                _array[index] = value;
                Length++;
            }
            else
            {
                Length = 1;

                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                _array[index] = value;
            }
        }

        // 25-26. Добавление массива по индексу (в начало - по индексу 0)
        public void InsertAt(int index, int[] values)
        {
            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                if (values is null)
                {
                    throw new NullReferenceException("values is null");
                }

                int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

                if (_array.Length < requiredLength)
                {
                    ChangeLength(requiredLength);
                }

                MoveRightFromIndexByNumber(index, values.Length);
                InsertArrayAtIndex(index, values);
                Length += values.Length;
            }
            else
            {
                if (index < 0 || index > 0)
                {
                    throw new IndexOutOfRangeException("index");
                }

                if (values is null)
                {
                    throw new NullReferenceException("values is null");
                }

                Length = values.Length;
                int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

                if (_array.Length < requiredLength)
                {
                    ChangeLength(requiredLength);
                }

                InsertArrayAtIndex(index, values);
            }
        }

        // 4. Удаление из конца одного элемента
        public bool Remove()
        {
            if (Length == 0)
            {
                return false;
            }

            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 7. Удаление из конца N элементов
        public bool Remove(int number)
        {
            if (number < 0 || number > Length)
            {
                //throw new ArgumentOutOfRangeException("number > Length");
                return false;
            }

            if (Length == 0)
            {
                return false;
            }

            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }
        
        // 5-6. Удаление одного элемента по индексу (в начале - по индексу 0)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                // throw new IndexOutOfRangeException("index"); 
                return false;
            }

            MoveLeftFromIndexByNumber(index + 1, 1);
            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 8-9. Удаление N элементов по индексу (в начале - по индексу 0)
        public bool RemoveAt(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                //throw new IndexOutOfRangeException("index");
                return false;
            }

            if (number > Length - index)
            {
                //throw new ArgumentOutOfRangeException("index + number > Length");
                return false;
            }

            MoveLeftFromIndexByNumber(index + number, number);
            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 12. Первый индекс по значению
        public int GetIndexByValue(int value)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i; 
                    break;
                }
            }

            return index;
        }

        // 14. Реверс
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
            }
        }

        // 15. Поиск значения максимального элемента
        public int FindMaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }
            
            int maxValue = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                }
            }

            return maxValue;
        }

        // 16. Поиск значения минимального элемента
        public int FindMinValue()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            int minValue = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
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

            int maxIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
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

            int minIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // 19. Сортировка по возрастанию
        // пузырьком
        public void UpSortBubble()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = Length - 1; j > i; j--)
                {
                    if (_array[i] > _array[j])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }
        }

        // вставками
        public void UpSortInsertions()
        {
            int tmp;

            for (int i = 1; i < Length; i++)
            {
                int j = i - 1;
                tmp = _array[i];

                while (j >= 0 && _array[j] > tmp)
                {
                    _array[j + 1] = _array[j];
                    _array[j] = tmp;
                    j--;
                }
            }
        }

        // быстрая сортировка
        public ArrayList UpSortQuick_FirstTry()
        {      
            if (Length == 0)
            {
                return this;
            }
            if (Length == 1)
            {
                return this;
            }
            else
            {
                ArrayList left = new ArrayList();
                ArrayList right = new ArrayList();
                int endsMean = (this[0] + this[Length - 1]) / 2;

                for (int i = 0; i < Length; i++)
                {
                    if (this[i] <= endsMean)
                    {
                        left.Add(this[i]);
                    }
                    else
                    {
                        right.Add(this[i]);
                    }
                }

                left = left.UpSortQuick();
                right = right.UpSortQuick();

                return left.Concatenate(right);
            }
        }


        public ArrayList UpSortQuick()
        {
            int[] tmp = GetIntArray();
            tmp = UpSortQuickForInts(tmp);
            ArrayList list = new ArrayList(tmp);

            return list;
        }

        public int[] UpSortQuickForInts(int[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }
            if (array.Length == 1)
            {
                return array;
            }
            else
            {
                int[] left = new int[0];
                int[] right = new int[0];
                int p = (array[0] + array[array.Length - 1]) / 2;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] <= p)
                    {
                        Array.Resize(ref left, left.Length + 1);
                        left[left.Length - 1] = array[i];
                    }
                    else
                    {
                        Array.Resize(ref right, right.Length + 1);
                        right[right.Length - 1] = array[i];
                    }
                }

                left = UpSortQuickForInts(left);
                right = UpSortQuickForInts(right);

                return left.Concat(right).ToArray();
            }
        }

        // 20. Сортировка по убыванию
        public void DownSort()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = Length - 1; j > i; j--)
                {
                    if (_array[i] < _array[j])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }
        }

        // 21. Удаление по значению первого
        public int RemoveFirstWithValue(int value)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    MoveLeftFromIndexByNumber(index + 1, 1);
                    Length--;
                    break;
                }
            }

            return index;
        }

        // 22. Удаление по значению всех
        public int RemoveAllWithValue(int value)
        {
            int[] tmp = new int[0];
            int count = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    count++;
                }
                else
                {
                    Array.Resize<int>(ref tmp, tmp.Length + 1);
                    tmp[tmp.Length - 1] = _array[i];
                }
            }

            _array = tmp;
            Length -= count;

            return count;
        }

        // Перегрузка стандартных методов
        public override bool Equals(object? obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] != arrayList._array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Length; i++)
            {
                s += _array[i].ToString() + " ";
            }

            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Приватные
        private void ChangeLength(int newLength)
        {
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            ChangeLength(newLength);
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d);
            ChangeLength(newLength);
        }

        private void MoveRightFromIndexByNumber(int index, int number)
        {
            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + number] = _array[i];
            }
        }

        private void MoveLeftFromIndexByNumber(int index, int number)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i - number] = _array[i];
            }
        }

        private void InsertArrayAtIndex(int index, int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                _array[i + index] = values[i];
            }
        }

        public ArrayList Concatenate (ArrayList list)
        {
            int[] listInts = list.GetIntArray();
            Add(listInts);

            return this;
        }

        public int[] GetIntArray()
        {
            int[] ints = _array;
            Array.Resize(ref ints, Length);            
            
            return ints;
        }
    }
}