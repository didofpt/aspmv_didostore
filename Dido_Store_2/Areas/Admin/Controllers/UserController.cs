using Model.Dao;
using Model.EF;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewDataStatus();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewDataStatus();
            var model = new UserDao().GetById(id);
            return View(model);
        }

        // POST
        [HttpPost]
        // GET: Admin/User/Create
        
        public ActionResult Create(User user)
        {
            SetViewDataStatus();

            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var id = dao.Insert(user);
                if(id > 0)
                {
                    SetAlert("Thêm người dùng thành công.", "success");
                    return RedirectToAction("Index", "User");
                }
                else if(id == -1)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng thất bại");
                }
            }
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            SetViewDataStatus();

            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Update(user);
                if(res)
                {
                    SetAlert("Chỉnh sửa người dùng thành công.", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng thất bại");
                }
            }
            return View("Edit");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = new UserDao().GetById(id);
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}