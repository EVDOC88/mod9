using System;
using System.Runtime.Serialization;

namespace mod9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exeption = new Exception[] { new ArgumentException(), new DivideByZeroException(), new MyExeptinon("Мое исключение - ВОТ"), new IndexOutOfRangeException(), new RankException(), new FormatException() };
            NumberReader numberReader = new NumberReader();
            numberReader.NumSortEvent += Sort;

            foreach (var exep in exeption)
            { try
                {
                    numberReader.Read();
                    //throw exep;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ИКЛЮЧЕНИЕ {ex.Message} ");

                }
            }

        }

        [Serializable]
        internal class MyExeptinon : Exception
        {
            public MyExeptinon()
            {
            }

            public MyExeptinon(string? message) : base(message)
            {
            }

            public MyExeptinon(string? message, Exception? innerException) : base(message, innerException)
            {
            }

            protected MyExeptinon(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
        public static void Sort(int sortnum, List<string> list)
        {
        
            switch (sortnum)
            {
                case 1:
                    {
                        list.Sort();
                        Console.WriteLine("\n Отсортированный список от А-Я:");
                        foreach (var spisok in list)
                        {
                            Console.WriteLine(spisok);
                        }

                    }
                    break;
                case 2:
                    {
                        list.Sort();
                        list.Reverse();
                        Console.WriteLine("\n Отсортированный список от Я-А:");
                        foreach (var spisok in list)
                        {
                            Console.WriteLine(spisok);
                        }

                    }
                    break;

            }

        }
        class NumberReader
        {
            public delegate void NumberSort(int num, List<string> list);
            public event NumberSort NumSortEvent;
           public void Read()
            {
                List<string> list = new List<string> { "Лера", "Вова", "Женя", "Егор", "Равиль" };
                Console.WriteLine("Есть список: \n");
                foreach (var spisok in list)
                {
                    Console.WriteLine(spisok);
                }

                Console.WriteLine(" \n Для сортировки списка введите 1, если отортировать от А-Я, или 2 для сортировки от Я-А:");
                int sort = Convert.ToInt32(Console.ReadLine());
                if (sort != 1 && sort != 2) throw new FormatException("Введено неверное число");
                SortEnter(sort,list);

            }


            protected virtual void SortEnter(int sort, List<string> list)
            {
                NumSortEvent?.Invoke(sort, list);
            }

        }

    }
}