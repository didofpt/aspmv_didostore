using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product/Index
        public ActionResult Index()
        {
            var dao = new ProductDao();
            IEnumerable<Product> model = dao.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            return View();
        }

        [NonAction]
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new BranchDao();
            ViewBag.BranchID = new SelectList(dao.ListAll(), "ID", "BranchName", selectedId);
        }

    }
}