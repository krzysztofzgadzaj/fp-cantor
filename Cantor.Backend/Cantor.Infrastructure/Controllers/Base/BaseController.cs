using System;
using Microsoft.AspNetCore.Mvc;

namespace Cantor.Infrastructure.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected const string RoutePattern = "api/[controller]";

        protected static string GetUri(Guid resourceId, string resourceName) => 
            string.Format(
                "api/v{0}/{1}",
                (object) resourceName, 
                (object) resourceId);
    }
}