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
        public ArrayList(int[] array)
        {
            Length = array.Length;
            _array = array;
            UpSize();
        }

        // пользовательская длина списка - В ЧЕМ СМЫСЛ добавления условий?
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
        
        // 2. Добавление значения в начало
        public void AddToBegining(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            MoveRightFromIndex(0);
            _array[0] = value;
            Length++;
        }

        // 3. Добавление значения по индексу
        public void InsertAt(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index");
            }
            
            if (Length == _array.Length)
            {
                UpSize();
            }

            MoveRightFromIndex(index);
            _array[index] = value;
            Length++;
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

        // 5. Удаление из начала одного элемента
        public bool RemoveAtBegining()
        {
            if (Length == 0)
            {
                return false;
            }

            MoveLeftFromIndex(1);
            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 6. Удаление одного элемента по индексу - УТОЧНИТЬ ФОРМАТ ВЫВОДА
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index"); // return false;
            }

            MoveLeftFromIndex(index + 1);
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
            if (number > Length)
            {
                throw new ArgumentOutOfRangeException("number > Length");
            }

            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 8. Удаление из начала N элементов
        public bool RemoveAtBegining(int number)
        {
            if (number > Length)
            {
                throw new ArgumentOutOfRangeException("number > Length");
            }

            for (int i = 0; i < Length - number; i++)
            {
                _array[i] = _array[i + number];
            }
            
            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 9. Удаление N элементов по индексу
        public bool RemoveAt(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index");
            }

            if (number > Length - index)
            {
                throw new ArgumentOutOfRangeException("index + number > Length");
            }

            for (int i = index; i < Length - number; i++)
            {
                _array[i] = _array[i + number];
            }

            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 12. Первый индкс по значению
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
                return 0; // ПЕРЕДЕЛАТЬ (возвращать что-то другое)
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
                return 0; // ПЕРЕДЕЛАТЬ (возвращать что-то другое)
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
                return 0; // ПЕРЕДЕЛАТЬ (возвращать что-то другое)
            }

            int maxIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maxIndex)
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
                return 0; // ПЕРЕДЕЛАТЬ (возвращать что-то другое)
            }

            int minIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minIndex)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // 19. Сортировка по возрастанию
        public void UpSort()
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
        public int RemoveOneByValue(int value)
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

            MoveLeftFromIndex(index + 1);
            Length--;

            return index;
        }

        // 22. Удаление по значению всех
        // первая попытка - аж стыдно за этот ужас...
        public int RemoveAllByValueFIRST(int value)
        {
            int count = 0;
            int start = 0;
            count += RemoveAndMoveLeft(start, count, value);

            return count;
        }

        // вспомогательный метод к первой попытке (рекурсивный метод, передвигающий массив начиная с элемента влево на один)
        private int RemoveAndMoveLeft(int start, int count, int value)
        {
            for (int i = start; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    count++;
                    MoveLeftFromIndex(i + 1);
                    Length--;
                    count = RemoveAndMoveLeft(i, count, value);
                }
            }

            return count;
        }

        // вторая попытка
        public int RemoveAllByValueSECOND(int value)
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

        // 24. Добавление массива в конец
        // первая попытка - название предполагается без "FIRST"
        public void AddFIRST(int[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                Add(value[i]);
            }
        }

        // вторая попытка, вроде бы более эффективно по количеству действий - название предполагается без "SECOND"
        public void AddSECOND(int[] value)
        {
            int requiredLength = (int)((Length + value.Length) * 1.33d + 1);

            if (_array.Length < requiredLength)
            {
                ChangeLength(requiredLength);
            }

            for (int i = 0; i < value.Length; i++)
            {
                _array[i + Length] = value[i];
            }

            Length += value.Length;
        }

        // 25. Добавление массива в начало
        public void AddToBegining(int[] value)
        {
            int requiredLength = (int)((Length + value.Length) * 1.33d + 1);

            if (_array.Length < requiredLength)
            {
                ChangeLength(requiredLength);
            }

            for (int i = 0; i < value.Length; i++)
            {
                _array[i + Length] = value[i];
            }

            Length += value.Length;
        }

        // 26. Добавление массива в начало
        public void InsertAt(int index, int[] value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index");
            }

            int requiredLength = (int)((Length + value.Length) * 1.33d + 1);

            if (_array.Length < requiredLength)
            {
                ChangeLength(requiredLength);
            }

            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + value.Length] = _array[i];
            }

            for (int i = 0; i < value.Length; i++)
            {
                _array[i + index] = value[i];
            }

            Length += value.Length;
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

        // приватные
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

        private void MoveRightFromIndex(int index)
        {
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
        }

        private void MoveLeftFromIndex(int index)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i - 1] = _array[i];
            }
        }

        private void ChangeLength(int newLength)
        {
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}