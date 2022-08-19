using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#region Region for M3()
// This is true by default
//[assembly: RuntimeCompatibility(WrapNonExceptionThrows = false)]
#endregion

namespace CSharpCatches;

internal class Program
{
    static void Main()
    {
        try
        {
            //CppClassLib.MyCppClass.M1();
            //CppClassLib.MyCppClass.M2();
            //CppClassLib.MyCppClass.M3();
        }

        #region Region for M1()
        catch (NotSupportedException ex)
        {
            Console.WriteLine("NotSupportedException clause in C#: {0}", ex.Message);
        }
        #endregion

        #region Region for M2()
        catch (SEHException ex)
        {
            Console.WriteLine("SEHException clause in C#: {0}", ex.Message);
        }
        #endregion

        #region First region for M3()
        catch (RuntimeWrappedException ex)
        {
            Console.WriteLine("RuntimeWrappedException clause in C#: {0}", ex.WrappedException);
        }
        #endregion

        catch (Exception ex)
        {
            Console.WriteLine("Exception clause in C#: {0}", ex);
        }

        #region Second region for M3()
        catch
        {
            Console.WriteLine("Catch clause in C#");
            throw;
        }
        #endregion
    }
}