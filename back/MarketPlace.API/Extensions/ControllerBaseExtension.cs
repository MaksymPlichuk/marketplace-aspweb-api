using MarketPlace.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MarketPlace.API.Extensions
{
    public static class ControllerBaseExtension
    {
        public static IActionResult GetAction(this ControllerBase controller, ServiceResponse response)
        {
            if (response.IsSuccess)
            {
                return controller.Ok(response);
            }
            else
            {
                return controller.BadRequest(response);
            }
        }
    }
}
