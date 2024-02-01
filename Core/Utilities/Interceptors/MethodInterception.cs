using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Method çalışmadan önce çalışıyor...
        protected virtual void OnBefore(IInvocation invocation)
        {

        }

        //Method çalıştıktan sonra çalışıyor...
        protected virtual void OnAfter(IInvocation invocation)
        {

        }

        //Method hataya düştüğünde çalışıyor...
        protected virtual void OnException(IInvocation invocation, System.Exception ex)
        {

        }

        //Method başarılı olduğunda çalışıyor...
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;
            
            //Method çalışmadan önce çalıştı...
            OnBefore(invocation);

            try
            {
                //Methodu çalıştır demektir...
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                //Method hataya düşerse çalışır...
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    //Eğer başarılı ise method başarılı tamamlandığı için çalıştır...
                    OnSuccess(invocation);
                }
            }

            //En sonunda method bitiminde çalışır...
            OnAfter(invocation);
        }
    }
}