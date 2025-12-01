using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.Domain.Services;
using TaskManager.View.Controllers;
using TaskManager.View.Utils;

namespace TaskManager.View.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class AdminOnlyAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authService = context.HttpContext.RequestServices.GetService<IAuthService>();

        if (authService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        if (!authService.IsAdmin)
        {
            var nameController = NameController.GetControllerName(nameof(AccountsController));
            var actionController = nameof(AccountsController.AccessDenied);

            context.Result = new RedirectToActionResult(actionController, nameController, null);
        }
    }
}