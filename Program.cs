using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введіть висоту матриці ");
            int a = Convert.ToInt32(Console.ReadLine());


            Console.Write("Введіть ширину матриці ");
            int b = Convert.ToInt32(Console.ReadLine());



            Console.Write("Ведіть максимальне число матриці ");
            int maxElementOfArray = Convert.ToInt32(Console.ReadLine());
            int[,] array = GenerateMatrix(a, b, maxElementOfArray);


            Console.Write("Введіть K ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть L ");
            int l = Convert.ToInt32(Console.ReadLine());

            bool[,] colors = GetColors(array, a, b, k, l);


            Console.WriteLine("\nНепросортована матриця \n");
            DisplayMatrix(array, colors, a, b);
            array = GetSortedMatrix(array, colors, a, b);
            Console.WriteLine("\nПросортована матриця: \n");
            DisplayMatrix(array, colors, a, b);

            Console.WriteLine("\nХочете продовжити Так чи Ні");
            string answer = Convert.ToString(Console.ReadLine());
            if (answer == "Так" || answer == "так")
            {
                Console.WriteLine("\n");
                continue;
            }
            break;
        }
    }
    static int[,] GenerateMatrix(int a, int b, int max)
    {
        int[,] array = new int[a, b];
        Random rnd = new Random();
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                array[i, j] = rnd.Next(max);
            }
        }
        return array;
    }
    static bool[,] GetColors(int[,] array, int a, int b, int k, int l)
    {
        bool[,] colors = new bool[a, b];
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (array[i, j] / k < l)
                {
                    colors[i, j] = true;
                }
            }
        }
        return colors;
    }
    static void DisplayMatrix(int[,] array, bool[,] colors, int a, int b)
    {
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (colors[i, j]) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(array[i, j] + "\t");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    }
    static int[,] GetSortedMatrix(int[,] array, bool[,] colors, int a, int b)
    {
        int[] arr = new int[a * b];
        int index = 0;
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (colors[i, j])
                {
                    arr[index++] = array[i, j];
                }
            }
        }
        CombSort(arr, index);
        index = 0;
        for (int i = 0; i < a; i++)
        {
            for (int j = b - 1; j >= 0; j--)
            {
                if (colors[i, j])
                {
                    array[i, j] = arr[index++];
                }
            }
        }
        return array;
    }
    static void CombSort(int[] arr, int a)
    {
        int gap = a;
        bool swapped = true;
        while (gap > 1 || swapped)
        {
            swapped = false;
            gap = GetNextStep(gap);
            if (gap <= 1) gap = 1;
            for (int i = 0; i < a - gap; i++)
            {
                if (arr[i] > arr[i + gap])
                {
                    Swap(ref arr[i], ref arr[i + gap]);
                    swapped = true;
                }
            }
        }
    }
    static void Swap(ref int value1, ref int value2)
    {
        int temp = value1;
        value1 = value2;
        value2 = temp;
    }
    static int GetNextStep(int o)
    {
        o = o * 1000 / 1247;
        return o > 1 ? o : 1;
    }
}
