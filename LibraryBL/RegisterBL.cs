using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDL;
using LibraryModel;



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

        public string Member_Save(RegisterModel rm)
        {

            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_Member mb = new M_Member();
            mb.MemberID = rm.MemberID;
            mb.MemberName = rm.MemberName;
            mb.MemberPassword = rm.MemberPassword;
            mb.ContactNo = rm.ContactNo;
            mb.Address = rm.Address;

            try
            {
                lbe.M_Member.Add(mb);
                lbe.SaveChanges();
                msg = "OK";
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return msg;
        }
       
    }
}
