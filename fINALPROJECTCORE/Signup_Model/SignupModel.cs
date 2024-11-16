using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTCORE.Signup_Model
{
    public class SignupModel
    {
        public int USERID { get; set; }
        public string USERNAME { get; set; }

        public string USEREMAIL { get; set; }
        public long USERMOBILE { get; set; }
        public string USERADDRESS { get; set; }
        public string USERPASSWORD { get; set; }
        public int ACTIVE { get; set; }
    }
}
