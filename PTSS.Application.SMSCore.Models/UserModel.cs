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
    public class UserModel
    {
        private string sClassName = "UserModel";
        private SMSCoreData Data = new SMSCoreData();

        #region Column Names
        private const string rUserID = "UserID";
        private const string rFirstName = "FirstName";
        private const string rMiddleName = "MiddleName";
        private const string rLastName = "LastName";
        private const string rFullName = "FullName";
        private const string rEmail = "Email";
        private const string rMobileNumber = "MobileNumber";
        private const string rAlternateMobileNumber = "AlternateMobileNumber";
        private const string rCNIC = "CNIC";
        private const string rHomeAddress = "HomeAddress";
        private const string rUserTypeID = "UserTypeID";
        private const string rUserLoginPassword = "UserLoginPassword";
        private const string rUserLevelID = "UserLevelID";
        private const string rUserStatusID = "UserStatusID";
        private const string rLastLoginDateTime = "LastLoginDateTime";
        private const string rLastLogoutDateTime = "LastLogoutDateTime";
        private const string rLastSessionTotalTime = "LastSessionTotalTime";
        private const string risLoggedIn = "isLoggedIn";

        private const string cModuleID = "ModuleID";
        private const string cModuleFunctionID = "ModuleFunctionID";

        private const string cUserLevelID = "UserLevelID";
        private const string cUserTypeID = "UserTypeID";
        private const string cUserLevelName = "UserLevelName";
        private const string cUserTypeName = "UserTypeName";
        private const string cUserStatusID = "UserStatusID";
        private const string cUserStatusName = "UserStatusName";

        #endregion Column Name

        #region User Attributes

        private string sUserID;
        private string sFirstName;
        private string sMiddleName;
        private string sLastName;
        private string sFullName;
        private string sEmail;
        private string sMobileNumber;
        private string sAlternateMobileNumber;
        private string sCNIC;
        private string sHomeAddress;
        private string sUserTypeID;
        private string sUserLoginPassword;
        private string sConfirmPassword;
        private string sUserLevelID;
        private string sUserStatusID;
        private string sLastLoginDateTime;
        private string sLastLogoutDateTime;
        private string sLastSessionTotalTime;
        private string sisLoggedIn;
        private bool initialized;

        private UserTypeModel userType = new UserTypeModel();
        private UserLevelModel userLevel = new UserLevelModel();
        private UserStatusModel userStatus = new UserStatusModel();

        #endregion User Attributes

        #region GetNSet
        public string UserID
        {
            get
            {
                if (sUserID == null)
                    return null;
                else
                    return sUserID;
            }
            set
            {
                sUserID = value;
            }
        }
        public string FirstName
        {
            get
            {
                if (sFirstName == null)
                    return null;
                else
                    return sFirstName;
            }
            set
            {
                sFirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                if (sMiddleName == null)
                    return null;
                else
                    return " " + sMiddleName;
            }
            set
            {
                sMiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                if (sLastName == null)
                    return null;
                else
                    return " " + sLastName;
            }
            set
            {
                sLastName = value;
            }
        }
        public string FullName
        {
            get
            {
                if (sFullName == null)
                    return null;
                else
                    return sFullName;
            }
            set
            {
                sFullName = value;
            }
        }
        public string Email
        {
            get
            {
                if (sEmail == null)
                    return null;
                else
                    return sEmail;
            }
            set
            {
                sEmail = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                if (sMobileNumber == null)
                    return null;
                else
                    return sMobileNumber;
            }
            set
            {
                sMobileNumber = value;
            }
        }
        public string AlternateMobileNumber
        {
            get
            {
                if (sAlternateMobileNumber == null)
                    return null;
                else
                    return sAlternateMobileNumber;
            }
            set
            {
                sAlternateMobileNumber = value;
            }
        }
        public string CNIC
        {
            get
            {
                if (sCNIC == null)
                    return null;
                else
                    return sCNIC;
            }
            set
            {
                sCNIC = value;
            }
        }
        public string HomeAddress
        {
            get
            {
                if (sHomeAddress == null)
                    return null;
                else
                    return sHomeAddress;
            }
            set
            {
                sHomeAddress = value;
            }
        }
        public string UserTypeID
        {
            get
            {
                if (sUserTypeID == null)
                    return null;
                else
                    return sUserTypeID;
            }
            set
            {
                sUserTypeID = value;
                UserType.UserTypeID = value;
                UserType.UserTypeName = ApplicationHelper.GetUserTypesList().FirstOrDefault(userType => userType.UserTypeID == value).UserTypeName;
            }
        }
        
        public string UserLoginPassword
        {
            get
            {
                if (sUserLoginPassword == null)
                    return null;
                else
                    return sUserLoginPassword;
            }
            set
            {
                sUserLoginPassword = value;
            }
        }
        public string ConfirmPassword
        {
            get
            {
                if (sConfirmPassword == null)
                    return null;
                else
                    return sConfirmPassword;
            }
            set
            {
                sConfirmPassword = value;
            }
        }
        public string UserStatusID
        {
            get
            {
                if (sUserStatusID == null)
                    return null;
                else
                    return sUserStatusID;
            }
            set
            {
                sUserStatusID = value;
                UserStatus.UserStatusID = value;
                UserStatus.UserStatusName = ApplicationHelper.GetUserStatusList().FirstOrDefault(userStatus => userStatus.UserStatusID == value).UserStatusName;
            }
        }
        public string UserLevelID
        {
            get
            {
                if (sUserLevelID == null)
                    return null;
                else
                    return sUserLevelID;
            }
            set
            {
                sUserLevelID = value;
                UserLevel.UserLevelID = value;
                UserLevel.UserLevelName = ApplicationHelper.GetUserLevelsList().FirstOrDefault(userLevel => userLevel.UserLevelID == value).UserLevelName;
            }
        }
        public string LastLoginDateTime
        {
            get
            {
                if (sLastLoginDateTime == null)
                    return null;
                else
                    return sLastLoginDateTime;
            }
            set
            {
                sLastLoginDateTime = value;
            }
        }
        public string LastLogoutDateTime
        {
            get
            {
                if (sLastLogoutDateTime == null)
                    return null;
                else
                    return sLastLogoutDateTime;
            }
            set
            {
                sLastLogoutDateTime = value;
            }
        }
        public string LastSessionTotalTime
        {
            get
            {
                if (sLastSessionTotalTime == null)
                    return null;
                else
                    return sLastSessionTotalTime;
            }
            set
            {
                sLastSessionTotalTime = value;
            }
        }
        public string isLoggedIn
        {
            get
            {
                if (sisLoggedIn == null)
                    return null;
                else
                    return sisLoggedIn;
            }
            set
            {
                sisLoggedIn = value;
            }
        }
        public bool Initialized
        {
            get
            {
                return initialized;
            }
            set
            {
                initialized = value;
            }
        }
        public class UserPermission
        {
            public string ModuleID { get; set; }
            public string ModuleFunctionID { get; set; }
        }
        public UserTypeModel UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }
        public UserLevelModel UserLevel
        {
            get
            {
                return userLevel;
            }
            set
            {
                userLevel = value;
            }
        }
        public UserStatusModel UserStatus
        {
            get
            {
                return userStatus;
            }
            set
            {
                userStatus = value;
            }
        }
        public List<UserPermission> UserPermissions { get; set; }
        public IEnumerable<SelectListItem> UserTypeSelectList { get; set; }
        public IEnumerable<SelectListItem> UserLevelSelectList { get; set; }
        public IEnumerable<SelectListItem> UserStatusSelectList { get; set; }
        public IEnumerable<UserTypeModel> UserTypeList { get; set; }
        public IEnumerable<UserLevelModel> UserLevelList { get; set; }
        public IEnumerable<UserStatusModel> UserStatusList { get; set; }
        public IEnumerable<UserModel> FilteredUsersList { get; set; }

        public bool isUserIDAvailable { get; set; }

        #endregion GetNSet
        /// <summary>
        /// Initializes the User Model for existing user
        /// </summary>
        /// <param name="UserID"></param>
        public void Initialize(string UserID)
        {
            ResponseModel Result = new ResponseModel();
            Result = GetUserProfile(UserID);
            if(!Result.isSuccessful)
            {
                Initialized = false;
            }
            else
            {
                Result = GetUserLoginDetails(UserID);
                if (!Result.isSuccessful)
                {
                    Initialized = false;
                }
                else
                {
                    Initialized = true;
                }
            }
        }
        /// <summary>
        /// Initializes the User Model without user.
        /// </summary>
        public void Initialize()
        {
            UserTypeList = ApplicationHelper.GetUserTypesList();
            UserLevelList = ApplicationHelper.GetUserLevelsList();
            UserStatusList = ApplicationHelper.GetUserStatusList();

            UserTypeSelectList = ControlHelper.GetSelectList(UserTypeList, cUserTypeID, cUserTypeName);
            UserLevelSelectList = ControlHelper.GetSelectList(UserLevelList, cUserLevelID, cUserLevelName);
            UserStatusSelectList = ControlHelper.GetSelectList(UserStatusList, cUserStatusID, cUserStatusName);
        }
        public ResponseModel GetUserLoginDetails(string UserID)
        {
            string sFunctionName = "GetUserLoginDetails()";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            Result.FailedWithoutException();
            try
            {
                Data.getUserLoginDetails(UserID, out oDV);
                foreach (DataRowView row in oDV)
                {
                    UserLoginPassword = row[rUserLoginPassword].ToString();
                    UserLevelID = row[rUserLevelID].ToString();
                    UserStatusID = row[rUserStatusID].ToString();
                    LastLoginDateTime = row[rLastLoginDateTime].ToString();
                    LastLogoutDateTime = row[rLastLogoutDateTime].ToString();
                    LastSessionTotalTime = row[rLastSessionTotalTime].ToString();
                    isLoggedIn = row[risLoggedIn].ToString();

                    Result.SuccessfullyPassed();
                }
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }

            return Result;
        }

        public ResponseModel GetUserProfile(string UserID)
        {
            string sFunctionName = "GetUserProfile()";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            Result.FailedWithoutException();
            try
            {
                Data.getUserProfile(UserID, out oDV);
                foreach (DataRowView row in oDV)
                {
                    FirstName = row[rFirstName].ToString();
                    MiddleName = row[rMiddleName].ToString();
                    LastName = row[rLastName].ToString();
                    FullName = row[rFullName].ToString();
                    Email = row[rEmail].ToString();
                    MobileNumber = row[rMobileNumber].ToString();
                    AlternateMobileNumber = row[rAlternateMobileNumber].ToString();
                    CNIC = row[rCNIC].ToString();
                    HomeAddress = row[rHomeAddress].ToString();
                    UserTypeID = row[rUserTypeID].ToString();

                    Result.SuccessfullyPassed();
                }
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }

            return Result;
        }
        public ResponseModel ValidatePassword(string inputPassword)
        {
            string sFunctionName = "ValidatePassword";
            ResponseModel Result = new ResponseModel();
            SecurityModel Security = new SecurityModel();
            try
            {
                if (inputPassword == Security.sDecrypt(UserLoginPassword))
                {
                    Result.SuccessfullyPassed();
                }
                else
                {
                    Result.FailedWithoutException();
                }
            }
            catch(Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }
        public ResponseModel GetUserPermissions(string UserTypeID, string UserLevelID)
        {
            string sFunctionName = "GetUserPermissions(,)";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            UserPermissions = new List<UserPermission>();
            try
            {
                Data.getUserPermissionByUserTypeAndUserLevel(UserTypeID, UserLevelID, out oDV);
                foreach(DataRowView row in oDV)
                {
                    UserPermission UP = new UserPermission();
                    UP.ModuleID = row[cModuleID].ToString();
                    UP.ModuleFunctionID = row[cModuleFunctionID].ToString();
                    UserPermissions.Add(UP);
                }
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }
        public void GetUserLevels(string UserTypeID)
        {
            UserLevelSelectList = ControlHelper.GetSelectList(UserLevelList.Where(x => x.UserTypeID == UserTypeID), cUserLevelID, cUserLevelName);
        }
        public ResponseModel CheckUserIDAvailability(string UserID)
        {
            string sFunctionName = "CheckUserIDAvailability()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                DataView oDV = new DataView();
                Data.getUserLoginDetails(UserID, out oDV);

                isUserIDAvailable = oDV.Table?.Rows?.Count > 0 ? false : true;

                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
        public ResponseModel AddUserLoginAndUserProfile()
        {
            string sFunctionName = "AddUserLoginAndUserProfile";
            SecurityModel security = new SecurityModel();
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Data.AddUserLoginAndUserProfile(UserID, security.sEncrypt(UserLoginPassword), UserTypeID, UserLevelID, UserStatusID, FirstName, MiddleName, LastName, Email, MobileNumber, AlternateMobileNumber, CNIC, HomeAddress);
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
        public ResponseModel SearchUsersByFilter()
        {
            string sFunctionName = "SearchUsersByFilter";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                DataView oDV = new DataView();
                Data.SearchUsersByFilter(UserID, UserTypeID, UserLevelID, UserStatusID, out oDV);
                FilteredUsersList = oDV.Table?.AsEnumerable().Select(row => new UserModel
                {
                    UserID = row.Field<string>(rUserID),
                    FirstName = row.Field<string>(rFirstName),
                    MiddleName = row.Field<string>(rMiddleName),
                    LastName = row.Field<string>(rLastName),
                    FullName = row.Field<string>(rFullName),
                    Email = row.Field<string>(rEmail),
                    MobileNumber = row.Field<string>(rMobileNumber),
                    AlternateMobileNumber = row.Field<string>(rAlternateMobileNumber),
                    CNIC = row.Field<string>(rCNIC),
                    HomeAddress = row.Field<string>(rHomeAddress),
                    UserTypeID = row.Field<string>(rUserTypeID),
                    UserLevelID = row.Field<string>(rUserLevelID),
                    UserStatusID = row.Field<string>(rUserStatusID),
                    LastLoginDateTime = row.Field<string>(rLastLoginDateTime),
                    LastLogoutDateTime = row.Field<string>(rLastLoginDateTime),
                    LastSessionTotalTime = row.Field<string>(rLastSessionTotalTime),
                    isLoggedIn = row.Field<string>(risLoggedIn)
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
