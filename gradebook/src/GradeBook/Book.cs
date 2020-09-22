using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{//getter and setter prop, propg and propfull + tab
	public class Book
	{
		public string Name;
		private List<double> grades;

		//constructor
		public Book(string name)
		{
			Name = name;
			grades = new List<double>();
		}

		//a, b, c, d, e, f Grades
		public void AddLetterGrade(char letter)
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
		public void AddGrade(double grade)
		{

			if (grade >= 0 && grade <= 100)
			{
				grades.Add(grade);
			}
			else 
			{
				Console.WriteLine( new ArgumentException($"Invalid {nameof(grade)}"));
			}
		}

		public Statistics GetStatistics()
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
