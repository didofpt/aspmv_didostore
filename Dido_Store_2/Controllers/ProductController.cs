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

        public ActionResult ProductBranch(long branchID, int page = 1, int pageSize = 1)
        {
            var branch = new BranchDao().ViewDetail(branchID);
            ViewBag.Branch = branch;
            int totalRecord = 0;
            var model = new ProductDao().ListByBranch(branchID, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult Detail(int productID)
        {
            var product = new ProductDao().GetById(productID);
            ViewBag.Branch = new BranchDao().ViewDetail(product.BranchID.Value);
            ViewBag.RelatedProduct = new ProductDao().ListRelatedProducts(productID);
            return View(product);
        }
    }
}