using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += SortingSurname;

            try
            {
                numberReader.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }

            Console.ReadKey();
        }

        static void SortingSurname(int number)
        {
            var surnameList = new List<string>();

            surnameList.Add("Петров");
            surnameList.Add("Янковский");
            surnameList.Add("Иванов");
            surnameList.Add("Агутин");
            surnameList.Add("Кононов");

            switch (number)
            {
                case 1:
                    surnameList.Sort();

                    foreach (var item in surnameList)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 2:
                    surnameList.Sort();
                    surnameList.Reverse();

                    foreach (var item in surnameList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите число 1 (сортировка А-Я), либо число 2 (сортировка Я-А)");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
