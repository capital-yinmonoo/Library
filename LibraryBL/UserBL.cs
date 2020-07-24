using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryModel;
using LibraryDL;

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
    }
}
