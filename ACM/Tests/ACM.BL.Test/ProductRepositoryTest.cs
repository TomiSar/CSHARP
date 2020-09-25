using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
	[TestClass]
	public class ProductRepositoryTest
	{
		[TestMethod]
		public void RetrieveTest()
		{
			//-- Arrange
			var productRepository = new ProductRepository();
			var expected = new Product(2)
			{
				ProductName = "Record",
				ProductDescription = "Jazz record with all the past hit recordings from Blue Note",
				CurrentPrice = 10.29M
			};

			//-- Act
			var actual = productRepository.Retrieve(2);

			//-- Assert
			Assert.AreEqual(expected.ProductId, actual.ProductId);
			Assert.AreEqual(expected.ProductName, actual.ProductName);
			Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
			Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
		}

		[TestMethod]
		public void SaveTestValid()
		{
			//-- Arrange
			var productRepository = new ProductRepository();
			var updatetdProduct = new Product(2)
			{
				CurrentPrice = 18.23M,
				ProductName = "Record",
				ProductDescription = "Jazz record with all the past hit recordings from Blue Note",
				HasChanges = true
			};

			//-- Act
			var actual = productRepository.Save(updatetdProduct);

			//-- Assert
			Assert.AreEqual(true, actual);
		}

		[TestMethod]
		public void SaveTestMissingPrice()
		{
			//-- Arrange
			var productRepository = new ProductRepository();
			var updatetdProduct = new Product(2)
			{
				CurrentPrice = null,
				ProductName = "Record",
				ProductDescription = "Jazz record with all the past hit recordings from Blue Note",
				HasChanges = true
			};

			//-- Act
			var actual = productRepository.Save(updatetdProduct);

			//-- Assert
			Assert.AreEqual(false, actual);
		}
	}
}
