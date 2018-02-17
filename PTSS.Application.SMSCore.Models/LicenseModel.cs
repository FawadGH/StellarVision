using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Logger;

namespace PTSS.Application.SMSCore.Models
{
    public class LicenseModel
    {
        private string sClassName = "LicenseModel";

        Logger.Logger oLog = new Logger.Logger();

        private string sOrganizationName;
        private string sProductionYear;
        private string sTotalBranches;
        private string sOrganizationMnemonic;

        private string CustomPrivateKey;

        public string OrganizationName;
        public string OrganizationMnemonic;
        public string ProductionYear;
        public int TotalBranches;

        private string KeyString;
        private string License;
        public string LicenseHash;
        private string LicenseA;
        private string LicenseB;

        public string getKeyString()
        {
            return this.KeyString;
        }
        public void setKeyString(string Value)
        {
            this.KeyString = Value;
        }
        public string getLicense()
        {
            return this.License;
        }
        public void setLicense(string Value)
        {
            this.License = Value;
        }
        public string getLicenseHash()
        {
            return this.LicenseHash;
        }
        public void setLicenseHash(string Value)
        {
            this.LicenseHash = Value;
        }
        public string getLicenseA()
        {
            return this.LicenseA;
        }
        public void setLicenseA(string Value)
        {
            this.LicenseA = Value;
        }
        public string getLicenseB()
        {
            return this.LicenseB;
        }
        public void setLicenseB(string Value)
        {
            this.LicenseB = Value;
        }
        
        public bool setLicenses()
        {
            string sFunctionName = "setLicenses()";
            bool LicensesSet = false;
            try
            {
                GenerateKey();
                GenerateLicense();
                GetHash();
                LicensesSet = true;
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging
                LicensesSet = false;
            }
            return LicensesSet;
        }

        private void GenerateKey()
        {
            sOrganizationName = OrganizationName.Trim();
            sProductionYear = ProductionYear.Trim();
            sTotalBranches = TotalBranches.ToString().Trim().PadLeft(3, '0');
            sOrganizationMnemonic = OrganizationMnemonic.Trim().PadRight(10, '0');

            setKeyString(sOrganizationName + '_' + sProductionYear + '_' + sTotalBranches + '_' + sOrganizationMnemonic);
            
        }

        public bool bValidateKeyString()
        {
            bool bValidateKey = false;
            string[] sSegregatedValues = new string[4];// { "", "", "", "" };\
            sSegregatedValues = KeyString.Trim().Split('_');

            #region KeyValidation
            if (sSegregatedValues.Count() == 4) //All Values should be present
            {
                if (sSegregatedValues[0].Length <= 50) //Organization Name can be of Max 50 characters
                {
                    if (sSegregatedValues[1].Length == 4) //Year should be exactly 4 numbers.
                    {
                        if (sSegregatedValues[2].Length == 3) //Branches should be of max 3 length
                        {
                            if (sSegregatedValues[3].Length == 10) //Mnemonic should be exactly 10 characters long.
                            {
                                bValidateKey = true;
                            }
                        }
                    }
                }
            }
            #endregion KeyValidation

            if (bValidateKey)
            {
                sOrganizationName = sSegregatedValues[0];
                sProductionYear = sSegregatedValues[1];
                sTotalBranches = sSegregatedValues[2];
                sOrganizationMnemonic = sSegregatedValues[3];
            }
            return bValidateKey;
        }

        private void GenerateLicense()
        {
            string sFunctionName = "GenerateLicense()";
            try
            {
                PTSS.LicenserY.License LicenseY = new PTSS.LicenserY.License();
                if (isCustomPrivateKey())
                {
                    setLicense(LicenseY.GenerateLicense(KeyString.Trim(), CustomPrivateKey.Trim()));
                    License = getLicense();
                }
                else
                {
                    setLicense(LicenseY.GenerateLicense(KeyString.Trim()));
                    License = getLicense();
                }
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging

            }
        }
        
        public bool isCustomPrivateKey()
        {
            bool isPrivateKey = false;
            if (CustomPrivateKey != null)
            {
                if (CustomPrivateKey.Length == 16)
                {
                    isPrivateKey = true;
                }
            }
            return isPrivateKey;
        }

        private void GetHash()
        {
            string sFunctionName = "GetHash()";
            try
            {
                PTSS.LicenserY.License LicenseY = new PTSS.LicenserY.License();
                setLicenseHash(LicenseY.GetHash(License.Trim()));
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging

            }
        }
    }
}
