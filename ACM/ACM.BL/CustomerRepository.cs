using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
	public class CustomerRepository
	{
		private AddressRepository addressRepository { get; set; }

		public CustomerRepository()
		{
			addressRepository = new AddressRepository();
		}
		
		/// <summary>
		/// Retrieve one Customer 
		/// </summary>
		public Customer Retrieve(int customerId)
		{
			// Create the instance of Customer class. Pass in the requested id.
			Customer customer = new Customer(customerId);

			//Temporary hard-coded customer with customerId == 1 a populated Customer
			if (customerId == 1)
			{
				customer.EmailAddress = "fbaggins@hobbiton.me";
				customer.FirstName = "Frodo";
				customer.LastName = "Baggins";
				customer.AdressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
			}

			return customer;
		}

		/// <summary>
		/// Saves the current Customer
		/// </summary>
		/// <returns></returns>
		public bool save(Customer customer)
		{
			var success = true;
			if (customer.HasChanges)
			{
				if (customer.IsValid)
				{
					if (customer.IsNew)
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
