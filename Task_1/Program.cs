using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exception = new Exception[5];
            exception[0] = new OverflowException();
            exception[1] = new FormatException();
            exception[2] = new ArgumentException();
            exception[3] = new RankException();
            exception[4] = new MyException();

            for (int i = 0; i < exception.Length; i++)
            {
                try
                {
                    throw exception[i];
                }
                catch (Exception)
                {
                    Console.WriteLine(exception[i]);
                }
            }
            Console.ReadKey();
        }
    }
    public class MyException : Exception
    {
        public MyException()
        { }

        public MyException(string message)
            : base(message)
        { }
    }
}
