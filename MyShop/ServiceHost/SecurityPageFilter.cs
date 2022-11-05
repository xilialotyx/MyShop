using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission =
                (NeedsPermissionAttribute) context.HandlerMethod.MethodInfo.GetCustomAttribute(
                    typeof(NeedsPermissionAttribute));

            if (handlerPermission == null)
                return;

            var userPermissions = _authHelper.GetPermissions();

            if (userPermissions.All(x => x != handlerPermission.Permission))
                context.HttpContext.Response.Redirect("/User");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}