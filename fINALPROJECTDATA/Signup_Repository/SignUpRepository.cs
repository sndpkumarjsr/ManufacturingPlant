using Dapper;
using fINALPROJECTCORE.AppSettings;
using fINALPROJECTCORE.Signup_Interface;
using fINALPROJECTCORE.Signup_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTDATA.Signup_Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        IDbConnection connection = new SqlConnection(AppSettings.ConnnectionString.DevOps);

        public void ChangePassword(string email, string password)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Useremail", email);
            parameter.Add("UserPassword", password);
            connection.Execute("SPCHANGEPASSWORDOFSIGNUP", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<SignupModel> GetAll(string email, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("USEREMAIL", email);
            parameters.Add("USERpassword", password);
            var result = connection.Query<SignupModel>("SPGETALLDETAILSFROMSIGNUP",parameters, commandType: CommandType.StoredProcedure).ToList();
            if(result.Count <= 0 )
            {
                return null;
            }
            return result;
        }

        public void RegistrationInsertRecord(SignupModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("USERNAME", model.USERNAME);
            parameters.Add("USEREMAIL", model.USEREMAIL);
            parameters.Add("USERMOBILE", model.USERMOBILE);
            parameters.Add("USERADDRESS", model.USERADDRESS);
            parameters.Add("USERPASSWORD", model.USERPASSWORD);

            connection.Execute("SPINSERTRECORDINSIGNUP",parameters,commandType : CommandType.StoredProcedure);
        }

        public void RegistrationUpdatePassword(string email, long mobile, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("USEREMAIL", email);
            parameters.Add("USERMOBLE", mobile);
            parameters.Add("USERPASSWORD", password);

            connection.Execute("SPUPDATEPASSWORDINSIGNUP",parameters, commandType : CommandType.StoredProcedure);
        }
    }
}
