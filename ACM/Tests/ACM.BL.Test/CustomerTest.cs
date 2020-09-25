using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
	[TestClass]
	public class CustomerTest
	{
		[TestMethod]
		public void FullNameTestValid()
		{
			//-- Arrange
			Customer customer = new Customer()
			{
				FirstName = "Bilbo",
				LastName = "Baggins"
			};

			string expected = "Baggins, Bilbo";

			//-- Act
			string actual = customer.FullName;

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FullNameFirstNameEmpty()
		{
			//-- Arrange
			Customer customer = new Customer()
			{
				LastName = "Baggins"
			};

			string expected = "Baggins";

			//-- Act
			string actual = customer.FullName;

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FullNameLastNameEmpty()
		{
			//-- Arrange
			Customer customer = new Customer()
			{
				FirstName = "Bilbo"
			};

			string expected = "Bilbo";

			//-- Act
			string actual = customer.FullName;

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void StaticTest()
		{
			//-- Arrange
			var c1 = new Customer();
			c1.FirstName = "Bilbo";
			Customer.InstanceCount += 1;

			var c2 = new Customer();
			c2.FirstName = "Frodo";
			Customer.InstanceCount += 1;

			var c3 = new Customer();
			c1.FirstName = "Rosie";
			Customer.InstanceCount += 1;

			//-- Act
			int actual = Customer.InstanceCount;

			//-- Assert
			Assert.AreEqual(3, actual);
		}

		[TestMethod]
		public void ValidateValid()
		{
			var customer = new Customer
			{
				LastName = "Baggins",
				EmailAddress = "fbaggins@hobbiton.me"
			};

			//-- Arrange
			var expected = true;

			//-- Act
			var actual = customer.Validate();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ValidateMissingLastName()
		{
			var customer = new Customer
			{
				EmailAddress = "fbaggins@hobbiton.me"
			};

			//-- Arrange
			var expected = false;

			//-- Act
			var actual = customer.Validate();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
