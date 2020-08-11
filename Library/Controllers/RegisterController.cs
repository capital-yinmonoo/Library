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

        public ActionResult Register_Entry(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                rml.MemberID = id;
                ViewBag.MemberID = id;
                rml = rbl.SearchMember(rml);
            }
            else
            {
             
                ViewBag.MemberID= "";
                rml.Photo = "Default.png";
            }
            return View(rml);
        }

        public ActionResult Register_List()
        {
            String Imsg = Session["Imsg"] as string;
            String Umsg = Session["Umsg"] as string;
            ViewBag.Imsg = Imsg;
            ViewBag.Umsg = Umsg;
            Session["Imsg"] = "";
            Session["Umsg"] = "";
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
            string msg = string.Empty;
            if (rm != null)
            {
                var mid = rbl.Check_Member(rm);
               
                if (mid == null || mid == "")
                {
                    HttpPostedFileBase imgfile = Request.Files["imgdata"];
                    string photoname = string.Empty;
                    photoname = imgfile.FileName;
                    if (!string.IsNullOrWhiteSpace(photoname))
                    {
                        if (!Directory.Exists(Photo))
                        {
                            Directory.CreateDirectory(Photo);
                        }
                        string path = Photo + rm.MemberID + Path.GetExtension(photoname);
                        imgfile.SaveAs(path);
                        rm.Photo = rm.MemberID + Path.GetExtension(photoname);
                    }
                    else
                    {
                        rm.Photo = "Default.png";
                    }
                    msg=rbl.Member_Save(rm);
                    if (msg == "Insert Success")
                    {
                        Session["Imsg"] = "Insert";
                    }
                }
                else
                {
                    HttpPostedFileBase imgfile = Request.Files["imgdata"];
                    string photoname = string.Empty;
                    photoname = imgfile.FileName;
                    if (!string.IsNullOrWhiteSpace(photoname))
                    {
                        if (!Directory.Exists(Photo))
                        {
                            Directory.CreateDirectory(Photo);
                        }
                        string path = Photo + rm.MemberID + Path.GetExtension(photoname);
                        imgfile.SaveAs(path);
                        rm.Photo = rm.MemberID + Path.GetExtension(photoname);
                    }
                    else
                    {
                        DataTable dt = rbl.MemberCheck(mid);

                        rm.Photo = dt.Rows[0]["Photo"].ToString();
                    }
                    
                    msg=rbl.Member_Update(rm);
                    if (msg == "OK")
                    {
                        Session["Umsg"] = "Update";
                    }
                }
            }
            return RedirectToAction("Register_List");
        }
    }
}