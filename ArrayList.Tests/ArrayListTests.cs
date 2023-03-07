using Newtonsoft.Json.Linq;

namespace ListsProject2.Tests
{
    public class ArrayListTest
    {
        // ТЕСТЫ КОНСТРУКТОРОВ
        // пустой конструктор
        [Test]
        public void EmptyConstructorTest()
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
        [Test]
        public void ConstructorByArrayOfValuesPositiveTest()
        {
            int[] ints = new int[] { 1, 2, 3 };
            ArrayList expectedList = new ArrayList(new int[] { 1, 2, 3 });
            ArrayList actualList = new ArrayList(ints);
            int expectedLength = ints.Length;
            int actualLength = actualList.Length;

            Assert.That(actualList,  Is.EqualTo(expectedList));
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

        // Метод Add - добавление в конец -----------------------------------------------------------------------------------
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

        // Добавление по индексу --------------------------------------------------------------------------------------------------------
        // вставка значения по индексу
        // позитивные (индекс в диапазоне)
        [TestCase(0, 1)]
        [TestCase(0, -1)]
        [TestCase(0, 0)]
        public void Insert_InsertValueAtIndexToEmptyList_ElementByIndexEqualsValue_Test(int index, int expected)
        {
            ArrayList list = new ArrayList();
            list.InsertAt(index, expected);
            int actual = list[index];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0, 1)]
        [TestCase(0, -1)]
        [TestCase(0, 0)]
        public void Insert_InsertValueAtIndexToOneElementList_ElementByIndexEqualsValue_Test(int index, int expected)
        {
            ArrayList list = new ArrayList(5);
            list.InsertAt(index, expected);
            int actual = list[index];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0, 1)]
        [TestCase(1, -1)]
        [TestCase(2, 0)]
        public void Insert_InsertValueAtIndexToListOfSeveralElements_ElementByIndexEqualsValue_Test(int index, int expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            list.InsertAt(index, expected);
            int actual = list[index];

            Assert.That(actual, Is.EqualTo(expected));
        }

        // негативные
        // индекс вне диапазона
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void Insert_InsertValueAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void Insert_InsertValueAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void Insert_InsertValueAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        // вставка массива по индексу
        // позитивные (индекс в диапазоне и массив is NOT null)
        [Test]
        public void Insert_InsertArrayAtIndexToEmptyList_ArrayAdded_Test()
        {
            ArrayList actual = new ArrayList();
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Insert_InsertArrayAtIndexToOneElementList_ArrayAdded_Test()
        {
            ArrayList actual = new ArrayList(5);
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 5 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Insert_InsertArrayAtIndexToListOfSeveralElements_ArrayAddedToIndex_Test(int index)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.InsertAt(index, new int[] { 5, 6, 7 });
            ArrayList expected = new ArrayList(ArrayMock.GetMockExpectedForInsertAt(index));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // негативные
        // индекс ВНЕ диапазона, НО массив is NOT null, тесты на IndexOutOfRangeException
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void Insert_InsertArrayAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void Insert_InsertArrayAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void Insert_InsertArrayAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
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
        public void Insert_InsertNullArrayToOneElementList_ThrowNullReferenceException_Test()
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        [Test]
        public void Insert_InsertNullArrayToListOfSeveralElements_ThrowNullReferenceException_Test()
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
        public void Insert_InsertNullArrayAtIndexOutOfRangeToEmptyList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = null;

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void Insert_InsertNullArrayAtIndexOutOfRangeToOneElementList_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null; 

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void Insert_InsertNullArrayAtIndexOutOfRangeToListOfSeveralElements_ThrowIndexOutOfRangeException_Test(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        // Удаление из конца одного элемента --------------------------------------------------------------------------------
        // прямой, позитивный
        [TestCase(0, true)]
        [TestCase(1, true)]
        public void Remove_RemovesOneElementFromNotEmptyList_ReturnsTrue_Test(int mockParametr, bool expected)
        {
            ArrayList list = new ArrayList(ArrayMock.GetMockParametrForRemove(mockParametr));
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // прямой, негативный
        [TestCase(false)]
        public void Remove_RemovesOneElementFromNotEmptyList_ReturnsTrue_Test(bool expected)
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
    }

    public static class ArrayMock
    {
        public static int[] GetMockExpectedForInsertAt(int number) 
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
    }
}