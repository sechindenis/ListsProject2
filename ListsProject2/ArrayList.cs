namespace ListsProject2
{
    public class ArrayList
    {
        private int[] _array;

        private int _length;
        
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
            int _arrayLength = (int)(array.Length * 1.33d + 1);
            _array = new int[_arrayLength];

            for (int i = 0; i < Length; i++)
            {
                _array[i] = array[i];
            }
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
        public bool RemoveLastElement()
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
        public bool RemoveFirstElement()
        {
            if (Length == 0)
            {
                return false;
            }

            MoveLeftNextFromIndex(1);
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

            MoveLeftNextFromIndex(index + 1);
            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 7. Удаление из конца N элементов -
        // В ЭТОЙ И В 8-9 ЗАДАЧАХ УТОЧНИТЬ МЕХАНИЗМ ИЗМЕНЕНИЯ РАЗМЕРА
        // УТОЧНИТЬ ФОРМАТ МЕТОДА
        public bool RemoveFromEnd(int number)
        {
            if (number > Length)
            {
                throw new ArgumentOutOfRangeException("number > Length");
            }

            Length -= number;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }
            else
            {
                // дописать
            } 

            return true;
        }

        // 11. Доступ по индексу
        public int GetValueByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index"); // return false;
            }

            return _array[index];
        }

        // 12. Доступ по индексу
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

        // 13. Доступ по индексу - ПЕРЕДЕЛАТЬ
        public void ChangeValueByIndex(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("index");
            }

            _array[index] = value;
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

            MoveLeftNextFromIndex(index);
            Length--;

            return index;
        }

        // 22 первая попытка. Удаление по значению всех
        public int RemoveAllByValueFIRST(int value)
        {
            int count = 0;
            int start = 0;
            count += RemoveAndMoveLeft(start, count, value);

            return count;
        }
        // вспомогательный метод к "22 первая попытка" (рекурсивный метод, передвигающий массив начиная с элемента влево на один)
        private int RemoveAndMoveLeft(int start, int count, int value)
        {
            for (int i = start; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    count++;
                    MoveLeftNextFromIndex(i);
                    Length--;
                    count = RemoveAndMoveLeft(i, count, value);
                }
            }

            return count;
        }

        // 22 вторая попытка. Удаление по значению всех
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
        
        // приватные

        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d);
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void MoveRightFromIndex(int index)
        {
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
        }

        private void MoveLeftNextFromIndex(int index)
        {
            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
        }
    }
}