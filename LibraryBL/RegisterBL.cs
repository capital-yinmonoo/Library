using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDL;

namespace LibraryBL
{
    public class RegisterBL
    {

        public DataTable GetMember()
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[0];
            return bdl.SelectData("M_Member_SelecAll", prms);
        }
    }
}
