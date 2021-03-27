using System;
using System.Linq;

namespace ConsoleApplication
{
    class operation
    {
        public int[] DoReverse(int[] array) => array.Reverse().ToArray();
        public string[] FormatByInc(string[] array) => array.OrderBy(t => t.Length).ToArray();
        public int[] SumAndCount(int[] arrays)
        {
            int[] arr = new int[0];
            if (arrays.Length !=0 )
            {
                if(arrays.Any(x => x > 0 || x < 0))
                {
                    Array.Resize(ref arr, 2);
                    arr[0] = arrays.Where(x => x > 0).Count();
                    arr[1] = arrays.Where(x => x < 0).Sum();
                }
            }
            return arr;
        }
        public int GetUniqNumber(int[] array)
        {
            var a = array.GroupBy(g => g).Where(g => g.Count() < 2).Select(g => g.Key).ToArray();
            return a[0];
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            string[] devices = { "Telescopes", "Glasses", "Eyes", "Monocles" };
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 };
            int[] dig = { 1, 1, 1, 1, 2, 1, 1 };
            
            //Обратный
            operation manipulation = new operation();
            int[] newArray = manipulation.DoReverse(numbers);
            foreach (var item in newArray) Console.Write($"{item} ");

            //Форматирование увеличением
            Console.WriteLine();
            string[] newArraySort = manipulation.FormatByInc(devices);
            foreach (var item in newArraySort) Console.Write($"{item} ");

            //Суммировать и подсчитывать числа в массиве
            Console.Write("\n[ ");
            foreach (var item in manipulation.SumAndCount(digits)) Console.Write(item + " ");
            Console.WriteLine("]");

            //Получить уникальный номер в диапазоне массива
            var numeric = manipulation.GetUniqNumber(dig);
            Console.WriteLine($"Unique: {numeric}");
        }
    }
}