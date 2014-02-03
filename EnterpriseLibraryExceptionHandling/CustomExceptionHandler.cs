using System;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;

namespace EnterpriseLibraryExceptionHandling
{
    [ConfigurationElementType(typeof (CustomHandlerData))]
    public class CustomExceptionHandler : IExceptionHandler
    {
        public CustomExceptionHandler()
        {
   
        }

        public CustomExceptionHandler(NameValueCollection ignore)
        {
        }

        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            return new Exception();
        }
    }
}