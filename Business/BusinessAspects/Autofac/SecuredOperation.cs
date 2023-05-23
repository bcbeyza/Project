using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//jwt göndererek yapılan istek için bir htttpContext olusur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//roller attribute oldugu için , ile ayırıyoruz
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//autofacte yapılan injection degerlerini alacak

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;//metodu calıstırmaya devam et.Hata yok
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//yetkin yok hatası ver
        }
    }
}
