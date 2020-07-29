using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;
using LibraryModel;
using System.IO;
using System.Configuration;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookBL bbl = new BookBL();
        //string PDF = ConfigurationManager.AppSettings["PDF"].ToString();
        BookModel bm = new BookModel();
        public ActionResult Book()
        {
            return View();
        }


        public ActionResult Book_Entry(string id)
        {
            //return View();
            if (!string.IsNullOrWhiteSpace(id))
            {
                bm.BookID = id;
                ViewBag.BookID = id;
                bm = bbl.Searchbook(bm);
            }
            else
            {
                ViewBag.BookID = "";
            }
            return View(bm);
        }


        [HttpGet]
        public string GetBookList()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(bbl.GetBook());
        }

        [HttpGet]
        public string GetBookType()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(bbl.GetBookType());
        }
        public ActionResult M_BookSave(BookModel bm)
        {
            //bbl.Book_Save(bm);
            //return RedirectToAction("Book");
            if(bm !=null)
            {
                var mid = bbl.Check_Book(bm);

                if (mid == null || mid == "")
                {
                    HttpPostedFileBase pdf = Request.Files["pdffile"];
                    string pdfname = string.Empty;
                    pdfname = pdf.FileName;
                    bm.PDF = pdfname;
                    bbl.Book_Save(bm);
                }
                else
                {
                    HttpPostedFileBase pdf = Request.Files["pdffile"];
                    string pdfname = string.Empty;
                    pdfname = pdf.FileName;
                    bm.PDF = pdfname;
                    bbl.Book_Update(bm);
                }
               
            }
            return RedirectToAction("Book");
        }
    }
}