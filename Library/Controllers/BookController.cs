using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;
using LibraryModel;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookBL bbl = new BookBL();
        public ActionResult Book()
        {
            return View();
        }


        public ActionResult Book_Entry()
        {
            return View();
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
            bbl.Book_Save(bm);
            return RedirectToAction("Book");
        }
    }
}