using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
	[TestClass]
	public class OrderRepositoryTest
	{
		[TestMethod]
		public void RetrieveTest()
		{
			//-- Arrange
			var orderRepository = new OrderRepository();
			var expected = new Order(2)
			{
				OrderDate = new DateTimeOffset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 00, 00,
					new TimeSpan(8, 0, 0)),
			};

			//-- Act
			var actual = orderRepository.Retrieve(2);

			//-- Assert
			Assert.AreEqual(expected.OrderDate, actual.OrderDate);
		}
	}
}
