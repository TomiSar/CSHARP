using Acme.Common;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
		public Customer(): this(0)
		{

		}

		public Customer(int customerId)
		{
			CustomerId = customerId;
			AdressList = new List<Address>(); //Init list prevent NullValueException!! 
		}

		public List<Address> AdressList { get; set; } 
		public int CustomerId { get; private set; }
		public int CustomerType { get; set; }
		public string EmailAddress { get; set; }
		//prop, propg, propfull
		public string FirstName { get; set; }
		public static int InstanceCount { get; set; }

		public string FullName
		{
			get
			{
				string fullName = LastName;
				if (!string.IsNullOrWhiteSpace(FirstName))
				{
					if (!string.IsNullOrWhiteSpace(fullName))
					{
						fullName += ", "; 
					}
					fullName += FirstName;
				}
				return fullName;
			}
		}

		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
			}
		}

		public override string ToString() => FullName;

		public string Log() =>
			$"{CustomerId}: {FullName} Email: {EmailAddress} Status: {EntityState.ToString()}";

		/// <summary>
		/// Validate the Customer data
		/// </summary>
		/// <returns></returns>
		public override bool Validate()
		{
			var isValid = true;
			if (string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(EmailAddress)) {
				isValid = false;
			}

			return isValid;
		}
	}
}
