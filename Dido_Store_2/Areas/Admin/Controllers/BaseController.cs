using Dido_Store_2.Common;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            //if(session == null)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new
            //        RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            //}
            //base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if(type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        [NonAction]
        public void SetViewDataStatus(bool? selected = null)
        {
            StatusObj active = new StatusObj { Key = CommonConstants.STATUS_ACTIVE, Value = true };
            StatusObj deActive = new StatusObj { Key = CommonConstants.STATUS_DEACTIVE, Value = false };
            ViewBag.Status = new SelectList(new List<StatusObj> { active, deActive }, "Value", "Key", selected);
        }
    }
}