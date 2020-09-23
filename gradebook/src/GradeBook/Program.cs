using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
		{
			//Create a new book for grades that holds values in merory
			var book = new InMemoryBook("Scott's grade book");
			book.GradeAdded += OnGradeAdded;

			Console.WriteLine("\n******************************************************************");
			Console.WriteLine("***Welcome to GradeBook application you can add grades to Books***");
			Console.WriteLine("******************************************************************\n");

			EntergGrades(book);

			var stats = book.GetStatistics();

			Console.WriteLine($"The lowest grade is {stats.Low}");
			Console.WriteLine($"The highest grade is {stats.High}");
			Console.WriteLine($"The average grade is {stats.Average:N1}");
			Console.WriteLine($"The letter grade is {stats.Letter}");
		}

		private static void EntergGrades(IBook book)
		{
			while (true)
			{
				Console.WriteLine("Please enter grade as number or 'q' to quit? ");
				var input = Console.ReadLine();

				if (input.Equals("q"))
				{           //q Exits the program
					break;
				}

				try
				{
					var grade = double.Parse(input);    //Parse String to double  
					book.AddGrade(grade);               //Add grade to Book
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		static void OnGradeAdded(object sender, EventArgs e)
		{
			Console.WriteLine("A grade was added");
		}
	}
}
