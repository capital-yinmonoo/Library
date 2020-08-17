﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LibraryDL;

namespace Library.CheckUser
{
    public class CheckUserAccess
    {
        public static bool UserAccess(string id)
        {
            bool flag = false;
            BaseDL bdl = new BaseDL();
            DataTable dt = new DataTable();
            string viewname = id;
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = HttpContext.Current.Session["UserID"].ToString().Split('_')[0] };
            prms[1] = new SqlParameter("@ViewName", SqlDbType.VarChar) { Value = viewname };
            prms[2] = new SqlParameter("@Option", SqlDbType.Int) { Value = 1 };
            dt = bdl.SelectData("User_Authorization_SelectAll", prms);
            if (dt.Rows.Count > 0)
                flag = true;
            else
                flag = false;

            return flag;
        }
    }
}