using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTSS.Application.SMSCore.Structure;
using PTSS.Application.SMSCore.Models;
using PTSS.Logger;

namespace SMSCore
{
    public class SMSCoreWebModel
    {
        private string sClassName = "SMSCoreWebModel";
        Logger oLog = new Logger();
        public bool ValidateLicense()
        {
            string sFunctionName = "ValidateLicense()";
            bool isLicenseValidated = false;
            
            #region Text Logging
            Global.oLog.Log(
                sClassName,
                sFunctionName,
                "Validate License Procedure Initiated.");
            #endregion Text Logging
            ResponseModel Response = new ResponseModel();
            try
            {
                LicenseStructure LicenseStructure = new LicenseStructure();
                LicenseModel LicenseModel;
                if (ApplicationWrapper.OrganizationModel != null)
                {
                    LicenseStructure.OrganizationModel = ApplicationWrapper.OrganizationModel;
                }
                else
                {
                    #region Text Logging
                    Global.oLog.Log(
                        sClassName,
                        sFunctionName,
                        "Organization Model is null.");
                    #endregion Text Logging

                }
                Response = LicenseStructure.setLicenseVariables(out LicenseModel);
                if(Response.isSuccessful)
                {
                    #region Text Logging
                    Global.oLog.Log(
                        sClassName,
                        sFunctionName,
                        "License Details fetched. Going to Validate License");
                    #endregion Text Logging
                    if(LicenseModel != null)
                    {
                        bool LicensesSet = LicenseModel.setLicenses();
                        if (LicensesSet)
                        {
                            if(LicenseModel.LicenseHash == ApplicationWrapper.OrganizationModel.LicenseHash)
                            {
                                #region Text Logging
                                Global.oLog.Log(
                                    sClassName,
                                    sFunctionName,
                                    "License Details Validated Successfully.");
                                #endregion Text Logging
                                isLicenseValidated = true;
                            }
                            else
                            {
                                #region Text Logging
                                Global.oLog.Log(
                                    sClassName,
                                    sFunctionName,
                                    "Invalid License Details. License Mismatch");
                                #endregion Text Logging
                                isLicenseValidated = false;
                            }
                        }
                        else
                        {
                            #region Text Logging
                            Global.oLog.Log(
                                sClassName,
                                sFunctionName,
                                "Invalid License Details.");
                            #endregion Text Logging

                        }
                    }
                    else
                    {
                        #region Text Logging
                        Global.oLog.Log(
                            sClassName,
                            sFunctionName,
                            "Failed to fetch License details.");
                        #endregion Text Logging

                    }
                }
                else
                {
                    #region Text Logging
                    Global.oLog.Log(
                        sClassName,
                        sFunctionName,
                        "Failed to load license details.");
                    #endregion Text Logging

                }
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging
                Response.FailedWithException();
            }

            return isLicenseValidated;
        }

        public ResponseModel setOrganization()
        {
            string sFunctionName = "setOrganization()";

            #region Text Logging
            Global.oLog.Log(
                sClassName,
                sFunctionName,
                "Going to fetch Organization Configuration.");
            #endregion Text Logging

            ResponseModel Response = new ResponseModel();
            try
            {
                //OrganizationStructure OrganizationStruct = new OrganizationStructure();
                //Response = OrganizationStruct.setOrganization();
                OrganizationModel OrganizationModel = new OrganizationModel();
                OrganizationModel.Initialize();
                if (OrganizationModel != null)
                {
                    bool LicenseHashSet = OrganizationModel.setLicenseHash();
                    if (LicenseHashSet)
                    {
                        ApplicationWrapper.OrganizationModel = OrganizationModel;
                        Response.SuccessfullyPassed();
                    }
                    else
                    {
                        #region Text Logging
                        Global.oLog.Log(
                            sClassName,
                            sFunctionName,
                            "Failed to Set Licenses.");
                        #endregion Text Logging
                        Response.FailedWithoutException();
                    }
                }
                else
                {
                    #region Text Logging
                    Global.oLog.Log(
                        sClassName,
                        sFunctionName,
                        "Failed to fetch Organization Configuration.");
                    #endregion Text Logging
                    Response.FailedWithoutException();
                }
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging
                Response.FailedWithException();
            }

            return Response;
        }

        public ResponseModel ValidateUserLogin(string UserID, string Password)
        {
            string sFunctionName = "ValidateUserLogin";
            ResponseModel Result = new ResponseModel();
            LoginStructure Login = new LoginStructure();

            try
            {
                Result = Login.AuthenticateUserLogin(UserID, Password);
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }

            return Result;
        }
    }
}