using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
	public class ProductRepository
	{
		/// <summary>
		/// Retriev one Product
		/// </summary>
		public Product Retrieve(int productId)
		{
			Product product = new Product(productId);

			//Temporary hard-coded customer with productId == 5 a populated Product
			if (productId == 2)
			{
				product.ProductName = "Record";
				product.ProductDescription = "Jazz record with all the past hit recordings from Blue Note";
				product.CurrentPrice = 10.29M;
			}
			//Object myObject = new Object();
			//Console.WriteLine($"Object: {myObject.ToString()}");
			//Console.WriteLine($"Product: {product.ToString()}");

			return product;
		}

		/// <summary>
		/// Saves the current Product
		/// </summary>
		public bool Save(Product product)
		{
			var success = true;
			if (product.HasChanges)
			{
				if (product.IsValid)
				{
					if (product.IsNew)
					{
						//Call an Insert Stored Procedure
					}
					else
					{
						//Call an Update Stored Procedure
					}
				}
				else
				{
					success = false;
				}
			}
			return success;
		}
	}
}
