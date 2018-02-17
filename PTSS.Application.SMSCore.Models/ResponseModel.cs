using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public class ResponseModel
    {
        private string sClassName = "ResponseModel";
        public bool isSuccessful = false;
        public bool isException = false;
        public string sResponseCode;

        public void FailedWithException()
        {
            string sFunctionName = "FailedWithException()";
            this.isSuccessful = false;
            this.isException = true;
            this.sResponseCode = "9999";
        }
        public void FailedWithoutException()
        {
            string sFunctionName = "FailedWithoutException()";
            this.isSuccessful = false;
            this.isException = false;
            this.sResponseCode = "9999";
        }
        public void SuccessfullyPassed()
        {
            string sFunctionName = "SuccessfullyPassed()";
            this.isSuccessful = true;
            this.isException = false;
            this.sResponseCode = "0000";
        }
    }
    
}
