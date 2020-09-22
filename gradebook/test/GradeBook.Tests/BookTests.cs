using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
	public class BookTests
	{
		[Fact]
		public void BookGradeValueIsAcceptable()
		{
			//arrange
			var book = new Book("");
			book.AddGrade(105.0);
			book.AddGrade(-5.0);

			//actual
			var statistics = book.GetStatistics();

			//assert
			Assert.NotEqual(105.0, statistics.High);
			Assert.NotEqual(-5, statistics.Low);
		}

		[Fact]
		public void BookCalculatesAnAverageGrade()
		{
			//arrange
			var book = new Book("");
			book.AddGrade(89.1);
			book.AddGrade(90.5);
			book.AddGrade(77.3);

			//actual
			var statistics = book.GetStatistics();

			//assert
			Assert.Equal(85.6, Math.Round(statistics.Average, 1)); //round only one decimal
			Assert.Equal(90.5, statistics.High);
			Assert.Equal(77.3, statistics.Low);
			Assert.Equal('B', statistics.Letter);
		}
	}
}
