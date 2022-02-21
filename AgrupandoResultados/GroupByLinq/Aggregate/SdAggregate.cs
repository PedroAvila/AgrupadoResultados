using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByLinq
{
    public class SdAggregate
    {
        public void AggregateSumaDeNumeros()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate suma de números");
            Console.WriteLine(" ");

            IEnumerable<int> ints = new List<int> { 2, 4, 1, 6 };
            int result = ints.Aggregate((sum, val) => sum + val);
            Console.WriteLine($"La suma es: {result}");
        }

        public void AggregateConcat()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate Concat");
            Console.WriteLine(" ");

            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z" };
            string result2 = strings.Aggregate((concat, str) => $"{concat}&{str}");
            Console.WriteLine(result2);
        }

        public void AggregateCount()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Aggregate Count");
            Console.WriteLine(" ");

            IEnumerable<string> strings3 = new List<string> { "a", "ab", "abc", "abcd" };
            int result3 = strings3.Aggregate(0, (count, val) => count + 1);
            Console.WriteLine(result3);
        }


    }
}
