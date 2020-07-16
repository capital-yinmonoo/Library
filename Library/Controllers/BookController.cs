using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFunction;
using LibraryBL;

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

        [HttpGet]
        public string GetBookList()
        {
            Function fun = new Function();
            return fun.DataTableToJSONWithJSONNet(bbl.GetBook());
        }
    }
}