using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspect.Autofac
{
  public  class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
           _httpContextAccessor= ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //Servisimize baglanarak
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var _role in _roles)
            {
                if (roleClaims.Contains(_role))
                {
                    return;
                }
                throw new Exception(Messages.AuthorizationDenied);
            }
        }
    }
}
