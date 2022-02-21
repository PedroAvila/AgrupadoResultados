using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByLinq
{
    public class SdWhere
    {
        string[] presidents = {
                                     "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                                     "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                                     "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                                     "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                                     "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                                     "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        public void WhereStarsWith()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Obtener de una lista elementos que al principio comiencen con J");
            Console.WriteLine(" ");

            var sequence = presidents.Where(p => p.StartsWith("J"));
                foreach (var s in sequence)
                    Console.WriteLine($"{s}");
        }

        public void WhereP()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Los que tienen un indice impar, son cedidos a la secuencia");
            Console.WriteLine(" ");

            var sequence = presidents.Where((p, i) => (i & 1) == 1);
            foreach(string s in sequence)
                Console.WriteLine(s);
        }

    }
}
