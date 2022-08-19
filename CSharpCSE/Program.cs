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
                MyMethod();
            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine("AccessViolationException in Main(): {0}", ex.Message);
            }
            catch
            {
                Console.WriteLine("Catch clause in Main()");
            }
            finally
            {
                Console.WriteLine("Executing finally block in Main()");
            }
        }

        private class MyDisposable : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Disposing MyDisposable");
            }
        }

        private static void MyMethod()
        {
            try
            {
                using (new MyDisposable())
                {
                    throw new AccessViolation­Exception("Test exception from MyMethod()");

                    #region Hint section
                    Marshal.StructureToPtr(123, new IntPtr(123), true);
                    #endregion
                }
            }
            catch (AccessViolation­Exception)
            {
                Console.WriteLine("AccessViolationException in MyMethod()");
                throw;
            }
            finally
            {
                Console.WriteLine("Executing finally block in MyMethod()");
            }
        }
    }
}
