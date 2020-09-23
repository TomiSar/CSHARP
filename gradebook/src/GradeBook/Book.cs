using System;
using System.Collections.Generic;
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

		public virtual event GradeAddedDelegate GradeAdded;

		public abstract void AddGrade(double grade);

		public virtual Statistics GetStatistics()
		{
			throw new NotImplementedException();
		}
	}

	//Defining A child class : Defining A parent class
	public class InMemoryBook : Book
	{
		private List<double> grades;
		//constructor
		public InMemoryBook(string name) : base(name)
		{
			grades = new List<double>();
		}

		//A, B, C, D, E and F are grades
		public void AddGrade(char letter)
		{
			switch (letter)
			{
				case 'A':
					AddGrade(90);
					break;
				case 'B':
					AddGrade(80);
					break;
				case 'C':
					AddGrade(70);
					break;
				case 'D':
					AddGrade(60);
					break;
				case 'E':
					AddGrade(50);
					break;
				default:
					break;
			}
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
			//new instance of Statisctics
			var result = new Statistics();
			double gradesSum = 0.0;
			result.Average = 0.0;
			result.High = Double.MinValue;
			result.Low= Double.MaxValue;

			foreach (var grade in grades)
			{
				result.Low = Math.Min(grade, result.Low);
				result.High = Math.Max(grade, result.High);
				gradesSum += grade;
			}
			result.Average = gradesSum / grades.Count;

			switch(result.Average)
			{
				case var d when d >= 90.0:
					result.Letter = 'A';
					break;
				case var d when d >= 80.0:
					result.Letter = 'B';
					break;
				case var d when d >= 70.0:
					result.Letter = 'C';
					break;
				case var d when d >= 60.0:
					result.Letter = 'B';
					break;
				case var d when d >= 50.0:
					result.Letter = 'C';
					break;
			}
			return result;
		}
	}
}
