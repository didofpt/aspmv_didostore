using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dido_Store_2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        [ChildActionOnly]
        public PartialViewResult Branch()
        {
            var model = new BranchDao().ListAll();
            return PartialView(model);
        }

        public ActionResult ProductBranch(long branchID)
        {
            var branch = new BranchDao().ViewDetail(branchID);
            return View(branch);
        }

        public ActionResult Detail(int productID)
        {
            var product = new ProductDao().GetById(productID);
            return View(product);
        }
    }
}