using System.Collections.Generic;
using System.Linq;

namespace GroupByLinq
{
    public class EmployeeRepository
    {
        public IEnumerable<Employee> ListEmployees()
        {
            using (var context = new NorthwindContext())
            {
                var result = from e in context.Employees
                                 //             group e by e.Title into g
                                 //             orderby g.Key
                                 //             select g;
                                 //return result.ToString();
                             select e;
                return result.ToList();
            }
        }


    }
}
