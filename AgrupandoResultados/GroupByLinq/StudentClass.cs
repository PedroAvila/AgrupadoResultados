﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByLinq
{
    public class StudentClass
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();

        #region data
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }

        protected static List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
                Year = GradeLevel.SecondYear,
                ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
                Year = GradeLevel.ThirdYear,
                ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
                Year = GradeLevel.FirstYear,
                ExamScores = new List<int>{ 94, 92, 91, 91}},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
                Year = GradeLevel.FourthYear,
                ExamScores = new List<int>{ 96, 85, 91, 60}}
        };
        #endregion

        //Helper method, used in GroupByRange.
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name,-15}{item.Score}");
            }
        }

        public void GroupBySingleProperty()
        {
            Console.WriteLine("Agrupar por una sola propiedad en un objeto:");
            var queryLastNames =
                from student in students
                group student by student.LastName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        public void GroupByTitle()
        {
            Console.WriteLine("Agrupar por una sola propiedad en un objeto:");
            Console.WriteLine("=============================================");
            var listEmployee = _employeeRepository.ListEmployees().ToList();
            var query =
                from e in listEmployee
                group e by e.Title into g
                orderby g.Key
                select g;

            foreach (var nameGroup in query)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var e in nameGroup)
                {
                    Console.WriteLine($"\t{e.LastName}, {e.FirstName}");
                }
            }
        }

        public void GroupBySubstring()
        {
            Console.WriteLine("\r\nGroup by Algo que no sea una propiedad del objeto:");
            Console.WriteLine("=============================================");
            var listEmployee = _employeeRepository.ListEmployees().ToList();
            var query =
                from e in listEmployee
                group e by e.LastName[0];

            foreach (var employeeGroup in query)
            {
                Console.WriteLine($"Key: {employeeGroup.Key}");
                foreach (var e in employeeGroup)
                {
                    Console.WriteLine($"\t{e.LastName}, {e.FirstName}");
                }
            }
        }

        public void GroupByRange()
        {
            Console.WriteLine("\r\nAgrupe por rango numérico y proyecte en un nuevo tipo anónimo:");

            var queryNumericRange =
                from student in students
                let percentile = GetPercentile(student)
                group new { student.FirstName, student.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            //Se requiere foreach anidado para iterar sobre grupos y elementos de grupo.
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 18}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }
        }

        public void AgruparMasDeUnCampo()
        {
            using (var context = new NorthwindContext())
            {
                var result = from o in context.Orders
                             join c in context.Customers on o.CustomerID equals c.CustomerID
                             group o by new { o.CustomerID, c.ContactName } into grupo
                             select grupo;
                foreach (var grupo in result)
                {
                    Console.WriteLine($"Nombre Cliente: {grupo.Key.ContactName} ID: {grupo.Key.CustomerID}");
                    foreach (var oAgrupado in grupo)
                    {
                        Console.WriteLine($"\tPedido Nº {oAgrupado.OrderID} {oAgrupado.OrderDate} {Environment.NewLine}");
                    }
                }
            }
        }

        public void AgregarFrutas()
        {
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };
            // Determina si alguna cadena de la matriz es más larga que "plátano".
            string longestName =
                fruits.Aggregate("banana", (longest, next) => next.Length > longest.Length ? next : longest, fruit => fruit.ToUpper());
            Console.WriteLine($"La fruta con el nombre más largo es: {longestName}");
        }
    }
}
