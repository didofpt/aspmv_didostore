using Dido_Store_2.Common;
using Model.Dao;
using Model.EF;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product/Index
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var dao = new ProductDao();
            IEnumerable<Product> model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewDataStatus();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            SetViewDataStatus();
            SetViewBag(product.BranchID);
            if(ModelState.IsValid)
            {
                product.Alias = ConvertNameToAlias.ConvertToUnsign(product.Name);
                int res = new ProductDao().Insert(product);
                if(res > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ProductDao().GetById(id);
            SetViewDataStatus(model.Status);
            SetViewBag(model.BranchID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.Alias = ConvertNameToAlias.ConvertToUnsign(product.Name);
                var res = dao.Update(product);
                if(res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhận không thành công");
                }
            }
            return View("Edit");
        }

        [NonAction]
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new BranchDao();
            ViewBag.BranchID = new SelectList(dao.ListAll(), "ID", "BranchName", selectedId);
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

    }
}