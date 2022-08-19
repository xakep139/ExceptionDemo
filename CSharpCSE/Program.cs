using System;
using System.Runtime.InteropServices;

namespace CSharpCSE
{
    internal class Program
    {
        #region Hint section
        // The same behavior can be achieved by changing the app.config:
        //[System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions] // Will not work in .NET Core
        #endregion

        static void Main()
        {
            try
            {
                Marshal.StructureToPtr(123, new IntPtr(123), true);
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("AccessViolationException catch clause visited");
                throw;
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }
        }
    }
}
