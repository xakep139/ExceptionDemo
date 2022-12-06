using System;
using System.Collections.Generic;
using System.Runtime;

namespace SoftOutOfMemory;

internal class Program
{
	static void Main(string[] _)
	{
		try
		{
			var list = new List<decimal[]>();
			while (true)
			{
				list.Add(new decimal[100_500_000]);
			}
			//using var failPoint = new MemoryFailPoint(100_500);
		}
		catch (InsufficientMemoryException ex)
		{
			Console.WriteLine("Caught {0}", ex);
		}
		catch (OutOfMemoryException ex)
		{
			Console.WriteLine("We caught OutOfMemoryException: {0}", ex);
		}

		Console.WriteLine("Pgrogram terminated successfully...");
	}
}

