using System;
using System.Collections.Generic;

namespace MyLib
{


    class Program
    {
        public static List<char> user_input;  // необхідно створювати вручну
        public static List<char> user_input_with_square;  // необхідно створювати вручну

        public static bool is_poly=true;
        public static int symbol_count;
        public static bool is_count_has_pair;

        static void IsPoly() 
        {   //взнаєм чи кількість символів парна.

            symbol_count = user_input.Count;//Оновлюємо кількість символів 
            is_count_has_pair = (symbol_count % 2 == 0); // результат тру або фолс

            if (is_count_has_pair)
            {
                while (symbol_count > 0) 
                {
                    if (user_input[0] == user_input[symbol_count - 1])
                    {
                        Console.WriteLine("Крайнi цифри одинаковi, можливо - полiндром.");
                        user_input.RemoveAt(symbol_count - 1);//видаляэмо кінцевий символ
                        user_input.RemoveAt(0);//видаляэмо початковий символ
                        symbol_count = user_input.Count;// оновлюємо кількість символів

                        foreach (var single_char in user_input) 
                        {
                            Console.Write(single_char);
                        }
                        Console.Write(Environment.NewLine);
                    }
                    else 
                    {
                        Console.WriteLine("Перша i остання цифри не однаковi. Число не полiндром!");
                        is_poly = false;
                        break;
                    }
                }
            }
            else  // якщо кількість символів НЕ парна
            {
                while (symbol_count > 1)
                {
                    if (user_input[0] == user_input[symbol_count - 1])
                    {
                        Console.WriteLine("Крайнi цифри одинаковi, можливо - полiндром.");
                        user_input.RemoveAt(symbol_count - 1);//видаляэмо кінцевий символ
                        user_input.RemoveAt(0);//видаляэмо початковий символ
                        symbol_count = user_input.Count;// оновлюємо кількість символів
                        foreach (var single_char in user_input)
                        {
                            Console.Write(single_char);
                        }
                        Console.Write(Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine("Перша i остання цифри не однаковi. Число не полiндром!");
                        is_poly = false;
                        break;
                    }
                }
            }

            if (is_poly) { Console.WriteLine("Число - полiндром"); }else { Console.WriteLine("Число - НЕ поліндром"); }

        }
      
        
        
        
        
        static void Main(string[] args)
        {

            
            user_input = new List<char>(); // створюємо новий список з символів
            user_input_with_square = new List<char>();
            string user_temp_input = Console.ReadLine(); // звчитуємо символи з клавіатури
          
           //Переводимо символи число і берем його до квадрата  
            int temp_sq;
            int.TryParse(user_temp_input, out temp_sq);
            temp_sq = temp_sq * temp_sq;
            Console.WriteLine("Квадрат введеного числа це:" + temp_sq.ToString());
            string square_value = temp_sq.ToString();

            foreach (var single_char in square_value) 
            {
                user_input_with_square.Add(single_char);
            }
            foreach (var single_symbol in user_temp_input)
            {
                user_input.Add(single_symbol);// поштучно переносимо символи в список з символами
            }
             //Взнаєм кількість символів
            symbol_count = user_input.Count;
            IsPoly(); //взнаэм чи поліндром основне число
            user_input = user_input_with_square;
            IsPoly(); //взнаэм чи поліндром квадрат основного числа









        }
    }
}
