using Castle.DynamicProxy;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            //Eğer gönderilen validatorType bir IValidator türünde değilse hata veririz...
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //Bir tane instance üretiyoruz. Aslında productValidator nesnesini newlemiş oluyoruz...
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //Objeye yani bizim birinci sıradaki objemize ulaşıyoruz. Örneğin entity'e...
            Type entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //Methodun parametrelerine bakılır ve filtreleniyor...
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}