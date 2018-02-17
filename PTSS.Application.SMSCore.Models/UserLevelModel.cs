using PTSS.Application.SMSCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PTSS.Application.SMSCore.Models
{
    public class UserLevelModel
    {
        private string sClassName = "UserLevelModel";
        private SMSCoreData Data = new SMSCoreData();

        #region Column Names
        private const string cUserLevelID = "UserLevelID";
        private const string cUserTypeID = "UserTypeID";
        private const string cUserLevelName = "UserLevelName";

        private const string cUserTypeName = "UserTypeName";
        #endregion Column Names

        #region Get N Set
        public string UserLevelName { get; set; }
        public string UserLevelID { get; set; }
        public string NewUserLevelName { get; set; }
        private string userTypeID;
        public string UserTypeID
        {
            get
            {
                return userTypeID;
            }
            set
            {
                userTypeID = value;
                UserTypeName = ApplicationHelper.GetUserTypesList().FirstOrDefault(x => x.UserTypeID == value).UserTypeName;
            }
        }
        public string UserTypeName { get; set; }
        public IEnumerable<SelectListItem> UserTypeList { get; set; }
        public IEnumerable<UserLevelModel> UserLevelList { get; set; }
        #endregion Get N Set
        public ResponseModel AddUserLevel(string UserTypeID, string UserLevelName)
        {
            string sFunctionName = "AddUserLevel(,)";
            ResponseModel Result = new ResponseModel();
            try
            {
                DataView oDV = new DataView();
                Data.getUserLevelByUserTypeIDAndUserLevelName(UserTypeID, UserLevelName, out oDV);
                Result.SuccessfullyPassed();
                foreach (DataRowView row in oDV)
                {
                    if (row[cUserLevelName].ToString() == UserLevelName)
                        Result.FailedWithoutException();
                }
                if (Result.isSuccessful)
                {
                    Data.AddUserLevel(UserTypeID, UserLevelName);
                    Result.SuccessfullyPassed();
                }
            }
            catch (Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
        public void Initialize()
        {
            DataView oDV = new DataView();
            Data.getAllUserTypes(out oDV);
            UserTypeList = ControlHelper.GetSelectList(oDV, cUserTypeID, cUserTypeName);
        }
        public ResponseModel GetAllUserLevelsList()
        {
            string sFunctionName = "GetAllUserLevelsList()";
            ResponseModel Result = new ResponseModel();
            try
            {
                DataView oDV = new DataView();
                Data.getAllUserLevels(out oDV);
                UserLevelList = oDV.Table.AsEnumerable().Select(row => new UserLevelModel()
                {
                    UserLevelID = row.Field<string>(cUserLevelID),
                    UserLevelName = row.Field<string>(cUserLevelName),
                    UserTypeID = row.Field<string>(cUserTypeID)
                });
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel EditUserLevel()
        {
            string sFunctionName = "EditUserLevel()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Data.editUserLevel(UserLevelName, UserTypeID, NewUserLevelName);
                Result.SuccessfullyPassed();
                //Update Application Wrapper
                GetAllUserLevelsList();
                ApplicationWrapper.UserLevelsList = UserLevelList.ToList();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel DeleteUserLevel()
        {
            string sFunctionName = "DeleteUserLevel()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Data.deleteUserLevel(UserTypeID, UserLevelName);
                Result.SuccessfullyPassed();
                //Update Application Wrapper
                GetAllUserLevelsList();
                ApplicationWrapper.UserLevelsList = UserLevelList.ToList();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
    }
}
