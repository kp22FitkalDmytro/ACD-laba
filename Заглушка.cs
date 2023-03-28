using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("������ ������ ������� ");
            int a = Convert.ToInt32(Console.ReadLine());


            Console.Write("������ ������ ������� ");
            int b = Convert.ToInt32(Console.ReadLine());



            Console.Write("����� ����������� ����� ������� ");
            int maxElementOfArray = Convert.ToInt32(Console.ReadLine());
            int[,] array = GenerateMatrix(a, b, maxElementOfArray);


            Console.Write("������ K ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.Write("������ L ");
            int l = Convert.ToInt32(Console.ReadLine());

            bool[,] colors = GetColors(array, a, b, k, l);


            Console.WriteLine("\n�������������� ������� \n");
            DisplayMatrix(array, colors, a, b);
            array = GetSortedMatrix(array, colors, a, b);
            Console.WriteLine("\n������������ �������: \n");
            DisplayMatrix(array, colors, a, b);

            Console.WriteLine("\n������ ���������� ��� �� ͳ");
            string answer = Convert.ToString(Console.ReadLine());
            if (answer == "���" || answer == "���")
            {
                Console.WriteLine("\n");
                continue;
            }
            break;
        }
    }