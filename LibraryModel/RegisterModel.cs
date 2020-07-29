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
        public DateTime JoinDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Mode { get; set; }
        public string Gender { get; set; }
        public bool Graduated { get; set; }
        public bool Student { get; set; }
        public bool Master { get; set; }
    }
}
