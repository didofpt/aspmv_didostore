using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order/Index
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var dao = new OrderDao();
            IEnumerable<Order> model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = res
            });
        }

        //[HttpPost]
        //public ActionResult Detail(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new OrderDao();
        //        var res = dao.Update(product);
        //        if (res)
        //        {
        //            SetAlert("Cập nhật sản phẩm thành công.", "success");
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhận không thành công");
        //        }
        //    }
        //    return View("Edit");
        //}

        [NonAction]
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new BranchDao();
            ViewBag.BranchID = new SelectList(dao.ListAll(), "ID", "BranchName", selectedId);
        }
    }
}