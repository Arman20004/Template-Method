Console.WriteLine("Initial array");
int[] array = { 39, 39, 28, 58, 13, 52, 33, 7, 76, 91, 48, 21, 19, 18, 9, 12, 14, 90, 82 };
foreach (int item in array)
{
    Console.Write($"{item} ");
}
//----------------------------------
Strategy context = new BubbleSort();
context.Sort(array);
context.PrintArray(array);
//----------------------------------
context = new SelectionSort();
context.Sort(array);
context.PrintArray(array);
//----------------------------------
context = new InsertionSort();
context.Sort(array);
context.PrintArray(array);

abstract class Strategy
{

    public abstract void Sort(int[] array);

    public void PrintArray(int[] array)

    {
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();

    }
}
class BubbleSort : Strategy
{
    public override void Sort(int[] array)

    {
        Console.WriteLine("\n\nBubbleSort");
        for
       (int i = 0; i < array.Length; i++)

        {
            for
           (int j = array.Length - 1; j > i; j--)

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
class SelectionSort : Strategy
{
    public override void Sort(int[] array)

    {
        Console.WriteLine("\nSelectionSort");
        for (int i = 0; i < array.Length - 1; i++)
        {
            int k = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[k] > array[j])
                    k = j;
            if (k != i)
            {
                int temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }
        }
    }
}
class InsertionSort : Strategy
{
    public override void Sort(int[] array)
    {
        Console.WriteLine("\nInsertionSort");
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
