using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Initial array");
        int[] array = { 39, 39, 28, 58, 13, 52, 33, 7, 76, 91, 48, 21, 19, 18, 9, 12, 14, 90, 82 };

        foreach (int item in array) { Console.Write(item + " "); }

        Console.WriteLine("\n");
        AbstractSort bubbleSort = new BubbleSort();
        bubbleSort.Sort(array);

        Console.WriteLine();
        AbstractSort selectionSort = new SelectionSort();
        selectionSort.Sort(array);

        Console.WriteLine();
        AbstractSort insertionSort = new InsertionSort();
        insertionSort.Sort(array);

        Console.ReadLine();
    }
}

abstract class AbstractSort
{
    public void Sort(int[] array)
    {
        Console.WriteLine(GetSortName());
        PerformSort(array);
        PrintArray(array);
    }

    protected abstract string GetSortName();
    protected abstract void PerformSort(int[] array);

    protected void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}

class BubbleSort : AbstractSort
{
    protected override string GetSortName()
    {
        return "BubbleSort";
    }

    protected override void PerformSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = array.Length - 1; j > i; j--)
            {
                if (array[j] < array[j - 1])
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
        }
    }
}

class SelectionSort : AbstractSort
{
    protected override string GetSortName()
    {
        return "SelectionSort";
    }

    protected override void PerformSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int k = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[k] > array[j]) { k = j; }

            if (k != i)
            {
                int temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }
        }
    }
}

class InsertionSort : AbstractSort
{
    protected override string GetSortName()
    {
        return "InsertionSort";
    }

    protected override void PerformSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int j = 0;
            int buffer = array[i];
            for (j = i - 1; j >= 0; j--)
            {
                if (array[j] < buffer) { break; }

                array[j + 1] = array[j];
            }
            array[j + 1] = buffer;
        }
    }
}