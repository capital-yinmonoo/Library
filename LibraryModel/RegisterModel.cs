using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class RegisterModel
    {
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberPassword { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        public string Mode { get; set; }
    }
}
