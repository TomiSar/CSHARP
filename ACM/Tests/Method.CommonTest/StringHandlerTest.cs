using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Common;

namespace Acme.CommonTest
{
	[TestClass]
	public class StringHandlerTest
	{

		[TestMethod]
		public void InsertSpacesTestValid()
		{
			//-- Arrange
			var source = "InsertSpaceBetween";
			var expected = "Insert Space Between";

			//-- Act
			var actual =  source.InsertSpaces();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsertSpacesTestWithExistingSpace()
		{
			//null string, uppercase String, long string, Short string, UpperCase string

			//-- Arrange
			var source = "No Inserting Space Between If Space Exists";
			var expected = "No Inserting Space Between If Space Exists";

			//-- Act
			var actual = source.InsertSpaces();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsertSpacesTestWitNull()
		{
			//null string, uppercase String, long string, Short string, UpperCase string

			//-- Arrange
			string source = null;
			string expected = null;

			//-- Act
			var actual = source.InsertSpaces();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsertSpacesTestWitEmpty()
		{
			//long string, Short string, UpperCase string

			//-- Arrange
			string source = String.Empty;
			string expected = String.Empty;

			//-- Act
			var actual = source.InsertSpaces();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsertSpacesTestWitUppercase()
		{
			//long string, Short string, UpperCase string

			//-- Arrange
			string source = "TESTUPPER";
			string expected = "T E S T U P P E R";

			//-- Act
			var actual = source.InsertSpaces();

			//-- Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
