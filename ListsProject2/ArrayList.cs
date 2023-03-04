namespace ListsProject2
{
    public class ArrayList
    {
        private int[] _array;
        
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

        // пользовательская длина списка
        public int Length { get; private set; }

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

            for (int i = Length; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = value;
            Length++;
        }

        // 3. Добавление значения по индексу
        public void InsertAt(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            
            if (Length == _array.Length)
            {
                UpSize();
            }

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

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

            _array[Length - 1] = 0;
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

            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
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
                throw new ArgumentOutOfRangeException("index"); // return false;
            }

            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
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

            } 

            return true;
        }

        // 10. Вернуть длину
        public int GetLength()
        {
            return Length;
        }

        // 11. Вернуть длину
        public int GetElement(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("index"); // return false;
            }

            return _array[index];
        }

        // приватные
        //private void PassValuesToAnotherArray(int[] oneArray, int[] anotherArray)
        //{
        //    for (int i = 0; i < _array.Length; i++)
        //    {
        //        tmpArray[i] = _array[i];
        //    }
        //}

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
    }
}