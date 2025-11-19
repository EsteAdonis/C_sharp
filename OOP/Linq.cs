using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.Design;

namespace C_Sharp
{
	public class Employee(int id, string name, string color, decimal salary, int? managerId, int? departmentId)
	{
		public int Id => id;
		public string? Name => name;
		public string? Color => color;
		public decimal Salary => salary;
		public int? ManagerId => managerId;
		public int? DepartmentId => departmentId;
	}

	public class Depatment(int id, string name)
	{
		public int Id => id;
		public string? Name => name;
	}
	
	public class Movie(int id, string actress, string moviename)
	{
		public int Id => id;
		public string? Protagonist => actress;
		public string? MovieName => moviename;
	}

	public static class Linq
	{
		public static void LinqExamples()
		{
			var Departments = new List<Depatment>()
			{
				new (1, "Human Resorces"),
				new (2, "Accounting"),
				new (3, "Treasury"),
				new (4, "Customers"),
				new (5, "Contract"),
				new (6, "Claims")
			};

			var Employees = new List<Employee>()
			{
				new (1, "Eris", "Black", new Random().Next(10000, 100000), 6, 4 ),
				new (2, "Vanessa", "White", new Random().Next(10000, 100000), 6, 4),
				new (3, "Adonis", "blue", new Random().Next(10000, 100000), 6, null ),
				new (4, "Amy Adams", "Red", new Random().Next(10000, 100000), 6, 1 ),
				new (5, "Ferguson", "Beige", new Random().Next(10000, 100000), 6, null ),
				new (6, "Elizabeth Sue", "Purple", new Random().Next(10000, 100000), null, 5 ),
				new (7, "Tyde Ochoa", "Purple", new Random().Next(10000, 100000), 11, 5 ),
				new (8, "Hesíone", "Purple", new Random().Next(10000, 100000), 11, 3 ),
				new (9, "Atenea", "Purple", new Random().Next(10000, 100000),11, null ),
				new (10, "Hera", "Purple", new Random().Next(10000, 100000), 13, 1 ),
				new (11, "Afrodita", "Purple", new Random().Next(10000, 100000), null, 6),
				new (12, "Idalia", "Purple", new Random().Next(10000, 100000), 13, 2 ),
				new (13, "Minerva", "Purple", new Random().Next(10000, 100000), null, 4 ),
			};

			// Exercise: Find Manager's Name
			var Managers = (from manager in Employees
											join employee in Employees
											on manager.ManagerId equals employee.Id
											select employee.Name).Distinct();

			foreach (var manager in Managers)
			{
				Console.WriteLine(manager);
			}
			Console.WriteLine("\n\n\n");

			// The same question but using join extension
			var mgrs = Employees.Join(Employees,
																emp => emp.ManagerId,
																mgr => mgr.Id,
																(emp, mgr) => new { ManagerName = mgr.Name })
																.Distinct();
			foreach (var mgr in mgrs)
			{
				Console.WriteLine(mgr.ManagerName);
			}

			// Get Employees with their respective department
			var EmployeeWithDeparment = from e in Employees
																	join d in Departments
																	on e.DepartmentId equals d.Id
																	orderby d.Name
																	select (new { EmployeeName = e.Name, Department = d.Name });

			foreach (var empDep in EmployeeWithDeparment)
			{
				Console.WriteLine($"Employee - Deparment = {empDep.EmployeeName} - {empDep.Department}");
			}

			// The same question but using join
			var employeDepartment = Employees.Join( Departments,
																							e => e.DepartmentId,
																							d => d.Id,
																							(e, d) => new { EmployeeName = e.Name, Department = d.Name })
																							.OrderBy(d => d.Department)
																							.ToList();
			foreach (var ed in employeDepartment)
			{
				Console.WriteLine($"Employee-Department {ed.EmployeeName} - {ed.Department}");
			}

			// LEFT OUTER JOIN
			var leftQuery = from e in Employees
											join d in Departments
											on e.DepartmentId equals d.Id into gj    // creating a Group Join
											from subgroup in gj.DefaultIfEmpty()
											select new { e.Name, Department = subgroup?.Name ?? string.Empty };

			foreach (var leftJoin in leftQuery)
			{
				Console.WriteLine($"Left Outer Join {leftJoin.Name} - {leftJoin.Department}");
			}

			// The equivalent query using method syntax is shown in the following code:

			var EmpLeftJoinDeparments =
						Employees.GroupJoin(Departments, e => e.DepartmentId, d => d.Id, (e, deparmentList) => new { e.Name, subgroup = deparmentList })
						.SelectMany(joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
												(e, d) => new { e.Name, Department = d?.Name ?? string.Empty }
						);
			
			foreach(var elfd  in EmpLeftJoinDeparments)
			{
				Console.WriteLine($"{elfd.Name} - {elfd.Department}");
			}

			// Find: if not element match, it return null (default for reference type)
			// First: If no match is found, it throws an exception (InvalidOperationException).
			// FirstOrDefault, which returns null for reference types or the default value for value types instead of throwing an exception.

			var query = from b in Employees.Distinct()
									select b.Name;

			// LINQ Query Operators
			var res = from b in Employees
								where b.Color == "Purple"
								orderby b.Name
								select b;

			var res1 = from b in Employees
								 orderby b.Color descending
								 select b.Color;

      // LINQ Extension Methods.
      var res2 = Employees.Where(b => b.Color == "Purple").OrderBy(b => b.Name).Select(b => b.Name);
      // Where Clause
      var whereResult = Employees.Where(x => x.Color == "blue").First();

      Console.WriteLine("itemList.Where(x => x.Color == 'blue').First() => " +  whereResult.Name);
			Console.WriteLine("---------------------");


			// Order BY Clause
			var resu = from i in Employees
								 orderby i.Color, i.Name
								 select (i.Name, i.Color);
								 
      var result = Employees.OrderBy(i => i.Name).ToList();
      var resultResultDecending = Employees.OrderByDescending(x => x.Id).ToList();      

      foreach(var item in result) {
        Console.WriteLine(item.Name + " " + item.Color);
      }

			// IEnumerable<(string, string)> queryTeachers = teachers
			// 			.OrderBy(teacher => teacher.City)
			// 			.ThenBy(teacher => teacher.Last)
			// 			.Select(teacher => (teacher.Last, teacher.City));

			// foreach ((string last, string city) in queryTeachers)
			// {
			// 		Console.WriteLine($"City: {city}, Last Name: {last}");
			// }



			// Group By Clause
			var groupByResult = Employees.GroupBy(x => x.Color);
      Console.WriteLine("Group By Clause");
      foreach (var y in groupByResult)
      {
          Console.WriteLine(y.Key);
          foreach (var item in y)
          {
              Console.WriteLine(item.Name);
          }
      }
      Console.WriteLine("---------------------");      

			// Group By with Select
      var groupedItems = Employees.GroupBy(x => x.Color) 
                                  .Select(g => new { Key = g.Key, Items = g.ToList() })
                                  .ToList();    
	    foreach (var group in groupedItems)
      {
        Console.WriteLine($"Color: {group.Key}");
        foreach (var item in group.Items)
        {
          Console.WriteLine($" - {item.Name}");
        }
      }


			// Second Source
			var Movies = new List<Movie>()
      {
        new (1, "Elizabeth Sue", "The Saint"),
        new (2, "Adonis", "Greek God" ),
        new (3, "Amy Adams", "Year Leap" ),
        new (4, "Adonis", "Greek God" ),
        new (5, "Vanessa", "Mission Imposible" ),
        new (6, "Eris", "Megamind" ),
      };

      var joinList = result.Join(Movies, r=> r.Name, m => m.Protagonist, (r, m) => m ).ToList();

      foreach(var l in joinList) {
        Console.WriteLine("Name = " + l.Protagonist + " " + l.MovieName);
      }

      // Select Clause
      var selectedList = Employees
                         .Where(x => x.Color == "Red")
                         .Select(x => new {Name=x.Name, Color=x.Color})
                         .ToList();

      foreach(var item in selectedList) {
        Console.WriteLine(item.Name);
      }


      // All & Any Clause, returns bools
      var anyResultTrue = Employees.Any(x => x.Color == "blue");
      var anyResultFalse = Employees.Any(x => x.Color == "beige");

      var allResults = Employees.All(x => x.Name == "baseball");

      Console.WriteLine("All & Any Clause");
      Console.WriteLine("This Should be true: " + anyResultTrue);
      Console.WriteLine("This Should be false: " + anyResultFalse);

      Console.WriteLine("Are all baseball for the name? : " + allResults);
      Console.WriteLine("---------------------");



      // Contains Clause
      List<int> intList = [1, 2, 3, 4, 5];
      var containsResult1 = intList.Contains(8);
      var containsResult2 = intList.Contains(1);

      Console.WriteLine("Contains Clause");
      Console.WriteLine("Contains 8? : " + containsResult1);
      Console.WriteLine("Contains 1? : " + containsResult2);
      Console.WriteLine("---------------------");   


      /// Math Clauses Average, Count, Max, Sum, Min

      Console.WriteLine("Math Clause");
      var avg = intList.Average();
      var max = intList.Max();
      var min = intList.Min();
      var count = intList.Count;
      var sum = intList.Sum();

      Console.WriteLine("avg : " + avg);
      Console.WriteLine("max : " + max);
      Console.WriteLine("min : " + min);
      Console.WriteLine("count : " + count);
      Console.WriteLine("sum :" + sum);
      Console.WriteLine("---------------------");      


      ///  ElementAt, First, Last, Single or Defaults Clause
      var elementResult = Employees.ElementAt(0);
      var firstResult = Employees.Where(x => x.Color == "blue").FirstOrDefault();
      var lastResult = Employees.Where(x => x.Color == "blue").LastOrDefault();
      var singleResult = Employees.Where(x => x.Color == "brown").SingleOrDefault();

      Console.WriteLine("elementResult : " + elementResult.Name);
      Console.WriteLine("firstResult : " + firstResult?.Name);
      Console.WriteLine("lastResult : " + lastResult?.Name);
      Console.WriteLine("singleResult : " + singleResult?.Name); //this throws exception if there is more than one match while first returns the first match
      Console.WriteLine("---------------------");

      /// Concat Clause , merges two lists of the same type
      var intLst1 = new List<int>() { 1, 2, 3 };
      var intLst2 = new List<int>() { 4, 5 };
      var intLst3 = intLst1.Concat(intLst2).ToList();

      Console.WriteLine("Concat Clause");
      foreach (var y in intLst3)
      {
          Console.WriteLine(y);
      }
      Console.WriteLine("---------------------");    


      /// Distinct Clause, get the distinct values of a list, 
      /// doesnt work with objects without a helper method

      var dLst = new List<int>() { 1, 1, 2, 3, 3, 3, 5 };
      var distinctLst = dLst.Distinct().ToList();

      Console.WriteLine("Distinct Clause");
      foreach (var y in distinctLst)
      {
          Console.WriteLine(y);
      }
      Console.WriteLine("---------------------");  



      /// Skip & Take Clause
      var skippedLst = Employees.Skip(2).ToList();
      var takenLst = Employees.Take(3).ToList();

      Console.WriteLine("Skip Clause");
      foreach (var y in skippedLst)
      {
          Console.WriteLine(y.Name);
      }
      Console.WriteLine("---------------------");

      Console.WriteLine("Take Clause");
      foreach (var y in takenLst)
      {
          Console.WriteLine(y.Name);
      }
      Console.WriteLine("---------------------");



      /// Deferred Execution vs Immediate Execution
      /// 
      // this is immediate exectuion because we immeditaly tell it to turn it into a list and that needs the objects now
      var imLst = Employees.Skip(2).ToList(); 

      //deffered execution is how u build a query
      var queryw = Employees.Where(x => x.Color == "blue");

      // query = query.Select(x => new Item(5, x?.Name!, x?.Color!));

      var query2 = queryw.Select(x => new { Id = x.Id });
      //you can see if u had conditions or other options you would be able to build a query like this and gives flexibility and u dont have to always need objects for those queries since its basically interpreted as logic
      //like a  sql query, show debugger

      var query3 = query2.ToList(); //executes here

      Console.WriteLine("Deferred");
      foreach (var y in query3)
      {
          Console.WriteLine(y.Id);
      }
      Console.WriteLine("---------------------");


    int[] numbers = [0, 1, 2, 3, 4, 5, 6]; 
    var numQuery = from num in numbers 
                    where (num % 2) == 0 
                    select num; 

    var remains = numbers.Where(n => n % 2 == 0).Select(n => new {n});
    

    foreach (int num in numQuery) 
        Console.WriteLine("{0,1}", num); 
		}
	}
}