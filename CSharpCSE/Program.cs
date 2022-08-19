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
                throw new AccessViolation­Exception("Test exception");

                #region Hint section
                Marshal.StructureToPtr(123, new IntPtr(123), true);
                #endregion
            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine("AccessViolationException clause visited: {0}", ex.Message);
            }
            catch
            {
                Console.WriteLine("Catch clause visited");
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }
        }
    }
}
