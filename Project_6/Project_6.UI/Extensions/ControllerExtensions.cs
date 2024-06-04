using Microsoft.AspNetCore.Mvc;
using Project_6.Common;

namespace Project_6.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response,
            string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response,
            string actionName)
        {
            switch (response.ResponseType)
            {
                case ResponseType.NotFound:
                    return controller.NotFound();
                case ResponseType.ValidationError:
                {
                    foreach (var customValidationError in response.ValidationErrors)
                    {
                        controller.ModelState.AddModelError(customValidationError.PropertyName,
                            customValidationError.ErrorMessage);
                    }

                    return controller.View(response.Data);
                }
                case ResponseType.Succes:
                default:
                    return controller.RedirectToAction(actionName);
            }
        }


        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.View(response.Data);
        }
    }
}