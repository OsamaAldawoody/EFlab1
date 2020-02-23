using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 2, 4, 6, 7 , 1 ,4 , 2 ,9 ,1 };
            var query1 = numbers.Distinct()
                .OrderBy(num => num)
                .Select(num => new { number = num,multiply = num*num});
            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            string[] arr = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            var query2 = arr.Where(str => str.Length == 3).Select(str => new {name= str.ToUpper() });
                
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }


            NORTHWNDEntities nw = new NORTHWNDEntities();



            //var query3 = nw.Customers.Select(s => s.CustomerID);
            //foreach (var item in query3)
            //{
            //    Console.WriteLine(item);
            //}

            //var query4 = nw.Orders.Select(o => new { o.OrderID, o.OrderDate, o.CustomerID });
            //foreach (var item in query4)
            //{
            //    Console.WriteLine(item);
            //}

            //___________add order____________ 


            //var query5 = nw.Orders.Select(o => new { o.EmployeeID, o.CustomerID }).OrderBy(c => c.CustomerID);
            //foreach (var item in query5)
            //{
            //    Console.WriteLine(item);
            //}
            //Order order = new Order();
            //order.CustomerID = "ANTON";
            //order.EmployeeID = 3;
            //nw.Orders.Add(order);


            //___________display order____________


            //var order1 = nw.Products.Single(p => p.ProductID == 10).Order_Details.Select(o => new { o.UnitPrice, o.Quantity });
            //foreach (var item in order1)
            //{
            //    Console.WriteLine(item);
            //}


            //___________remove order____________


            //var deletedOrder = nw.Orders.Single(o => o.OrderID == 10249);
            //var deletedDetails = deletedOrder.Order_Details;
            //nw.Order_Details.RemoveRange(deletedDetails);
            //nw.Orders.Remove(deletedOrder);
            //var query9 = nw.Orders.Select(o => o.OrderID);
            //foreach (var item in query9)
            //{
            //    Console.WriteLine(item);
            //}


            //_____________ display nancy davolio supervisor__________

            Employee nancyquery = nw.Employees.Single(e=>e.FirstName == "Nancy"&& e.LastName=="Davolio");
            Console.WriteLine(nancyquery.Employee1.FirstName + " "+ nancyquery.Employee1.LastName);


            // ______________update nancy title _____________
            Console.WriteLine(nw.Employees.Single(e => e.EmployeeID == 1).Title);
            nw.Employees.Single(e => e.EmployeeID == 1).Title = "Hr Manager";
            
            nw.SaveChanges();

            Console.WriteLine(nw.Employees.Single(e => e.EmployeeID == 1).Title);


            //______________display all territories for nancy____________________ 
            var territories = nw.Employees.Where(e => e.FirstName == "Nancy" && e.LastName == "Davolio")
                .Select(t => new { t.Address, t.City, t.Country, t.PostalCode });

            foreach (var item in territories)
            {
                Console.WriteLine(item);
            }


            //Console.WriteLine("*************************************************");
            //foreach (var item in query9)
            //{
            //    Console.WriteLine(item);
            //}

            //var query9 = nw.Orders.Select(o => o.OrderID);
            //foreach (var item in query9)
            //{
            //    Console.WriteLine(item);
            //}

            //var query6 = nw.Orders.Select(o => new { o.EmployeeID, o.CustomerID }).OrderBy(c => c.CustomerID);
            //foreach (var item in query6)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();
        }
        
    }
}
