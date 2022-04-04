using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] _claims;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string claims)
        {
            _claims = claims.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.GetClaimRoles();

            foreach (var claim in _claims)
            {
                if (roleClaims.Contains(claim))
                {
                    return;
                }
            }

            throw new BusinessException("Yetkiniz yok!");
        }
    }
}
