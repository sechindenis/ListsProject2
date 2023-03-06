namespace ListsProject2.Tests
{
    public class ArrayListTest
    {
        // Три теста конструкторов
        [TestCase(0)]
        public void ArrayListFirstConstructorTest(int expected)
        {
            ArrayList arrayList = new ArrayList();
            int actual = arrayList.Length;
            
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(1, 0)]
        public void ArrayListSecondConstructorTest(int expectedLength, int expectedValue)
        {
            ArrayList arrayList = new ArrayList(expectedValue);
            int actualLength = arrayList.Length;
            int actualValue = arrayList[0];

            Assert.That(actualLength, Is.EqualTo(expectedLength));
            Assert.That(actualValue,  Is.EqualTo(expectedValue));
        }

        [Test]
        public void ArrayListThirdConstructorTest()
        {
            int[] ints = new int[] { 1, 2, 3 };
            ArrayList actualArray = new ArrayList(ints);
            ArrayList expectedArray = new ArrayList(new int[] { 1, 2, 3 });
            int expectedLength = ints.Length;
            int actualLength   = actualArray.Length;

            Assert.That(actualArray,  Is.EqualTo(expectedArray));
            Assert.That(actualLength, Is.EqualTo(expectedLength));
        }

        // Три теста метода Add
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void AddTest(int value)
        {
            ArrayList actualArray = new ArrayList(new int[] { 1, 2, 3 });
            actualArray.Add(value);
            ArrayList expectedArray = new ArrayList(new int[] { 1, 2, 3, value });

            Assert.That(actualArray, Is.EqualTo(expectedArray));
        }

        [Test]
        public void AddFIRSTTest()
        {
            ArrayList actualArray = new ArrayList(new int[] { 1, 2, 3 });
            actualArray.AddFIRST(new int[] {4, 5, 6});
            ArrayList expectedArray = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.That(actualArray, Is.EqualTo(expectedArray));
        }

        [Test]
        public void AddSECONDTest()
        {
            ArrayList actualArray = new ArrayList(new int[] { 1, 2, 3 });
            actualArray.AddSECOND(new int[] { 4, 5, 6 });
            ArrayList expectedArray = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.That(actualArray, Is.EqualTo(expectedArray));
        }

        // Добавление значения в начало
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void AddToBeginingTest(int value)
        {
            ArrayList arrayEmpty = new ArrayList();
            arrayEmpty.AddToBegining(value);

            Assert.That(arrayEmpty[0], Is.EqualTo(value));

            //
            ArrayList arrayOneElement = new ArrayList(5);
            arrayOneElement.AddToBegining(value);

            Assert.That(arrayOneElement[0], Is.EqualTo(value));

            //
            ArrayList arrayLong = new ArrayList(new int[] { 1, 2, 3 });
            arrayLong.AddToBegining(value);

            Assert.That(arrayLong[0], Is.EqualTo(value));
        }


    }
}