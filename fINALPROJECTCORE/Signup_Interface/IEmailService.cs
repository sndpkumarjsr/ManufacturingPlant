﻿using fINALPROJECTCORE.Signup_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fINALPROJECTCORE.Signup_Interface
{
    public interface IEmailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
