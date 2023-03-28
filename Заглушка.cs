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