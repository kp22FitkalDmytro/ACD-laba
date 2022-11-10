using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class lab2
    {
        public static float x;
        public static float a;
        public static float b;
        public static float y;
        public static float temp;
        public static string console_temp;
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть y");
            console_temp = Console.ReadLine();
            float.TryParse(console_temp, out y);
            Console.WriteLine("");
            Console.WriteLine("Введiть x");
            console_temp = Console.ReadLine();
            float.TryParse(console_temp, out x);
            temp = (float)Math.Cos(y);
            temp = (float)Math.Sin(x) - temp;
            temp = (float)Math.Abs(temp);
            temp = (float)(Math.Pow(temp, (float)1 / 3));
            a = temp;
            Console.WriteLine("a = " + a.ToString());
            temp = a * a;
            temp = (float)Math.Sin(temp);
            temp = (float)Math.Cos(temp);
            b = temp;
            Console.WriteLine("b = "+ b.ToString());
        }
    }
}
