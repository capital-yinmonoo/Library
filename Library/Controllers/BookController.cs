using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;
using LibraryModel;
using System.IO;
using System.Data;
using System.Configuration;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DataTable dt = new DataTable();
        BookBL bbl = new BookBL();
        string BookFile = ConfigurationManager.AppSettings["BookFile"].ToString();
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
                    //bm.PDF = pdfname;
                    if (!string.IsNullOrWhiteSpace(pdfname))
                    {
                        if (!Directory.Exists(BookFile))
                        {
                            Directory.CreateDirectory(BookFile);
                        }
                        string path = BookFile + bm.BookName + Path.GetExtension(pdfname);
                        pdf.SaveAs(path);
                        bm.PDF = bm.BookName + Path.GetExtension(pdfname);
                       
                    }
                    else
                    {
                        bm.PDF = pdfname;
                    }
                    bbl.Book_Save(bm);
                }
                else
                {
                    HttpPostedFileBase pdf = Request.Files["pdffile"];
                    string pdfname = string.Empty;
                    pdfname = pdf.FileName;
                    //bm.PDF = pdfname;
                    if (!string.IsNullOrWhiteSpace(pdfname))
                    {
                        if (!Directory.Exists(BookFile))
                        {
                            Directory.CreateDirectory(BookFile);
                        }
                        string path = BookFile + bm.BookName + Path.GetExtension(pdfname);
                        pdf.SaveAs(path);
                        bm.PDF = bm.BookName + Path.GetExtension(pdfname);
                       
                    }
                    else
                    {
                        DataTable dt = bbl.BookCheck(mid);
                        bm.PDF = dt.Rows[0]["PDF"].ToString();
                    }
                    bbl.Book_Update(bm);
                }
               
            }
            return RedirectToAction("Book");
        }
    }
}