using System;
using System.Collections.Generic;

namespace ACM.BL
{
	public class Order : EntityBase
	{
		public Order()
		{

		}

		public Order(int orderId)
		{
			OrderId = orderId;
			OrderItems = new List<OrderItem>();
		}

		public int CustomerId { get; set; }
		public int OrderId { get; private set; }
		public DateTimeOffset? OrderDate { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public int ShippingAddressId { get; set; }

		public override string ToString() => 
			   $"{OrderDate.Value.Date} ({OrderId})";

		/// <summary>
		/// Validates the order data
		/// </summary>
		/// <returns></returns>
		public override bool Validate()
		{
			var isValid = true;
			
			if (OrderDate == null) isValid = false;

			return isValid;
		}
	}
}
