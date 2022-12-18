using System;
using System.Reflection;

namespace ACDlab2marix
{
    class Task
    {
        static void Main(string[] args)
        {


            int n = 0; 
            Console.WriteLine("Введіть число: ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
            } while (n % 2 == 0);
            int[,] matrix = new int[n, n]; 
            int[][] min = new int[1][]; 

            int[] matrixTraversalSequence = new int[n * n]; 
            Console.WriteLine("Введіть 1 щоб згенерквати випадкову матрицю, 2 щоб вписати свою або будь яке інше число щоб вийти:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    matrix = GeneratePRMatrix(n);
                    break;
                case 2:
                    matrix = GenerateCustomMatrix(n);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

           
            min = MatrixTraversal(matrix, ref min, ref matrixTraversalSequence);

           
            PrintMatrix(matrix);
            PrintSequence(matrixTraversalSequence);
            print(min, matrix);

        }

      
        static int[,] GeneratePRMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int max;
            Random rand = new Random();

           
            Console.WriteLine("Введіть максимальну кількість значень в матриці: ");
            do
            {
                max = Convert.ToInt32(Console.ReadLine());
            } while (max < 1);

            //згенеруємо матрицю

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(1, max);
                }
            }

            return matrix;
        }

        
        static int[,] GenerateCustomMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            string str;
            string[] splited;

         
            Console.WriteLine("введіть матрицю (розділіть числа пробілом):");
            for (int i = 0; i < n; i++)
            {
                do
                {
                    str = Console.ReadLine(); 
                    splited = str.Split(" "); 
                } while (splited.Length != n);

         
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(splited[j]);
                }
            }

            return matrix;
        }

        
        static int[][] MatrixTraversal(int[,] matrix, ref int[][] min, ref int[] matrixTraversalSequence)
        {
            int n = Convert.ToInt32(Math.Sqrt(matrix.Length));
            int x = (n - 1) / 2, y = (n - 1) / 2; 
            min[0] = new int[] { y, x }; 
            Array.Fill<int>(matrixTraversalSequence, -1); 

           
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                x += 1;
                for (int j = 0; j < 2 + 2 * i; j++)
                {
                    x -= 1;
                    min = minimal(min, matrix, new int[] { y, x }); 
                    Append(ref matrixTraversalSequence, matrix[y, x]); 
                }
                for (int j = 0; j < 1 + 2 * i; j++)
                {
                    y -= 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    Append(ref matrixTraversalSequence, matrix[y, x]);
                }

                for (int j = 0; j < 2 + 2 * i; j++)
                {
                    x += 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    Append(ref matrixTraversalSequence, matrix[y, x]);
                }

                for (int j = 0; j < 1 + 2 * i; j++)
                {
                    y += 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    Append(ref matrixTraversalSequence, matrix[y, x]);
                }
                y += 1;
            }
            for (int i = 0; i < n; i++)
            {
                min = minimal(min, matrix, new int[] { y, x });
                Append(ref matrixTraversalSequence, matrix[y, x]);
                x -= 1;
            }

            return min;
        }

        static int[][] minimal(int[][] min, int[,] matrix, int[] pos)
        {
            int n1 = matrix[min[0][0], min[0][1]];
            int n2 = matrix[pos[0], pos[1]];

            if (n1 > n2)
            {
                return new int[1][] { pos };
            }
            else if (n1 == n2)
            {
                int[][] tmp = new int[min.Length + 1][];
                for (int i = 0; i < min.Length; i++)
                {
                    tmp[i] = min[i];
                }
                tmp[tmp.Length - 1] = pos;

                return tmp;
            }
            else
            {
                return min;
            }
        }


        static void Append(ref int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                {
                    arr[i] = val;
                    break;
                }
            }
        }


        static void PrintMatrix(int[,] matrix)
        {
            int n = Convert.ToInt32(Math.Sqrt(matrix.Length)); 

            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }

       
        static void PrintSequence(int[] mts)
        {
            for (int i = 0; i < mts.Length; i++)
            {
                Console.Write(mts[i] + "  ");
            }
            Console.WriteLine("");
        }

        
        static void print(int[][] min, int[,] matrix)
        {
            for (int i = 0; i < min.Length; i++)
            {
                Console.Write(matrix[min[i][0], min[i][1]] + "[" + min[i][0] + "][" + min[i][1] + "] - ");
                if (min[i][0] > min[i][1])
                {
                    Console.Write("під діагоналлю\n");
                }
                else if (min[i][0] < min[i][1])
                {
                    Console.Write("над діагоналлю\n");
                }
                else
                {
                    Console.Write("на діагоналі\n");
                }
            }
        }
    }
}