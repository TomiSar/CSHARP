using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
	public class OrderRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public Order Retrieve(int orderId)
		{
			Order order = new Order(orderId);

			//Temporary hard-coded customer with oorderId == 5 a populated Product
			if (orderId == 2)
			{
				order.OrderDate = new DateTimeOffset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 00, 00,
								  new TimeSpan(8, 0, 0));
			}
			return order;
		}

		/// <summary>
		/// Sava the current Order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public bool Save(Order order)
		{
			var success = true;
			if (order.HasChanges)
			{
				if (order.IsValid)
				{
					if (order.IsNew)
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
