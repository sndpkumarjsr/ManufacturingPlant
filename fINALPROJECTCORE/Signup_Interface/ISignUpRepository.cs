using fINALPROJECTCORE.Signup_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTCORE.Signup_Interface
{
    public interface ISignUpRepository
    {
        List<SignupModel> GetAll(string email, string password);
        void RegistrationInsertRecord(SignupModel model);
        void RegistrationUpdatePassword(string email, long mobile, string password);
        void ChangePassword(string email, string password);

        

    }
}
