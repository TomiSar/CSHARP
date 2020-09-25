using Acme.Common;

namespace ACM.BL
{
	public class Product : EntityBase, ILoggable
	{
		public Product()
		{

		}

		public Product(int productID)
		{
			ProductId = productID;
		}

		public int ProductId { get; private set; }
		public string ProductDescription { get; set; }
		//CurrentPrice --> Nullable type can hold Current Price value or null
		public decimal? CurrentPrice { get; set; }

		private string _productName;
		public string ProductName
		{
			get 
			{
				return _productName.InsertSpaces();
			}
			set 
			{
				_productName = value; 
			}
		}

		public override string ToString() => ProductName;

		public string Log() =>
			$"{ProductId}: {ProductName} Detail: {ProductDescription} Status: {EntityState.ToString()}";

		/// <summary>
		/// Validates the Product data 
		/// </summary>
		/// <returns></returns>
		public override bool Validate()
		{
			var isValid = true;
			if (string.IsNullOrWhiteSpace(ProductName) || CurrentPrice == null)
			{
				isValid = false;
			}
			return isValid;
		}
	}
}
