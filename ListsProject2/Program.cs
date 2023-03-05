using ListsProject2;

int[] ints= new int[10] { 5, 1, 1, 4, 1, 1, 3, 6, 1, 5 };

ArrayList one = new ArrayList(ints);
Console.WriteLine(one.RemoveAllByValueSECOND(1));

for (int i = 0; i < one.Length; i++)
{
    Console.Write($"{one.GetValueByIndex(i)} ");
}

Console.WriteLine();

//Console.WriteLine(one.RemoveOneByValue(1));
//Console.WriteLine(one.Length);

//for (int i = 0; i < one.Length; i++)
//{
//    Console.Write($"{one[i]} ");
//}

//5, 1, 2, 3, 1, 1, 3, 1, 4

//arrayOfIndexes = { 1, 4, 5, 7 }

int d = 0;

