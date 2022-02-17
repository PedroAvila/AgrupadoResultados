using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentClass sc = new StudentClass();
            //sc.QueryHighScores(1, 90);
            //sc.GroupBySingleProperty();
            //sc.GroupByTitle();
            //sc.GroupBySubstring();
            //sc.GroupByRange();
            //sc.AgruparMasDeUnCampo();
            //sc.AgregarFrutas();

            string[] presidents = {
                                     "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                                     "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                                     "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                                     "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                                     "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                                     "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            var sequence = presidents.Where(p => p.StartsWith("J"));
            foreach (var s in sequence)
                Console.WriteLine($"{s}");

            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate suma de números");
            Console.WriteLine(" ");

            IEnumerable<int> ints = new List<int> { 2, 4, 1, 6 };
            int result = ints.Aggregate((sum, val)=> sum + val);
            Console.WriteLine($"La suma es: {result}");

            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate Concat");
            Console.WriteLine(" ");

            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z" };
            string result2 = strings.Aggregate((concat, str) => $"{concat}&{str}");
            Console.WriteLine(result2);

            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate");
            Console.WriteLine(" ");

            IEnumerable<string> strings3 = new List<string> { "a", "ab", "abc", "abcd" };
            int result3 = strings3.Aggregate(0, (count, val) => count + 1);
            Console.WriteLine(result3);



            Console.WriteLine("presiona cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
