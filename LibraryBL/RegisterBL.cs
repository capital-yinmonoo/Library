using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDL;
using LibraryModel;
using System.Web;



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
            string createdby = string.Empty;
            createdby = HttpContext.Current.Session["UserID"].ToString();
            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_Member mb = new M_Member();
            mb.MemberID = rm.MemberID;
            mb.MemberName = rm.MemberName;
            mb.MemberPassword = rm.MemberPassword;
            mb.ContactNo = rm.ContactNo;
            mb.Address = rm.Address;
            mb.Photo = rm.Photo;
            mb.JoinDate = Convert.ToDateTime(rm.JoinDate);
            mb.CreatedDate = DateTime.Now;
            mb.CreatedBy = createdby;

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

        public string Member_Update(RegisterModel rm)
        {
            string updatedby = string.Empty;
            updatedby = HttpContext.Current.Session["UserID"].ToString();
            LibraryEntities3 lbe = new LibraryEntities3();
            string msg = string.Empty;
            M_Member mb = lbe.M_Member.Where(c => c.MemberID.Equals(rm.MemberID)).SingleOrDefault();
            mb.MemberName = rm.MemberName;
            mb.MemberPassword = rm.MemberPassword;
            mb.ContactNo = rm.ContactNo;
            mb.Address = rm.Address;
            mb.Photo = rm.Photo;
            mb.UpdatedDate = DateTime.Now;
            mb.UpdatedBy = updatedby;

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

        public RegisterModel SearchMember(RegisterModel rml)
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MemberID", SqlDbType.Int) { Value = rml.MemberID };
            //prms[1] = new SqlParameter("@StaffName", SqlDbType.VarChar) { Value = sm.StaffName };
            DataTable dt = bdl.SelectData("M_Member_Search", prms);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Photo"].ToString()))
                    rml.Photo = dt.Rows[0]["Photo"].ToString();
                else
                    rml.Photo = "Default.png";
               rml.MemberID = dt.Rows[0]["MemberID"].ToString();
               rml.MemberName = dt.Rows[0]["MemberName"].ToString();
               rml.MemberPassword = dt.Rows[0]["MemberPassword"].ToString();
               rml.ContactNo = dt.Rows[0]["ContactNo"].ToString();
               rml.Address = dt.Rows[0]["Address"].ToString();
               
            }

            return rml;
        }

        public string Check_Member(RegisterModel rm)
        {
            LibraryEntities3 lb = new LibraryEntities3();
            string msg = string.Empty;
            M_Member update = lb.M_Member.Where(c => c.MemberID.Equals(rm.MemberID)).SingleOrDefault();
            if (update != null)
                msg = update.MemberID;
            else
                msg = "";
            return msg;
        }

        public DataTable MemberCheck(string id)
        {
            BaseDL bdl = new BaseDL();
            DataTable dt = new DataTable();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MemberID", SqlDbType.VarChar) { Value = id };
            dt = bdl.SelectData("M_Member_Select_byID", prms);

            return dt;
        }

        
    }
}
