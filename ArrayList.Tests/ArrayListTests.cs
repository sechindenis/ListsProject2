using Newtonsoft.Json.Linq;

namespace ListsProject2.Tests
{
    public class ArrayListTest
    {
        // ТЕСТЫ КОНСТРУКТОРОВ ----------------------------------------------------------------------------------------------------------------------------
        // пустой конструктор
        [Test]
        public void ConstructorEmptyTest()
        {
            int expected = 0;
            ArrayList list = new ArrayList();
            int actual = list.Length;
            
            Assert.That(actual, Is.EqualTo(expected));
        }

        // конструктор по значению
        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(1, 0)]
        public void ConstructorByValueTest(int expectedLength, int expectedValue)
        {
            ArrayList list = new ArrayList(expectedValue);
            int actualLength = list.Length;
            int actualValue = list[0];

            Assert.That(actualLength, Is.EqualTo(expectedLength));
            Assert.That(actualValue,  Is.EqualTo(expectedValue));
        }

        // конструктор по массиву
        // позитивный
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void ConstructorByArrayOfValuesPositiveTest(int index, int expectedValue)
        {
            int[] ints = new int[] { 1, 2, 3 };
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int expectedLength = ints.Length;
            int actualLength = list.Length;
            int actualValue = list[index];

            Assert.That(actualValue,  Is.EqualTo(expectedValue));
            Assert.That(actualLength, Is.EqualTo(expectedLength));
        }

        // конструктор по массиву
        // негативный тест
        [Test]
        public void ConstructorByArrayOfValuesNegativeTest()
        {
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => new ArrayList(ints));
        }

        // Метод Add - добавление в конец ------------------------------------------------------------------------------------------------------------------
        // один элемент в конец
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_AddValueToEmptyList_ValueAddedToTheEnd_Test(int value)
        {
            ArrayList actual = new ArrayList();
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_AddValueToOneElementList_ValueAddedToTheEnd_Test(int value)
        {
            ArrayList actual = new ArrayList(5);
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { 5, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_AddValueToListOfSeveralElements_ValueAddedToTheEnd_Test(int value)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // массив в конец
        // позитивные тесты
        [Test]
        public void Add_AddArrayToEmptyList_ArrayAddedToTheEnd_Test()
        {
            ArrayList actual = new ArrayList();
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_AddArrayToOneElementList_ArrayAddedToTheEnd_Test()
        {
            ArrayList actual = new ArrayList(5);
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 5, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_AddArrayToListOfSeveralElements_ArrayAddedToTheEnd_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // негативные тесты
        [Test]
        public void Add_AddNullArrayToEmptyList_ThrowNullReferenceException_Test()
        {
            ArrayList actual = new ArrayList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_AddNullArrayToOneElementList_ThrowNullReferenceException_Test()
        {
            ArrayList actual = new ArrayList(6);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_AddNullArrayToListOfSeveralElements_ThrowNullReferenceException_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        // Добавление по индексу ---------------------------------------------------------------------------------------------------------------------
        // вставка значения по индексу
        // позитивные (индекс в диапазоне)
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void InsertAt_InsertValueAtIndexToEmptyList_ElementByIndexEqualsValue_Test(int value)
        {
            ArrayList actual = new ArrayList();
            actual.InsertAt(0, value);
            ArrayList expected = new ArrayList(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void InsertAt_InsertValueAtIndexToOneElementList_ElementByIndexEqualsValue_Test(int value)
        {
            ArrayList actual = new ArrayList(5);
            actual.InsertAt(0, value);
            ArrayList expected = new ArrayList(new int[] { value, 5 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void InsertAt_InsertValueAtIndexToListOfSeveralElements_ElementByIndexEqualsValue_Test(int index, int value)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.InsertAt(index, value);
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForInsertValueAt(index));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // негативные
        // индекс вне диапазона
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertValueAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertValueAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void InsertAt_InsertValueAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        // вставка массива по индексу
        // позитивные (индекс в диапазоне и массив is NOT null)
        [Test]
        public void InsertAt_InsertArrayAtIndexToEmptyList_ArrayAdded_Test()
        {
            ArrayList actual = new ArrayList();
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void InsertAt_InsertArrayAtIndexToOneElementList_ArrayAdded_Test()
        {
            ArrayList actual = new ArrayList(5);
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 5 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void InsertAt_InsertArrayAtIndexToListOfSeveralElements_ArrayAddedToIndex_Test(int index)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.InsertAt(index, new int[] { 5, 6, 7 });
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForInsertArrayAt(index));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // негативные
        // индекс ВНЕ диапазона, НО массив is NOT null, тесты на IndexOutOfRangeException
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertArrayAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertArrayAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void InsertAt_InsertArrayAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        // негативные
        // индекс в диапазоне, НО массив is null, тесты на NullReferenceException
        [Test]
        public void Insert_InsertNullArrayToEmptyList_ThrowNullReferenceException_Test()
        {
            ArrayList list = new ArrayList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        [Test]
        public void InsertAt_InsertNullArrayToOneElementList_ThrowNullReferenceException_Test()
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        [Test]
        public void InsertAt_InsertNullArrayToListOfSeveralElements_ThrowNullReferenceException_Test()
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        // негативные
        // индекс ВНЕ диапазона, И массив is null, тесты на очередность вывода ошибки (первой идет IndexOutOfRangeException)
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertNullArrayAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = null;

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_InsertNullArrayAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null; 

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]  
        public void InsertAt_InsertNullArrayAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        // Удаление из конца одного элемента --------------------------------------------------------------------------------------------------------
        // прямой, позитивный, непустой лист
        [TestCase(0, true)]
        [TestCase(1, true)]
        public void Remove_RemovesOneElementFromNotEmptyList_ReturnsTrue_Test(int mockParametr, bool expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForRemove(mockParametr));
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }


        // прямой, негативный, пустой лист
        [TestCase(false)]
        public void Remove_RemovesOneElementFromNotEmptyList_ReturnsFalse_Test(bool expected)
        {
            ArrayList list = new ArrayList();
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, на лист более чем из одного элемента
        [Test]
        public void Remove_RemovesOneElementFromLongList_NewListOneElementLess_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.Remove();
            ArrayList expected = new ArrayList(new int[] { 1, 2 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, на лист из одного элемента
        [Test]
        public void Remove_RemovesOneElementFromoneElementList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1 });
            actual.Remove();
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Удаление из конца N элементов ---------------------------------------------------------------------------------------------------------------
        // прямой, непустой лист
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void Remove_RemovesNumberElementFromNotEmptyList_ReturnsTrueOrFalse_Test(int numberOfElements, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5});
            bool actual = list.Remove(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой, пустой лист
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void Remove_RemovesNumberElementFromEmptyList_ReturnsFalse_Test(int numberOfElements, bool expected)
        {
            ArrayList list = new ArrayList();
            bool actual = list.Remove(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются НЕпустыми в итоге
        [Test]
        public void Remove_RemovesNumberElementFromNotEmptyList_NewNotEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.Remove(2);
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются пустыми в итоге
        [Test]
        public void Remove_RemovesNumberElementFromNotEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.Remove(5);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Удаление одного элемента по индексу -----------------------------------------------------------------------------------------------------------
        // прямой для непустого листа
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(4, true)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void RemoveAt_RemovesOneElementAtIndexFromNotEmptyList_ReturnsTrueOrFalse_Test(int index, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(index);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой для пустого листа
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(4, false)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void RemoveAt_RemovesOneElementAtIndexFromEmptyList_ReturnsFalse_Test(int index, bool expected)
        {
            ArrayList list = new ArrayList();
            bool actual = list.RemoveAt(index);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются НЕпустыми в итоге
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void RemoveAt_RemovesOneElementAtIndexFromNotEmptyList_NewNotEmptyList_Test(int mockNumber)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockForRemoveElementAt(-1));
            actual.RemoveAt(mockNumber);
            ArrayList expected = new ArrayList(ArrayMock.GetMockForRemoveElementAt(mockNumber));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются пустыми в итоге
        [Test]
        public void RemoveAt_RemovesOneElementAtIndexFromNotEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1 });
            actual.RemoveAt(0);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Удаление N элементов по индексу ---------------------------------------------------------------------------------------------------------------
        // прямой для непустого листа
        //
        [TestCase(0, 1, true)]
        [TestCase(1, 2, true)]
        [TestCase(4, 1, true)]
        //
        [TestCase(0, 6, false)]
        [TestCase(1, 9, false)]
        [TestCase(4, 2, false)]
        //
        [TestCase(6, 1, false)]
        [TestCase(-1, 1, false)]
        [TestCase(-100, 1, false)]
        //
        [TestCase(6, 10, false)]
        [TestCase(-1, 10, false)]
        [TestCase(-100, 10, false)]
        public void RemoveAt_RemovesNumberOfElementsAtIndexFromNotEmptyList_ReturnsTrueOrFalse_Test(int index, int number, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(index, number);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой для пустого листа
        [TestCase(0, 1, false)]
        [TestCase(1, 2, false)]
        [TestCase(4, 1, false)]
        //
        [TestCase(0, 6, false)]
        [TestCase(1, 9, false)]
        [TestCase(4, 2, false)]
        //
        [TestCase(6, 1, false)]
        [TestCase(-1, 1, false)]
        [TestCase(-100, 1, false)]
        //
        [TestCase(6, 10, false)]
        [TestCase(-1, 10, false)]
        [TestCase(-100, 10, false)]
        public void RemoveAt_RemovesNumberOfElementsAtIndexFromNotEmptyList_ReturnsFalse_Test(int index, int number, bool expected)
        {
            ArrayList list = new ArrayList();
            bool actual = list.RemoveAt(index, number);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются НЕпустыми в итоге
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveAt_RemovesNumberOfElementsAtIndexFromNotEmptyList_NewNotEmptyList_Test(int mockNumber)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockForRemoveNumberOfElementsAt(-1));
            actual.RemoveAt(mockNumber, mockNumber);
            ArrayList expected = new ArrayList(ArrayMock.GetMockForRemoveNumberOfElementsAt(mockNumber));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный для листов, которые остаются пустыми в итоге
        [Test]
        public void RemoveAt_RemovesNumberOfElementsAtIndexFromNotEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.RemoveAt(0, 5);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Получение индекса первого элемента со значением -------------------------------------------------------------------------------------------------
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(5, 4)]
        [TestCase(10, -1)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void GetIndexByValueTest(int value, int expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            int actual = list.GetIndexByValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(1, -1)]
        public void GetIndexByValueEmptyListTest(int value, int expected)
        {
            ArrayList list = new ArrayList();
            int actual = list.GetIndexByValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Реверс -------------------------------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void ReverseNotEmptyListTest(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForReverse(mockParametr));
            actual.Reverse();
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForReverse(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void ReverseEmptyListTest()
        {
            ArrayList actual = new ArrayList();
            actual.Reverse();
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Поиск максимального элемента ------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 5)]
        [TestCase(2, 10000)]
        [TestCase(3, 5)]
        [TestCase(4, 1)]
        [TestCase(5, -1)]
        [TestCase(6, 0)]
        public void FindMaxValueInNotEmptyListTest(int mockParametr, int expected) 
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForReverse(mockParametr));
            int actual = list.FindMaxValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // лист из 1 элемента
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FindMaxValueInOneElementListTest(int expected)
        {
            ArrayList list = new ArrayList(expected);
            int actual = list.FindMaxValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void FindMaxValueInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMaxValue());
        }

        // Поиск минимального элемента ------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 1)]
        [TestCase(2, 10)]
        [TestCase(3, -2)]
        [TestCase(4, 1)]
        [TestCase(5, -3)]
        [TestCase(7, 0)]
        public void FindMinValueInNotEmptyListTest(int mockParametr, int expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForReverse(mockParametr));
            int actual = list.FindMinValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void FindMinValueInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMinValue());
        }

        // Поиск индекса максимального элемента ------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 4)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 1)]
        public void FindMaxValueIndexInNotEmptyListTest(int mockParametr, int expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForReverse(mockParametr));
            int actual = list.FindMaxValueIndex();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void FindMaxValueIndexInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMaxValueIndex());
        }

        // Поиск индекса минимального элемента ------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 1)]
        [TestCase(4, 0)]
        [TestCase(5, 2)]
        [TestCase(7, 1)]
        public void FindMinValueIndexInNotEmptyListTest(int mockParametr, int expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForReverse(mockParametr));
            int actual = list.FindMinValueIndex();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void FindMinValueIndexInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMinValueIndex());
        }

        //// Сортировка по возрастанию ПУЗЫРЕК ------------------------------------------------------------------------------------------------------------------------
        //// непустой лист
        //[TestCase(1, 1)]
        //[TestCase(2, 2)]
        //[TestCase(3, 3)]
        //[TestCase(4, 4)]
        //[TestCase(5, 5)]
        //public void UpSortBubble_NotEmptyListTest(int mockParametr, int mockExpected)
        //{
        //    ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForUpSort(mockParametr));
        //    actual.UpSortBubble();
        //    ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForUpSort(mockExpected));

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //// лист из одного элемента
        //[Test]
        //public void UpSortBubble_OneElementListTest()
        //{
        //    ArrayList actual = new ArrayList(1);
        //    actual.UpSortBubble();
        //    ArrayList expected = new ArrayList(1);

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //// пустой лист
        //[Test]
        //public void UpSortBubble_EmptyListTest()
        //{
        //    ArrayList actual = new ArrayList();
        //    actual.UpSortBubble();
        //    ArrayList expected = new ArrayList();

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //// Сортировка по возрастанию ВСТАВКИ ------------------------------------------------------------------------------------------------------------------------
        //// непустой лист
        //[TestCase(1, 1)]
        //[TestCase(2, 2)]
        //[TestCase(3, 3)]
        //[TestCase(4, 4)]
        //[TestCase(5, 5)]
        //public void UpSortInsertions_NotEmptyListTest(int mockParametr, int mockExpected)
        //{
        //    ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForUpSort(mockParametr));
        //    actual.UpSortInsertions();
        //    ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForUpSort(mockExpected));

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //// лист из одного элемента
        //[Test]
        //public void UpSortInsertions_OneElementListTest()
        //{
        //    ArrayList actual = new ArrayList(1);
        //    actual.UpSortInsertions();
        //    ArrayList expected = new ArrayList(1);

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //// пустой лист
        //[Test]
        //public void UpSortInsertions_EmptyListTest()
        //{
        //    ArrayList actual = new ArrayList();
        //    actual.UpSortInsertions();
        //    ArrayList expected = new ArrayList();

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        // Сортировка по возрастанию БЫСТРАЯ ------------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void UpSortQuick_NotEmptyListTest(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForUpSort(mockParametr));
            actual = actual.UpSortQuick();
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForUpSort(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // лист из одного элемента
        [Test]
        public void UpSortQuick_OneElementListTest()
        {
            ArrayList actual = new ArrayList(1);
            actual = actual.UpSortQuick();
            ArrayList expected = new ArrayList(1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void UpSortQuick_EmptyListTest()
        {
            ArrayList actual = new ArrayList();
            actual = actual.UpSortQuick();
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Сортировка по убыванию ---------------------------------------------------------------------------------------------------------------------------
        // непустой лист
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void DownSortNotEmptyListTest(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForDownSort(mockParametr));
            actual.DownSort();
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForDownSort(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // пустой лист
        [Test]
        public void DownSortEmptyListTest()
        {
            ArrayList actual = new ArrayList();
            actual.DownSort();
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Удаление по значению первого ------------------------------------------------------------------------------------------------------------------------
        // прямой, непустой лист
        [TestCase(1, 0)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        [TestCase(5, -1)]
        public void RemoveFirstWithValue_RemoveFirstWithValueInNotEmptyList_ReturnIndex_Test(int value, int expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForRemoveFirstByValue(value));
            int actual = list.RemoveFirstWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой, пустой лист
        [TestCase(1, -1)]
        [TestCase(2, -1)]
        [TestCase(3, -1)]
        [TestCase(4, -1)]
        [TestCase(5, -1)]
        public void RemoveFirstWithValue_RemoveFirstWithValueInEmptyList_ReturnIndex_Test(int value, int expected)
        {
            ArrayList list = new ArrayList();
            int actual = list.RemoveFirstWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, непустой лист на входе и выходе
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void RemoveFirstWithValue_RemoveFirstWithValueInNotEmptyList_NewNotEmptyList_Test(int value)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForRemoveFirstByValue(value));
            actual.RemoveFirstWithValue(value);
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForRemoveFirstByValue(value));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, непустой лист на входе, пустой лист на выходе
        [Test]
        public void RemoveFirstWithValue_RemoveFirstWithValueInNotEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1 });
            actual.RemoveFirstWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, пустой лист на входе и выходе
        [Test]
        public void RemoveFirstWithValue_RemoveFirstWithValueInEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList();
            actual.RemoveFirstWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Удаление по значению всех ------------------------------------------------------------------------------------------------------------------------
        // прямой, непустой лист
        [TestCase(1, 3)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        public void RemoveAllWithValue_RemoveAllWithValueInNotEmptyList_ReturnAmount_Test(int value, int expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForRemoveAllByValue(value));
            int actual = list.RemoveAllWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой, непустой лист
        [Test]
        public void RemoveAllWithValue_RemoveAllWithValueInEmptyList_ReturnZero_Test()
        {
            ArrayList list = new ArrayList();
            int actual = list.RemoveAllWithValue(1);

            Assert.That(actual, Is.EqualTo(0));
        }

        // косвенный, непустой лист на входе и выходе
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        public void RemoveAllWithValue_RemoveAllWithValueInNotEmptyList_NewNotEmptyList_Test(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(ArrayMock.GetMockParametrForRemoveAllByValue(mockParametr));
            actual.RemoveAllWithValue(mockParametr);
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForRemoveAllByValue(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, непустой лист на входе, пустой лист на выходе
        [Test]
        public void RemoveAllWithValue_RemoveAllWithValueInNotEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 1, 1, 1 });
            actual.RemoveAllWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // косвенный, пустой лист на входе и выходе
        [Test]
        public void RemoveAllWithValue_RemoveAllWithValueInEmptyList_NewEmptyList_Test()
        {
            ArrayList actual = new ArrayList();
            actual.RemoveAllWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public static class ArrayMock
    {
        public static int[] GetMockExpectedForInsertValueAt(int number)
        {
            int[] expectedInts = new int[0];

            switch (number)
            {
                case 0:
                    expectedInts = new int[] { 0, 1, 2, 3 };
                    break;

                case 1:
                    expectedInts = new int[] { 1, 1, 2, 3 };
                    break;

                case 2:
                    expectedInts = new int[] { 1, 2, 2, 3 };
                    break;

                case 3:
                    expectedInts = new int[] { 1, 2, 3, 3 };
                    break;
            }

            return expectedInts;
        }

        public static int[] GetMockExpectedForInsertArrayAt(int number) 
        {
            int[] expectedInts = new int[0];

            switch (number)
            {
                case 0:
                    expectedInts = new int[] { 5, 6, 7, 1, 2, 3}; 
                    break;

                case 1:
                    expectedInts = new int[] { 1, 5, 6, 7, 2, 3 };
                    break;

                case 2:
                    expectedInts = new int[] { 1, 2, 5, 6, 7, 3 };
                    break;
            }

            return expectedInts;
        }

        public static int[] GetMockParametrForRemove(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 0:
                    parametr = new int[] { 1, 2, 3 };
                    break;

                case 1:
                    parametr = new int[] { 1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForRemove(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 0:
                    parametr = new int[] { 1, 2 };
                    break;

                case 1:
                    parametr = new int[] { 1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockForRemoveElementAt(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case -1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 0:
                    parametr = new int[] { 2, 3, 4, 5 };
                    break;

                case 1:
                    parametr = new int[] { 1, 3, 4, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 2, 3, 4 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockForRemoveNumberOfElementsAt(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case -1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 1:
                    parametr = new int[] { 1, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 1, 2, 5 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockParametrForReverse(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 1000, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -1, -2, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -1, -2, -3 };
                    break;

                case 6:
                    parametr = new int[] { -10, 0, -3 };
                    break;

                case 7:
                    parametr = new int[] { 10, 0, 3 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForReverse(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 5, 4, 3, 2, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10000, 1000, 100, 10 };
                    break;

                case 3:
                    parametr = new int[] { 5, -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockParametrForUpSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 5, 4, 3, 2, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10000, 1000, 100, 10 };
                    break;

                case 3:
                    parametr = new int[] { 5, -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -1, -2, -3 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForUpSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 1000, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockParametrForDownSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 1000, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForDownSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 5, 4, 3, 2, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10000, 1000, 100, 10 };
                    break;

                case 3:
                    parametr = new int[] { 5, -1, -2 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -1, -2, -3 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockParametrForRemoveFirstByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 2, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1, 3 };
                    break;

                case 4:
                    parametr = new int[] { 4, 4, 4 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForRemoveFirstByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 4, 4 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockParametrForRemoveAllByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 1, 4, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 2, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, 3, 3 };
                    break;

                case 4:
                    parametr = new int[] { 4, 4, 4 };
                    break;

                case 5:
                    parametr = new int[] { 9, 5, 7, 5, 2, 5, 3, 5, 2 };
                    break;

                case 6:
                    parametr = new int[] { 9, 6, 7, 6, 2, 6, 3, 6, 6 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForRemoveAllByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 2, 4 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2 };
                    break;

                case 5:
                    parametr = new int[] { 9, 7, 2, 3, 2 };
                    break;

                case 6:
                    parametr = new int[] { 9, 7, 2, 3 };
                    break;
            }

            return parametr;
        }
    }
}