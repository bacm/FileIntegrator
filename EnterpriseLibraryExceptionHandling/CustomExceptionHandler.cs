using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;

namespace EnterpriseLibraryExceptionHandling
{
    [ConfigurationElementType(typeof (CustomHandlerData))]
    public class CustomExceptionHandler : IExceptionHandler
    {
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            throw new NotImplementedException();
        }
    }
}