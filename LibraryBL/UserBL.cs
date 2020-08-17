using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryModel;
using LibraryDL;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace LibraryBL
{
    public class UserBL
    {
        public UserModel CheckLogin(UserModel umodel)
        {
            LibraryEntities3 db = new LibraryEntities3();
            M_User um = db.M_User.Where(m => m.UserID == umodel.UserID && m.Password == umodel.Password).SingleOrDefault();

            if (um == null)
                return null;
            else
            {
                umodel.UserID = um.UserID;
                umodel.UserName = um.UserName;
                return umodel;
            }
        }
        public string SaveUser(UserModel um)
        {

            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_User mb = new M_User();
            mb.UserID = um.UserID;
            mb.UserName = um.UserName;
            mb.Password = um.Password;
            try
            {
                lbe.M_User.Add(mb);
                lbe.SaveChanges();
                msg = "OK";
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return msg;
        }
        public DataTable GetUser()
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[0];
            return bdl.SelectData("M_User_SelectAll", prms);
        }

        public DataTable M_View_Select()
        {
            BaseDL bdl = new BaseDL();
            return bdl.SelectData("M_View_SelectAll", null);
        }
    }
}
