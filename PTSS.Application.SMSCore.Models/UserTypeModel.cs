using PTSS.Application.SMSCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public class UserTypeModel
    {
        private string sClassName = "UserTypeModel";
        private SMSCoreData Data = new SMSCoreData();

        #region Column Names

        private const string cUserTypeID = "UserTypeID";
        private const string cUserTypeName = "UserTypeName";

        #endregion Column Names
        #region Get N Set
        public string UserTypeName { get; set; }
        public string UserTypeID { get; set; }
        public string NewUserTypeName { get; set; }
        public IEnumerable<UserTypeModel> UserTypeList { get; set; }
        #endregion Get N Set
        public ResponseModel AddUserType(string UserTypeName)
        {
            string sFunctionName = "AddUserType()";
            ResponseModel Result = new ResponseModel();
            try
            {
                DataView oDV = new DataView();
                Data.getUserTypeByUserTypeName(UserTypeName, out oDV);
                Result.SuccessfullyPassed();
                foreach(DataRowView row in oDV)
                {
                    if (row[cUserTypeName].ToString() == UserTypeName)
                        Result.FailedWithoutException();
                }
                if (Result.isSuccessful)
                {
                    Data.AddUserType(UserTypeName);
                    Result.SuccessfullyPassed();
                }
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel GetAllUserTypesList()
        {
            string sFunctionName = "GetAllUserTypesList()";
            ResponseModel Result = new ResponseModel();
            try
            {
                DataView oDV = new DataView();
                Data.getAllUserTypes(out oDV);
                UserTypeList = oDV.Table.AsEnumerable().Select(row => new UserTypeModel()
                {
                    UserTypeID = row.Field<string>(cUserTypeID),
                    UserTypeName = row.Field<string>(cUserTypeName)
                });
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel EditUserType()
        {
            string sFunctionName = "EditUserType()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Data.editUserType(UserTypeName, NewUserTypeName);
                Result.SuccessfullyPassed();
                //Update Application Wrapper
                GetAllUserTypesList();
                ApplicationWrapper.UserTypesList = UserTypeList.ToList();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel DeleteUserType()
        {
            string sFunctionName = "DeleteUserType()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Data.deleteUserType(UserTypeName);
                Result.SuccessfullyPassed();
                //Update Application Wrapper
                GetAllUserTypesList();
                ApplicationWrapper.UserTypesList = UserTypeList.ToList();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
    }
}
