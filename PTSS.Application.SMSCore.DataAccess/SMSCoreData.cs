using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.DataAccess
{
    public class SMSCoreData
    {
        private string sClassName = "SMSCoreData";
        SMSCoreDataAccess oDA = new SMSCoreDataAccess();

        //public void getUserProfile(string sUserID, out DataView oDV)
        //{
        //    oDV = oDA.getDataView("Select * from Branches where ID = 1");
        //}
        public void getOrganizationDetails(out DataView oDV)
        {
            oDV = oDA.getDataView("Select * from Organization_Configuration");
        }
        public void getTotalBranches(out DataView oDV)
        {
            oDV = oDA.getDataView("Select count(*) from Branches where isActive = '1'");
        }
        public void getUserLoginDetails(string UserID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserID", SqlDbType.VarChar, 50)
            };
            oParam[0].Value = UserID;
            oDV = oDA.getDataViewProc("getUserLoginDetails", oParam);
        }
        public void getUserProfile(string UserID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserID", SqlDbType.VarChar, 50)
            };
            oParam[0].Value = UserID;
            oDV = oDA.getDataViewProc("getUserProfile", oParam);
        }
        public void getUserTypeDescription(string UserTypeID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = UserTypeID;
            oDV = oDA.getDataViewProc("getUserTypeDescription", oParam);
        }
        public void getUserTypeByUserTypeName(string UserTypeName, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeName;
            oDV = oDA.getDataViewProc("getUserTypeByUserTypeName", oParam);
        }
        public void getAllUserTypes(out DataView oDV)
        {
            oDV = oDA.getDataViewProc("getAllUserTypes");
        }
        public void getAllUserLevels(out DataView oDV)
        {
            oDV = oDA.getDataViewProc("getAllUserLevels");
        }
        public void getUserStatusDescription(string UserStatusID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserStatusID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = UserStatusID;
            oDV = oDA.getDataViewProc("getUserStatusDescription", oParam);
        }
        public void getUserLevelDescription(string UserTypeID, string UserLevelID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelID;
            oDV = oDA.getDataViewProc("getUserLevelDescription", oParam);
        }
        public void getUserLevelByUserTypeIDAndUserLevelName(string UserTypeID, string UserLevelName, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelName;
            oDV = oDA.getDataViewProc("getUserLevelByUserTypeIDAndUserLevelName", oParam);
        }
        public void getAllModules(out DataView oDV)
        {
            oDV = oDA.getDataViewProc("getAllModules");
        }
        public void getModuleByModuleID(string ModuleID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("ModuleID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = ModuleID;
            oDV = oDA.getDataViewProc("getModule", oParam);
        }
        public void getAllModuleFunctions(out DataView oDV)
        {
            oDV = oDA.getDataViewProc("getAllModuleFunctions");
        }
        public void getModuleFunctionsByModuleID(string ModuleID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("ModuleID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = ModuleID;
            oDV = oDA.getDataViewProc("getModuleFunctions", oParam);
        }
        public void getUserPermissionByUserTypeAndUserLevel(string UserTypeID, string UserLevelID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelID;
            oDV = oDA.getDataViewProc("getUserPermissionByUserTypeAndUserLevel", oParam);
        }
        public void getModuleFunction(string ModuleID, string ModuleFunctionID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("ModuleID", SqlDbType.VarChar, 3),
                new SqlParameter("ModuleFunctionID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = ModuleID;
            oParam[1].Value = ModuleFunctionID;
            oDV = oDA.getDataViewProc("getModuleFunction", oParam);
        }
        public void AddUserType(string UserTypeName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeName;
            oDA.InsertRecordProc("AddUserType", oParam);
        }
        public void AddUserLevel(string UserTypeID, string UserLevelName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelName;
            oDA.InsertRecordProc("AddUserLevel", oParam);
        }
        public void RemovePermissions(string UserTypeID, string UserLevelID)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelID;
            oDA.InsertRecordProc("RemovePermissions", oParam);
        }
        public void SetPermissions(string UserTypeID, string UserLevelID, string ModuleID, string ModuleFunctionID)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4),
                new SqlParameter("ModuleID", SqlDbType.VarChar, 3),
                new SqlParameter("ModuleFunctionID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelID;
            oParam[2].Value = ModuleID;
            oParam[3].Value = ModuleFunctionID;
            oDA.InsertRecordProc("SetPermissions", oParam);
        }
        public void GetAllUserStatus(out DataView oDV)
        {
            oDV = oDA.getDataViewProc("GetAllUserStatus");
        }
        public void AddUserLoginAndUserProfile(string UserID, string UserLoginPassword, string UserTypeID, string UserLevelID, string UserStatusID, string FirstName, string MiddleName, string LastName, string Email, string MobileNumber, string AlternateMobileNumber, string CNIC, string HomeAddress)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserID", SqlDbType.VarChar, 50),
                new SqlParameter("UserLoginPassword", SqlDbType.VarChar, 100),
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4),
                new SqlParameter("UserStatusID", SqlDbType.VarChar, 3),
                new SqlParameter("FirstName", SqlDbType.VarChar, 25),
                new SqlParameter("MiddleName", SqlDbType.VarChar, 25),
                new SqlParameter("LastName", SqlDbType.VarChar, 25),
                new SqlParameter("Email", SqlDbType.VarChar, 75),
                new SqlParameter("MobileNumber", SqlDbType.VarChar, 15),
                new SqlParameter("AlternateMobileNumber", SqlDbType.VarChar, 15),
                new SqlParameter("CNIC", SqlDbType.VarChar, 15),
                new SqlParameter("HomeAddress", SqlDbType.VarChar, 250)
            };
            oParam[0].Value = UserID;
            oParam[1].Value = UserLoginPassword;
            oParam[2].Value = UserTypeID;
            oParam[3].Value = UserLevelID;
            oParam[4].Value = UserStatusID;
            oParam[5].Value = FirstName;
            oParam[6].Value = MiddleName;
            oParam[7].Value = LastName;
            oParam[8].Value = Email;
            oParam[9].Value = MobileNumber;
            oParam[10].Value = AlternateMobileNumber;
            oParam[11].Value = CNIC;
            oParam[12].Value = HomeAddress;

            oDA.InsertRecordProc("AddUserLoginAndUserProfile", oParam);
        }

        public void SearchUsersByFilter(string UserID, string UserTypeID, string UserLevelID, string UserStatusID, out DataView oDV)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserID", SqlDbType.VarChar, 50),
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelID", SqlDbType.VarChar, 4),
                new SqlParameter("UserStatusID", SqlDbType.VarChar, 3)
            };
            oParam[0].Value = string.IsNullOrWhiteSpace(UserID) ? "-1" : UserID;
            oParam[1].Value = string.IsNullOrWhiteSpace(UserTypeID) ? "-1" : UserTypeID;
            oParam[2].Value = string.IsNullOrWhiteSpace(UserLevelID) ? "-1" : UserLevelID;
            oParam[3].Value = string.IsNullOrWhiteSpace(UserStatusID) ? "-1" : UserStatusID;

            oDV = oDA.getDataViewProc("SearchUsersByFilter", oParam);
        }

        public void editUserType(string UserTypeName, string NewUserTypeName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeName", SqlDbType.VarChar, 25),
                new SqlParameter("NewUserTypeName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeName;
            oParam[1].Value = NewUserTypeName;

            oDA.InsertRecordProc("editUserType", oParam);
        }

        public void editUserLevel(string UserLevelName, string UserTypeID, string NewUserLevelName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserLevelName", SqlDbType.VarChar, 25),
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("NewUserLevelName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserLevelName;
            oParam[1].Value = UserTypeID;
            oParam[2].Value = NewUserLevelName;

            oDA.InsertRecordProc("editUserLevel", oParam);
        }

        public void deleteUserType(string UserTypeName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeName;
            oDA.InsertRecordProc("deleteUserType", oParam);
        }

        public void deleteUserLevel(string UserTypeID, string UserLevelName)
        {
            SqlParameter[] oParam =
            {
                new SqlParameter("UserTypeID", SqlDbType.VarChar, 3),
                new SqlParameter("UserLevelName", SqlDbType.VarChar, 25)
            };
            oParam[0].Value = UserTypeID;
            oParam[1].Value = UserLevelName;
            oDA.InsertRecordProc("deleteUserLevel", oParam);
        }
    }
}
