using Dido_Store_2.Areas.Admin.Models;
using Dido_Store_2.Common;
using Model.Dao;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.AdminLogin(model.UserName, model.Password);
                if(res)
                {

                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin
                    {
                        UserName = user.Username,
                        UserID = user.ID
                    };
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
                }
            }
            return View("Index");
        }
    }
}