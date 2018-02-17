using PTSS.Application.SMSCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public class UserStatusModel
    {
        private string sClassName = "UserStatusModel";
        private SMSCoreData Data = new SMSCoreData();

        #region Column Names

        private const string cUserStatusID = "UserStatusID";
        private const string cUserStatusName = "UserStatusName";

        #endregion Column Names

        #region Get N Set

        public string UserStatusID { get; set; }
        public string UserStatusName { get; set; }
        public IEnumerable<UserStatusModel> UserStatusList { get; set; }

        #endregion Get N Set

        public ResponseModel GetAllUserStatusList()
        {
            string sFunctionName = "GetAllUserStatusList()";
            ResponseModel Result = new ResponseModel();
            try
            {
                DataView oDV = new DataView();
                Data.GetAllUserStatus(out oDV);
                UserStatusList = oDV.Table.AsEnumerable().Select(row => new UserStatusModel
                {
                    UserStatusID = row.Field<string>(cUserStatusID),
                    UserStatusName = row.Field<string>(cUserStatusName)
                });
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
    }
}
