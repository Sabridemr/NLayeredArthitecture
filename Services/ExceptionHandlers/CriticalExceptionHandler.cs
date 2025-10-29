using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NLayeredArthitecture.Services
{
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is CriticalException)
            {
                Console.WriteLine("hata ile ilgili sms gönderildi");
            }

            return ValueTask.FromResult(false);
        }
    }
}