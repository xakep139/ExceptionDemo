using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Filters
{
    internal class Program
    {
        private static bool ExceptionFilterPredicate(Exception ex)
        {
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
            catch (Exception ex) when (ExceptionFilterPredicate(ex))
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
            finally
            {
                //call this if exception occurs or not
                httpClient?.Dispose();
            }
        }
    }
}