using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;


namespace Library.Controllers
{
    public class RegisterController : Controller
    {
        RegisterBL rbl = new RegisterBL();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register_List()
        {
            return View();
        }

        [HttpGet]
        public string GetMemberList()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(rbl.GetMember());
        }
    }
}