using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        // GET: Admin/Branch
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new BranchDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new BranchDao();
            Branch model = dao.GetByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            if(ModelState.IsValid)
            {
                var dao = new BranchDao();
                branch.CreatedDate = DateTime.Now;
                int res = dao.Insert(branch);
                if(res > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View("Create");
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            if(ModelState.IsValid)
            {
                var dao = new BranchDao();
                branch.UpdatedDate = DateTime.Now;
                var res = dao.Update(branch);
                if(res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật hãng thất bại");
                }
            }
            return View("Edit");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new BranchDao();
            bool res = dao.Delete(id);
            if(res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Xóa hãng thất bại");
            }
            return View("Index");
        }
    }
}