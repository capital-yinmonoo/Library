using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryModel;
using LibraryBL;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(int? errorId)
        {
            if (errorId > 0)
                ViewBag.ErrorMessage = "Incorrect UserID or Password!";
            else
            {
                ViewBag.ErrorMessage = "";
            }
            return View();
        }
        public ActionResult Checklogin(UserModel um)
        {
            UserBL ubl = new UserBL();
            UserModel umodel = ubl.CheckLogin(um);
            if (umodel == null)
            {
                return RedirectToAction("Login", "Login", new { @errorId = 1 });

            }
            else
            {
                Session["UserID"] = um.UserID.ToString();
                return RedirectToAction("Register_List", "Register");
            }
        }
    }
}