using System;
using ACM.BL;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
	[TestClass]
	public class CustomerRepositoryTest
	{
		[TestMethod]
		public void RetrieveValid()
		{
			//-- Arrange
			var customerRepository = new CustomerRepository();
			var expected = new Customer(1)
			{
				EmailAddress = "fbaggins@hobbiton.me",
				FirstName = "Frodo",
				LastName = "Baggins"
			};

			//-- Act
			var actual = customerRepository.Retrieve(1);

			//-- Assert
			Assert.AreEqual(expected.CustomerId, actual.CustomerId);
			Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
			Assert.AreEqual(expected.FirstName, actual.FirstName);
			Assert.AreEqual(expected.LastName, actual.LastName);
			//Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RetrieveExistingWithAdress()
		{
			//-- Arrange
			var customerRepository = new CustomerRepository();
			var expected = new Customer(1)
			{
				EmailAddress = "fbaggins@hobbiton.me",
				FirstName = "Frodo",
				LastName = "Baggins",

				AdressList = new List<Address>()
						   {
								new Address()
								{
									AddressType = 1,
									StreetLine1 = "Bag End",
									StreetLine2 = "Bagshot row",
									City = "Hobbiton",
									State = "Shire",
									Country = "Middle Earth",
									PostalCode = "144"
								},
								new Address()
								{
									AddressType = 2,
									StreetLine1 = "Green Dragon",
									City = "Bywater",
									State = "Shire",
									Country = "Middle Earth",
									PostalCode = "146"
								}
						    }
						};

			//-- Act
			var actual = customerRepository.Retrieve(1);

			//-- Assert
			Assert.AreEqual(expected.CustomerId, actual.CustomerId);
			Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
			Assert.AreEqual(expected.FirstName, actual.FirstName);
			Assert.AreEqual(expected.LastName, actual.LastName);

			for (int i = 0; i < 1; i++)
			{
				Assert.AreEqual(expected.AdressList[i].AddressType, actual.AdressList[i].AddressType);
				Assert.AreEqual(expected.AdressList[i].StreetLine1, actual.AdressList[i].StreetLine1);
				Assert.AreEqual(expected.AdressList[i].City, actual.AdressList[i].City);
				Assert.AreEqual(expected.AdressList[i].State, actual.AdressList[i].State);
				Assert.AreEqual(expected.AdressList[i].Country, actual.AdressList[i].Country);
				Assert.AreEqual(expected.AdressList[i].PostalCode, actual.AdressList[i].PostalCode);
			}
		}
	}
}
