using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#region Region for M3()
[assembly: RuntimeCompatibilityAttribute(WrapNonExceptionThrows = true)]
#endregion

namespace CSharpConsole;

internal class Program
{
    static void Main()
    {
        try
        {
            CppClassLib.MyCppClass.M1();
            // CppClassLib.MyCppClass.M2();
            // CppClassLib.MyCppClass.M3();
        }
        catch (RuntimeWrappedException ex)
        {
            Console.WriteLine("RuntimeWrappedException clause in C#: {0}", ex.WrappedException);
        }
        catch (SEHException ex)
        {
            Console.WriteLine("SEHException clause in C#: {0}", ex.Message);
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