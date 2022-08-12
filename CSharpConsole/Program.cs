using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = false)]

namespace CSharpConsole;

internal class Program
{
	[DllImport("UnmanagedClassLib.dll")]
	static public extern void ThrowUnmanagedException();

	static void Main()
	{
		try
		{
			//ThrowUnmanagedException();
			//CppClassLib.MyCppClass.MethodThatThrows();
			//CppClassLib.MyCppClass.MethodThatThrowsManaged();
			CppClassLib.MyCppClass.M3();
		}
		catch (RuntimeWrappedException)
		{
			Console.WriteLine("RuntimeWrappedException clause in C#");
		}
		catch (SEHException ex)
		{
			Console.WriteLine("SEHException clause in C#: {0}", ex);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Exception clause in C#: {0}", ex);
		}
		catch
		{
			Console.WriteLine("Catch clause in C#");
			throw;
		}
	}
}