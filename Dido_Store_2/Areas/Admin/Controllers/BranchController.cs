using Model.Dao;
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


    }
}