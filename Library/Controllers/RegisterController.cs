using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;
using LibraryModel;
using System.Configuration;
using System.Data;
using System.IO;

namespace Library.Controllers
{
    public class RegisterController : Controller
    {
        RegisterBL rbl = new RegisterBL();
        RegisterModel rml = new RegisterModel();
        DataTable dt = new DataTable();
        string Photo = ConfigurationManager.AppSettings["Photo"].ToString();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register_Entry()
        {
            rml.Photo = "Default.Photo";
            return View(rml);
        }

        public ActionResult Register_List()
        {
            String Imsg = Session["Imsg"] as string;
            String Umsg = Session["Umsg"] as string;
            String EImsg = Session["EImsg"] as string;
            String EUmsg = Session["EUmsg"] as string;
            ViewBag.Imsg = Imsg;
            ViewBag.Umsg = Umsg;
            ViewBag.EImsg = EImsg;
            ViewBag.IUmsg = EUmsg;

            Session["Imsg"] = "";
            Session["Umsg"] = "";
            Session["EImsg"] = "";
            Session["EUmsg"] = "";
            return View();
        }

        [HttpGet]
        public string GetMemberList()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(rbl.GetMember());
        }

        public ActionResult Member_Save(RegisterModel rm)
        {
            RegisterBL rbl = new RegisterBL();
            //string flag = string.Empty;
            //RegisterBL rbl = new RegisterBL();
            if (rm != null)
            {
               
                rbl.Member_Save(rm);
            }
            return RedirectToAction("Register_List");
        }
    }
}