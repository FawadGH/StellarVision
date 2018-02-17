using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public static class ApplicationHelper
    {
        public static List<UserTypeModel> GetUserTypesList()
        {
            ResponseModel Result = new ResponseModel();
            List<UserTypeModel> UserTypeList = new List<UserTypeModel>();
            if (ApplicationWrapper.UserTypesList == null)
            {
                UserTypeModel UserTypeModel = new UserTypeModel();
                Result = UserTypeModel.GetAllUserTypesList();
                if (Result.isSuccessful)
                {
                    ApplicationWrapper.UserTypesList = UserTypeModel.UserTypeList.ToList();
                    UserTypeList = ApplicationWrapper.UserTypesList;
                }
            }
            else
            {
                UserTypeList = ApplicationWrapper.UserTypesList;
            }
            return UserTypeList;
        }

        public static List<UserLevelModel> GetUserLevelsList()
        {
            ResponseModel Result = new ResponseModel();
            List<UserLevelModel> UserLevelList = new List<UserLevelModel>();
            if (ApplicationWrapper.UserLevelsList == null)
            {
                UserLevelModel UserLevelModel = new UserLevelModel();
                Result = UserLevelModel.GetAllUserLevelsList();
                if (Result.isSuccessful)
                {
                    ApplicationWrapper.UserLevelsList = UserLevelModel.UserLevelList.ToList();
                    UserLevelList = ApplicationWrapper.UserLevelsList;
                }
            }
            else
            {
                UserLevelList = ApplicationWrapper.UserLevelsList;
            }
            return UserLevelList;
        }

        public static List<UserStatusModel> GetUserStatusList()
        {
            ResponseModel Result = new ResponseModel();
            List<UserStatusModel> UserStatusList = new List<UserStatusModel>();
            if (ApplicationWrapper.UserStatusList == null)
            {
                UserStatusModel UserStatusModel = new UserStatusModel();
                Result = UserStatusModel.GetAllUserStatusList();
                if (Result.isSuccessful)
                {
                    ApplicationWrapper.UserStatusList = UserStatusModel.UserStatusList.ToList();
                    UserStatusList = ApplicationWrapper.UserStatusList;
                }
            }
            else
            {
                UserStatusList = ApplicationWrapper.UserStatusList;
            }
            return UserStatusList;
        }
    }
}
