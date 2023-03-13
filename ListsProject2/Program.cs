
using ListsProject2;

int[] ints = new int[] { 0 ,0, 0 };
int[] ints2 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
int[] ints3 = new int[] { 9, 1, 7, 11, 5, 20, 3, -1, -100 };

ArrayList list = new ArrayList(ints3);

list = list.UpSortQuick();
Console.WriteLine(list + $"\n");
ints3 = QuickUpSort(ints3);
PrintArray(ints3);


void InsertionUpSort(int[] array)
{
    int tmp;

    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (array[i] < array[j])
            {
                tmp = array[i];

                for (int k = i; k > j; k--)
                {
                    array[k] = array[k - 1];
                }

                array[j] = tmp;
                break;
            }
        }
    }
}

void InsertionUpSort2(int[] array)
{
    int tmp;    

    for (int i = 1; i < array.Length; i++)
    {
        int j = i - 1; 
        tmp = array[i];

        while (j >= 0 && array[j] > tmp)
        {
            array[j + 1] = array[j];
            array[j] = tmp;
            j--;
        }
    }
}

int[] QuickUpSort(int[] array)
{

    if (array.Length == 1)
    {
        return array;
    }
    else
    {
        int[] left = new int[0];
        int[] right = new int[0];
        //int p = array[0];
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

        left = QuickUpSort(left);
        right = QuickUpSort(right);

        return left.Concat(right).ToArray();
    }
}


//4 9 7 6 3 4 0
//4 7 9 6 3 4 0



void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }

    Console.WriteLine();
}

