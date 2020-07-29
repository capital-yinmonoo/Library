using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LibraryDL;
using LibraryModel;


namespace LibraryBL
{
    public class BookBL
    {
        public DataTable GetBook()
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[0];
            return bdl.SelectData("M_Book_SelectAll", prms);
        }

        public DataTable GetBookType()
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[0];
            return bdl.SelectData("M_BookType_SelectAll", prms);
        }

        public string Book_Save(BookModel bm)
        {

            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_Book mb = new M_Book();
            mb.BookID = bm.BookID;
            mb.BookName = bm.BookName;
            mb.BookType = bm.BookType;
            mb.PDF = bm.PDF;
            try
            {
                lbe.M_Book.Add(mb);
                lbe.SaveChanges();
                msg = "OK";
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return msg;
        }

        public string Check_Book(BookModel rm)
        {
            LibraryEntities3 lb = new LibraryEntities3();
            string msg = string.Empty;
            M_Book update = lb.M_Book.Where(c => c.BookID.Equals(rm.BookID)).SingleOrDefault();
            if (update != null)
                msg = update.BookID;
            else
                msg = "";
            return msg;
        }

        public string Book_Update(BookModel rm)
        {

            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_Book mb = lbe.M_Book.Where(c => c.BookID.Equals(rm.BookID)).SingleOrDefault();
            mb.BookName = rm.BookName;
            mb.BookType = rm.BookType;
            mb.PDF = rm.PDF;
            try
            {
                lbe.SaveChanges();
                msg = "OK";
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return msg;
        }

        public BookModel Searchbook(BookModel bm)
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@BookID", SqlDbType.Int) { Value = bm.BookID };
            //prms[1] = new SqlParameter("@StaffName", SqlDbType.VarChar) { Value = sm.StaffName };
            DataTable dt = bdl.SelectData("M_Book_Search", prms);
            if (dt.Rows.Count > 0)
            {
                bm.BookID = dt.Rows[0]["BookID"].ToString();
                bm.BookName = dt.Rows[0]["BookName"].ToString();
                bm.BookType = dt.Rows[0]["BookType"].ToString();
            }

            return bm;
        }
    }
}
