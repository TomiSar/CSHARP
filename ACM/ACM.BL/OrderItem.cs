namespace ACM.BL
{
	public class OrderItem
 	{
		public OrderItem()
		{

		}

		public OrderItem(int orderItemId)
		{
			OrderItemId = orderItemId;
		}

		public int OrderItemId { get; private set; }
		public int ProductId { get; set; }
		public decimal? PurchasePrice { get; set; }
		public int Quantity { get; set; }

		/// <summary>
		/// Retrieve one Order Item 
		/// </summary>
		/// <returns></returns>
		public OrderItem Retrieve()
		{
			return new OrderItem();
		}

		/// <summary>
		/// Saves the current Order item
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			return true;
		}

		/// <summary>
		/// Validates the Order item data
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			var isValid = true;
			if  (Quantity <= 0 || ProductId <= 0 || PurchasePrice == null)
			{
				isValid = false;
			}
			return isValid;
		}
	}
}
