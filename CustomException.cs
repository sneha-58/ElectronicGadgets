using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{

	[Serializable]
	public class InvalidDataException : Exception
	{
		public InvalidDataException() { }
		public InvalidDataException(string message) : base(message) { }
		public InvalidDataException(string message, Exception inner) : base(message, inner) { }
		protected InvalidDataException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

	[Serializable]
	public class InsufficientStockException : Exception
	{
		public InsufficientStockException() { }
		public InsufficientStockException(string message) : base(message) { }
		public InsufficientStockException(string message, Exception inner) : base(message, inner) { }
		protected InsufficientStockException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class IncompleteOrderException : Exception
	{
		public IncompleteOrderException() { }
		public IncompleteOrderException(string message) : base(message) { }
		public IncompleteOrderException(string message, Exception inner) : base(message, inner) { }
		protected IncompleteOrderException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class PaymentFailedException : Exception
	{
		public PaymentFailedException() { }
		public PaymentFailedException(string message) : base(message) { }
		public PaymentFailedException(
          System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class ConcurrencyException : Exception
	{
		public ConcurrencyException() { }
		public ConcurrencyException(string message) : base(message) { }
		public ConcurrencyException(string message, Exception inner) : base(message, inner) { }
		protected ConcurrencyException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class AuthenticationException : Exception
	{
		public AuthenticationException() { }
		public AuthenticationException(string message) : base(message) { }
		public AuthenticationException(string message, Exception inner) : base(message, inner) { }
		protected AuthenticationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
