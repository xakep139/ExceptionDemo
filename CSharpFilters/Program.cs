using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpFilters
{
    internal class Program
    {
        #region Hidden region
        private static bool MyPredicate(Exception ex)
        {
            Console.WriteLine("MyPredicate() was called...");

            return ex is InvalidOperationException ioe &&
                ioe.InnerException == null;
        }
        #endregion

        static async Task Main()
        {
            HttpClient? httpClient = null;
            try
            {
                httpClient = new();
                using var _ = await httpClient.GetAsync("google.com");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                Console.WriteLine("HttpRequestException clause with InternalServerError filter");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException clause");
            }

            #region Hidden section
            catch (Exception ex) when (MyPredicate(ex))
            {
                Console.WriteLine("General Exception clause with filter");
            }
            #endregion

            catch (HttpRequestException) // Can we move this catch clause down?
            {
                Console.WriteLine("HttpRequestException clause");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception clause: {0}", ex);
            }
            finally
            {
                // call this regardless of whether exception occurs or not
                httpClient?.Dispose();
            }
        }
    }
}