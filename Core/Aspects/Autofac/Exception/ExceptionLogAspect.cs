using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Loging;
using Core.CrossCuttingConcerns.Loging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, System.Exception ex)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);

            logDetailWithException.ExceptionMessage = ex.Message;

            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            List<LogParameter> logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i]?.Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i]?.GetType().Name
                });
            }

            LogDetailWithException logDetailWithException = new LogDetailWithException()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}