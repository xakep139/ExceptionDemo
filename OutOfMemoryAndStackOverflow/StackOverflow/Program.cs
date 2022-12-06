using System;

namespace StackOverflow;

internal class Program
{
	static void Main(string[] _)
	{
		try
		{
			InfiniteRecursion(0);
		}
		catch (StackOverflowException)
		{
			Console.WriteLine("We caught StackOverflowException!");
		}
		catch (InsufficientExecutionStackException ex)
		{
			Console.WriteLine("Caught {0}", ex.Message);
		}

		Console.WriteLine("Pgrogram terminated successfully...");
	}

	static void InfiniteRecursion(int iteration)
	{
		//System.Runtime.CompilerServices.RuntimeHelpers.EnsureSufficientExecutionStack();
		InfiniteRecursion(iteration + 1);
		Console.WriteLine("Iteration {0} completed", iteration);
	}
}