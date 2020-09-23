using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{//getter and setter prop, propg and propfull + tab
	//delagte to keep track on application logic with object.
	//Event to Book when grade is added.
	public delegate void GradeAddedDelegate(object sender, EventArgs args);

	//Base class Everything inherits System.Object class <==> object
	public class NamedObject
	{
		public NamedObject(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			set;
		}
	}

	public interface IBook
	{
		void AddGrade(double grade);
		Statistics GetStatistics();
		string Name { get; }
		event GradeAddedDelegate GradeAdded;
	}

	public abstract class Book : NamedObject, IBook
	{
		public Book(string name) : base(name)
		{
		}

		public abstract event GradeAddedDelegate GradeAdded;
		public abstract void AddGrade(double grade);
		public abstract Statistics GetStatistics();
	}

	public class DiskBook : InMemoryBook
	{
		public DiskBook(string name) :base(name)
		{
		}

		public override event GradeAddedDelegate GradeAdded;

		public override void AddGrade(double grade)
		{
			//Write grades in file Scott's grade book.txt
			//Using writer as long as values are written in file atfter the Disposable is used
			//and file is relesed for other resources
			using (var writer = File.AppendText($"{Name}.txt"))
			{
				writer.WriteLine(grade);
				if (GradeAdded != null)
				{
					GradeAdded(this, new EventArgs ());
				}
			}
		}

		public override Statistics GetStatistics()
		{
			var result = new Statistics();
			using (var reader = File.OpenText($"{Name}.txt"))
			{
				var line = reader.ReadLine();
				while(line != null)
				{
					var number = double.Parse(line);
					result.Add(number);
					line = reader.ReadLine();
				}
			}
			return result;
		}
	}

	//Defining A child class : Defining A parent class
	public class InMemoryBook : Book, IBook
	{
		private List<double> grades;
		//constructor
		public InMemoryBook(string name) : base(name)
		{
			grades = new List<double>();
		}

		//Add grade to Grades List if grade 0-100
		//Method overrides Base class method
		public override void AddGrade(double grade)
		{
			if (grade >= 0 && grade <= 100)
			{
				grades.Add(grade);

				//If event = null no need to pass information =)
				if (GradeAdded != null)
				{
					GradeAdded(this, new EventArgs());
				} 
			}
			else 
			{
				Console.WriteLine( new ArgumentException($"Invalid {nameof(grade)}"));
			}
		}

		public override event GradeAddedDelegate GradeAdded;

		public override Statistics GetStatistics()
		{
			var result = new Statistics();

			foreach (var grade in grades)
			{
				result.Add(grade);
			}

			return result;
		}
	}
}
