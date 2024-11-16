using fINALPROJECTCORE.Signup_Interface;
using fINALPROJECTCORE.Signup_Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace fINALPROJECT.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ISignUpRepository repository;
        private readonly IEmailService emailService;

        public SignUpController(ISignUpRepository repository, IEmailService emailService)
        {
            this.repository = repository;
            this.emailService = emailService;
        }

        [Route("signup/getallDetail")]
        [HttpGet]
        public List<SignupModel> GetAll(string email, string password)
        {
           return repository.GetAll(email,password);
        }

        [Route("signup/insertRecord")]
        [HttpPost]
        public ActionResult RegistrationInsertRecord([FromForm]SignupModel model)
        {
            try
            {
                repository.RegistrationInsertRecord(model);
               return Json(new { Success = true , Message = "Inserted Successfully"});
            }
            catch (SqlException e)
            {
                return Json(new { Success = false ,Message = e.Message });
            }
        }

        [Route("signup/updatePassword")]
        [HttpPut]
        public ActionResult RegistrationUpdatePassword(string email, long mobile, string password)
        {
            try
            {
                repository.RegistrationUpdatePassword(email,mobile,password);
                MailRequest mailRequest = new MailRequest();
                mailRequest.ToEmail = email;
                mailRequest.Subject = "Security Alert";
                mailRequest.Body = "Your Password is Being Changed";
                emailService.SendEmail(mailRequest);
                return Json(new { Success = true, Message = "Passwod Updated" });
            }
            catch (SqlException e)
            {
                return Json(new { Success = false ,Message = e.Message });
            }
        }

        [Route("signup/changepassword")]
        [HttpPut]
        public ActionResult RegistrationChangePassword(string email, string password)
        {
            try
            {
                repository.ChangePassword(email, password);
                return Json(new { Success = true, Message = "Passwod Updated" });
            }
            catch (SqlException e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }

    }
}
