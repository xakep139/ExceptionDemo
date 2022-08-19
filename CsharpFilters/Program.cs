using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpFilters
{
    internal class Program
    {
        private static bool MyPredicate(Exception ex)
        {
            Console.WriteLine("ExceptionFilterPredicate() was called...");

            return ex is InvalidOperationException ioe &&
                ioe.InnerException == null;
        }

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
            catch (InvalidOperationException) // Can we move this catch clause down?
            {
                Console.WriteLine("InvalidOperationException clause");
            }
			#region Hidden
			catch (Exception ex) when (MyPredicate(ex))
            {
                Console.WriteLine("General Exception clause with filter");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HttpRequestException clause");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception clause: {0}", ex);
            }
			#endregion
			finally
			{
                // call this regardless of whether exception occurs or not
                httpClient?.Dispose();
            }
        }
    }
}