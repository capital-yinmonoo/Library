using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LibraryDL;

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
    }
}
