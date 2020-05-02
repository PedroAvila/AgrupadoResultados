using System;

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
            sc.GroupBySubstring();
            Console.WriteLine("presiona cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
