using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryBL;
using LibraryModel;
using CommonFunction;
using System.Data;
using FastMember;
using Newtonsoft.Json;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserBL ubl = new UserBL();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string GetUserList()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(ubl.GetUser());
        }
        public ActionResult User_list()
        {
            return View();
        }
        public ActionResult User_Entry(string id)
        {

            return View();
        }
        public ActionResult M_UserSave(UserModel um)
        {
            ubl.SaveUser(um);
            return RedirectToAction("User_list");
        }

        [HttpPost]
        public string _MViewBind(string id)
        {
            string jsonresult;
            DataTable dt = ubl.M_View_Select();

            dt.Columns.Add("Total", typeof(System.Int32));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Total"] = dt.Rows.Count;
                }
                jsonresult = JsonConvert.SerializeObject(dt);
                return jsonresult;
            }
            else
                return JsonConvert.SerializeObject(dt);

        }
    }
}