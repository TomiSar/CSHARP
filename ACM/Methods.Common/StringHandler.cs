using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
		/// <summary>
		/// Insert spaces before each capital letter in string 
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string InsertSpaces(this string source)
		{
			string result = String.Empty;

			if (String.IsNullOrEmpty(source))
			{
				result = source;
				return result;
			}

			if (!String.IsNullOrWhiteSpace(source))
			{
				foreach (char letter in source)
				{
					if (char.IsUpper(letter))
					{
						//Trim any spaces already there
						result = result.Trim();
						result += " ";
					}
					result += letter;
				}
			}
			//Trim to remove space before first capital character
			return result.Trim();
		}
    }
}
