using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Pantry.Utilities.Interceptor
{
    internal class DataHandlerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                ExceptionLogger.Log($"Method {invocation.Method.Name} " +
                                    $"called with these parameters: {invocation.Arguments}" +
                                    $"returned this response: {invocation.ReturnValue}");
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogExceptionToFile(ex, $"Method {invocation.Method.Name} " +
                                                       $"called with these parameters: {JsonConvert.SerializeObject(invocation.Arguments)}");
                throw;
            }
        }
    }
}
