using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByLinq
{
    class Program
    {
        private static readonly SdAggregate _sdAggregate = new SdAggregate();
        private static readonly SdWhere _sdWhere = new SdWhere();
        private static readonly SdSelect _sdSelect = new SdSelect();
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
            //_sdAggregate.AggregateSumaDeNumeros();
            //_sdAggregate.AggregateConcat();
            //_sdAggregate.AggregateCount();
            //_sdWhere.WhereStarsWith();
            //_sdWhere.WhereP();
            _sdSelect.SelectLength();
            _sdSelect.SelectNombreTamano();
            

            



            Console.WriteLine("presiona cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
