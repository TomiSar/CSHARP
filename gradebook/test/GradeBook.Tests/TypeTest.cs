using System;
using Xunit;

namespace GradeBook.Tests
{
	public delegate string WriteLogDelegate(string logMessage);

	public class TypeTests
	{
		int count = 0;

		//Test that uses delegate
		[Fact]
		public void WriteLogDelegatCanPointToMehod()
		{
			WriteLogDelegate log = ReturnMessage;
			log += ReturnMessage;
			log += IncrementCount;
			var result = log("Hello!");

			Assert.Equal(3, count);
			//Assert.Equal("Hello!Hello!hello!", result);

			//WriteLogDelegate log = ReturnMessage;
			//var result = log("Hello!");
			//Assert.Equal("Hello!", result);
		}

		string IncrementCount(string message)
		{
			count++;
			return message.ToLower();
		}

		string ReturnMessage(string message)
		{
			count++;
			return message;
		}

		//Tests passing and setting the values
		[Fact]
		public void ValueTypeAlsoPassByValue()
		{
			var i = GetInt();
			Assert.Equal(10, i);

			SetInt(ref i);
			Assert.Equal(42, i);
		}

		//Copy harcoded int only to value
		private void SetInt(ref int i)
		{
			i = 42;
		}

		private int GetInt()
		{
			return 10;
		}
		
		//String or string is ALWAYS a reference type
		//Tests passing and setting the references. A new Class is almost always a ref type that accepts pointer parameter values. 
		[Fact]
		public void BookCanBePassByRef()
		{
			var book1 = GetBook("Book 1");
			GetBookSetName(ref book1, "New Name");
			Assert.Equal("New Name", book1.Name);
		}

		//When parameter call is done. ref Parameter is passsed by reference NOT value.
		//When used in a method's parameter list, the ref keyword indicates that an argument is passed by 
		//reference, not by value. The ref keyword makes the formal parameter an alias for the argument, which must be a variable
		private void GetBookSetName(ref Book book, string name)
		{
			book = new InMemoryBook(name);
			book.Name = name;
		}

		[Fact]
		public void BookIsPassByValue()
		{
			var book1 = GetBook("Book 1");
			GetBookSetName(book1, "New Name");

			Assert.Equal("Book 1", book1.Name);
		}

		//
		private void GetBookSetName(Book book, string name)
		{
			book = new InMemoryBook(name);
			book.Name = name;
		}

		[Fact]
		public void BookNameCanBeSetFromReference()
		{
			var book1 = GetBook("Book 1");
			setName(book1, "Brand New Book 1");
			var book2 = GetBook(book1.Name.ToLower());

			Assert.Equal("Brand New Book 1", book1.Name);
			Assert.Equal("brand new book 1", book2.Name);
		}

		private void setName(Book book, string name)
		{
			book.Name = name;
		}

		//Strings inC# are Immutable (can't be changed after creating a string)
		[Fact]
		public void StringsBehaveLikeValueType()
		{
			string name = "Scott";
			var upper = MakeUpperCase(name);

			Assert.Equal("Scott", name);
			Assert.Equal("SCOTT", upper);
		}

		//Not changing the string parameter. Returns a copy pf string converted to uppercase.
		private string MakeUpperCase(string parameter)
		{
			return parameter.ToUpper();
		}

		[Fact]
		public void GetBookReturnDifferentObjects()
		{
			var book1 = GetBook("Book 1");
			var book2 = GetBook("Book 2");
			var book3 = GetBook("Book 3");

			//assert
			Assert.Equal("Book 1", book1.Name);
			Assert.Equal("Book 2", book2.Name);
			Assert.NotEqual("Book 4", book3.Name); //
			Assert.NotSame(book1, book2);          //book1 Object instance is not same as book2 Object instance
		}

		[Fact]
		public void TwoVariablsCanReferenceToSamaObject()
		{
			//book1 points to book2
			var book1 = GetBook("Book 1");
			var book2 = book1;

			//assert
			Assert.Same(book1, book2);
			Assert.True(Object.ReferenceEquals(book1, book2)); //Determines whether the specified System.Object instances are the same instance.
		}

		Book GetBook(string name)
		{
			return new InMemoryBook(name); 
		}
	}
}
