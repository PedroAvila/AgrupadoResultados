using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByLinq
{
    public class SdSelect
    {
        string[] presidents = {
                                     "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                                     "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                                     "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                                     "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                                     "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                                     "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        public void SelectLength()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Obtiene el tamaño de cada elemento de la colección");
            Console.WriteLine(" ");

            IEnumerable<int> nameLengths = presidents.Select(p => p.Length);
            foreach (int item in nameLengths)
                Console.WriteLine(item);
        }

        public void SelectNombreTamano()
        {
            Console.WriteLine(" ");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Obtiene el nombre y el tamaño");
            Console.WriteLine(" ");

            var nameObjs = presidents.Select(p => new { p, p.Length });
            foreach (var item in nameObjs)
                Console.WriteLine(item);
        }
    }
}
