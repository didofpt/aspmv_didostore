
using BotDetect.Web.Mvc;
using Dido_Store_2.Common;
using Dido_Store_2.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dido_Store_2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.Username, model.Password);
                if (res)
                {

                    var user = dao.GetByUserName(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    if(model.RememberMe)
                    {
                        HttpCookie rememberLogin = new HttpCookie("RememberLogin");
                        rememberLogin["Username"] = user.Username;
                        rememberLogin["Password"] = user.Password;
                        rememberLogin.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(rememberLogin);
                    }
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
                }
            }
            return View(model);
        }

        [HttpPost]
        [SimpleCaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.Username = model.Username;
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.BirthDay = model.BirthDay;
                    user.Gender = model.Gender;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký ko thành công!");
                    }
                }
            }
            return View(model);
        }
    }
}