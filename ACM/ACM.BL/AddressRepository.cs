using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
	class AddressRepository
	{
		/// <summary>
		/// Retrieve one address
		/// </summary>
		/// <param name="addressId"></param>
		/// <returns></returns>
		public Address Retrieve(int addressId)
		{
			// Create the instance of Address class. Pass in the requested id.
			Address address = new Address(addressId);

			//Temporary hard-coded customer with adreessId == 1 a populated Address
			//Unit test uses same values
			if (addressId == 1)
			{
				address.AddressType = 1;
				address.StreetLine1 = "Bag End";
				address.StreetLine2 = "Bagshot row";
				address.City = "Hobbiton";
				address.State = "Shire";
				address.Country = "Middle Earth";
				address.PostalCode = "144";
			}

			return address;
		}

		public IEnumerable<Address> RetrieveByCustomerId(int customerId)
		{
			//Temporary hard-coded values to return. A set of adresses dor a customer.
			var addressList = new List<Address>();
			Address address = new Address(1)
			{
				AddressType = 1,
				StreetLine1 = "Bag End",
				StreetLine2 = "Bagshot row",
				City = "Hobbiton",
				State = "Shire",
				Country = "Middle Earth",
				PostalCode = "144"
			};
			addressList.Add(address);

			address = new Address(2)
			{
				AddressType = 2,
				StreetLine1 = "Green Dragon",
				City = "Bywater",
				State = "Shire",
				Country = "Middle Earth",
				PostalCode = "146"
			};
			addressList.Add(address);

			return addressList;
		}

		/// <summary>
		/// Save the current Address
		/// </summary>
		/// <returns></returns>
		public bool Save(Address address)
		{
			var success = true;
			if (address.HasChanges)
			{
				if (address.IsValid)
				{
					if (address.IsNew)
					{
						//Call an Insert Stored Procedure
					}
					else //Call an Update Stored Procedure
					{
						
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
