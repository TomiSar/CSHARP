using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
			//Create a new book for grades
			var book = new Book("Scott's grade book");

			Console.WriteLine("\n******************************************************************");
			Console.WriteLine("***Welcome to GradeBook application you can add grades to Books***");
			Console.WriteLine("******************************************************************\n");

			while (true) {
				Console.WriteLine("Please enter grade as number or 'q' to quit? ");
				var input = Console.ReadLine();

				if (input.Equals("q")) {			//q Exits the program
					break;
				}

				//To prevent SystemFormatException
				try
				{
					var grade = double.Parse(input);    //Parse String to double  
					book.AddGrade(grade);               //Add grade to Book
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

			}

			var stats = book.GetStatistics();

			Console.WriteLine($"The lowest grade is {stats.Low}");
			Console.WriteLine($"The highest grade is {stats.High}");
			Console.WriteLine($"The average grade is {stats.Average:N1}");
			Console.WriteLine($"The letter grade is {stats.Letter}");
		}
	}
}
