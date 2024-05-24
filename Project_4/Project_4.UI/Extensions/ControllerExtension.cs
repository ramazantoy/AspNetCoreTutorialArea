using Microsoft.AspNetCore.Mvc;
using Project_4.Common.ResponseObjects;

namespace Project_4.UI.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller,IResponse<T> response,string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
               return controller.NotFound();
            }

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var validationError in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(validationError.PropertyName,validationError.ErrorMessage);
                }

                return controller.View(response.Data);
            }

            return controller.RedirectToAction(actionName);


        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.View(response.Data);
        }

        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response,string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.RedirectToAction(actionName);
        }
    }
}